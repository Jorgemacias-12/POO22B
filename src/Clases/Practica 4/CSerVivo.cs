using POO22B_MZJA.src.Utils;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser vivo                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public abstract class CSerVivo : Button
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // Donde Nacio
        private int XNacimiento;
        private int YNacimiento;
        private Point CoordenadasNacimiento;

        // Limites de crecimiento
        protected int LimiteAncho;
        protected int LimiteAlto;

        // Prevent non safe thread issues
        private readonly Object ThrLock;

        // Atributos del áre de desplazamiento
        protected Control AreaDesplazamiento;

        // Atributos de dirección
        protected bool Norte;
        protected bool Sur;
        protected bool Este;
        protected bool Oeste;
        protected int Velocidad;

        // Atributos de control
        protected bool Nacio;
        protected bool RegresarACasa;
        protected bool Muerto;
        protected bool Crecido;
        protected double Hambre;
        protected double ComidaIngerida;
        protected int LimiteInanicion;
        protected Oxigeno Oxigeno;
        protected bool HaySol;
        protected Random Rand;

        // Atributos de ejecución
        protected Thread ProcesoDesplazamiento;
        protected Thread ProcesoNacimiento;
        protected Thread ProcesoComer;
        private Thread ProcesoMuerte;
        private Thread ProcesoCansancio;
        private Thread ProcesoCrecimiento;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo(Control AreaDesplazamiento, int XNacimiento,
                        int YNacimiento, Oxigeno Oxigeno, bool HaySol,
                        int LimiteInanicion)
        {
            Constructor(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion);

            // Prevent non safe thread issues
            ThrLock = new object();
        }

        private void Constructor(Control AreaDesplazamiento, int XNacimiento,
                                 int YNacimiento, Oxigeno Oxigeno, bool HaySol,
                                 int LimiteInanicion)
        {
            // Asigna valores de nacimiento del ser vivo
            this.XNacimiento = XNacimiento;
            this.YNacimiento = YNacimiento;
            this.Oxigeno = Oxigeno;
            this.HaySol = HaySol;
            this.LimiteInanicion = LimiteInanicion;

            // Inicializar random
            Rand = new Random();

            // Inicializar point
            CoordenadasNacimiento = new Point();

            // Inicializa atributos del ecosistema
            this.AreaDesplazamiento = AreaDesplazamiento;
            this.AreaDesplazamiento.Controls.Add(this);

            // Inicializa atributos de navegación
            Norte = false;
            Sur = true;
            Este = true;
            Oeste = false;
            Velocidad = 0;

            // Incializa atributos de control.
            Nacio = false;
            RegresarACasa = false;
            Muerto = false;
            Crecido = false;

            // Incializa atributos de ejecución.
            ProcesoDesplazamiento = null;

            // Propiedades del Ser Vivo.

            // Si las coordenadas de nacimiento son 0
            // Se generan unas aleatorias
            CoordenadasNacimiento.X = this.XNacimiento == 0 ? Rand.Next(1, AreaDesplazamiento.Width - Width + LimiteAncho) : XNacimiento;
            CoordenadasNacimiento.Y = this.YNacimiento == 0 ? Rand.Next(1, AreaDesplazamiento.Height - Height + LimiteAlto) : YNacimiento;

            // Asignar coordenadas al ser vivo
            Location = CoordenadasNacimiento;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 1;
            BackColor = Color.White;
            Name = "Ser Vivo";
            Size = new Size(32, 32);
            BringToFront();

            // Accionar cuando hacemos clic en el
            Click += new EventHandler(EnClic);
        }

        // +------------------------------------------------------------------+
        // |  Permite al ser vivo ejecutar un operacion cuando se haaga clic  |
        // |  en este.                                                        |
        // +------------------------------------------------------------------+
        public abstract void EnClic(object sender, EventArgs e);

        // +------------------------------------------------------------------+
        // | Le da un formato (imagen) al SerVivo que va a generarse.         |   
        // +------------------------------------------------------------------+
        protected virtual void GenerarTipo()
        {
            BackColor = ColorUtils.GetRandomColor();
            ForeColor = ColorUtils.GetForegroundColor(BackColor);
        }

        public virtual void Morir()
        {
            ProcesoMuerte = new Thread(() =>
            {
                Muerto = true;
                Text = "D";
                BackColor = ColorUtils.GetColor("#ff4d4d");

                Thread.Sleep(500);

                Visible = false;

                AreaDesplazamiento.Controls.Remove(this);
                AreaDesplazamiento.Invalidate();

            });

            ProcesoMuerte.Start();
        }

        // +------------------------------------------------------------------+
        // | El Ser Vivo comienza el proceso de nacimiento.                   |   
        // +------------------------------------------------------------------+
        public virtual void Nacer()
        {
            ProcesoNacimiento = new Thread(() =>
            {
                // Comprueba si hay oxigeno suficiente
                if (Oxigeno.ValorActual <= 0)
                {
                    MessageBox.Show("No hay oxigeno disponible");
                    Thread.Sleep(1000);
                    Morir();
                    return;
                }

                // Comprueba si hay sol
                if (!HaySol)
                {
                    Thread.Sleep(1000);
                    Morir();
                    return;
                }

                Nacio = true;
                // Sobreescribir cantidad de oxigeno a consumir en los hijos
                Oxigeno.ValorActual -= 1;
                Muerto = false;
                Hambre = 0;
                ComidaIngerida = 0;

                Crecer();

            });

            ProcesoNacimiento.Start();

        }

        // +------------------------------------------------------------------+
        // | El Ser Vivo tiene unos limites de crecimiento generados, para    |
        // | posteriormente crecer en función del tiempo y un numero.         |
        // +------------------------------------------------------------------+
        public virtual void Crecer()
        {
            ProcesoCrecimiento = new Thread(() =>
            {
                LimiteAncho = Rand.Next(40, 65);
                LimiteAlto = Rand.Next(40, 65);

                while (!Crecido)
                {
                    if (Width >= LimiteAlto && Height >= LimiteAlto)
                    {
                        Crecido = true;
                    }

                    Width += 1;
                    Height += 1;

                }

            });

            ProcesoCrecimiento.Start();
        }

        // +------------------------------------------------------------------+
        // | El Ser Vivo al desplazarse se cansa, esto conlleva a consumir    |
        // | oxigeno, y acumular hambre si estos dos llegan a limites el ser  |
        // | vivo muere.                                                      |
        // +------------------------------------------------------------------+
        protected virtual void Cansarse()
        {
            ProcesoCansancio = new Thread(() =>
            {
                while (!Muerto && Nacio)
                {
                    Thread.Sleep(1000);

                    Hambre += Rand.Next(0, (int)(LimiteInanicion * 0.10f));

                    if (Hambre >= LimiteInanicion)
                    {
                        Morir();
                        return;
                    }

                    if (Oxigeno.ValorActual <= 0)
                    {
                        Morir();
                    }

                }
            });

            ProcesoCansancio.Start();
        }

        public virtual void Desplazar(int Velocidad)
        {
            // Variables para almacenar posición del ser vivo
            int X;
            int Y;

            this.Velocidad = Velocidad;

            ProcesoDesplazamiento = new Thread(() =>
            {
                while (!Muerto && Nacio)
                {
                    // Obtener posición actual del ser vivo
                    X = Location.X;
                    Y = Location.Y;

                    // Banderas para control de dirección
                    if (Norte)
                    {
                        Y -= 1;
                    }

                    if (Sur)
                    {
                        Y += 1;
                    }

                    if (Este)
                    {
                        X += 1;
                    }

                    if (Oeste)
                    {
                        X -= 1;
                    }

                    // Evitar que el ser vivo salga del ecosistema

                    if (X <= 0)
                    {
                        this.Oeste = false;

                        if (!RegresarACasa)
                        {
                            this.Este = true;
                        }

                    }

                    if (Y <= 0)
                    {
                        this.Norte = false;

                        if (!RegresarACasa)
                        {
                            this.Sur = true;
                        }

                    }

                    if (X >= AreaDesplazamiento.Width - Width)
                    {
                        this.Oeste = true;
                        this.Este = false;
                    }

                    if (Y >= AreaDesplazamiento.Height - Height)
                    {
                        this.Norte = true;
                        this.Sur = false;
                    }

                    // Cambiar a nueva posición
                    Location = new Point(X, Y);
                    Thread.Sleep(this.Velocidad);
                }

            });

            ProcesoDesplazamiento.Start();
        }

        public virtual void Comer()
        {
            ProcesoComer = new Thread(() =>
            {
            int ComidaEncontrada;

            ComidaEncontrada = 0;

            if (LimiteInanicion > 1000)
            {
                ComidaEncontrada = Rand.Next(100, (int)(LimiteInanicion * 0.20f));
            }

            if (LimiteInanicion < 1000)
            {
                ComidaEncontrada = Rand.Next(0, 950);
            }


            // Prevenir cualquier bug extraño
            // con valores menores a 0
            if (ComidaEncontrada == 0)
            {
                return;
            }

            // Almacenar la comida encontrada
            ComidaIngerida += ComidaEncontrada;

            // "Comer"
            Hambre -= ComidaEncontrada;

            // Mostrar información acerca de la operación
            MessageBox.Show(
                $"{GetType()} Ha comido - Comida Encontada: {ComidaEncontrada} - Hambre: {Hambre} " +
                $"Esta muerto? {Muerto} - Comida Ingerida: {ComidaIngerida}");

        });

            ProcesoComer.Start();
        }

    // +------------------------------------------------------------------+
    // | Establecer bandera muerto a verdadero para evitar                |
    // | conflictos con todo el hilo principal del programa.              |   
    // +------------------------------------------------------------------+
    protected override void Dispose(bool disposing)
        {
            Muerto = true;
            base.Dispose(disposing);
        }

    }
}
