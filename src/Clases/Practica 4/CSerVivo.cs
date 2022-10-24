using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
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

        // Limites de crecimiento
        protected int LimiteAncho;
        protected int LimiteAlto;

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
        protected int OxigenoAlmacenado;
        protected bool HaySol;
        private Random Rand;

        // Atributos de ejecución
        protected Thread ProcesoNacimiento;
        protected Thread ProcesoDesplazamiento;
        private Thread ProcesoCansancio;
        private Thread ProcesoComer;
        private Thread ProcesoMuerte;
        private Thread ProcesoCrecimiento;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo(Control AreaDesplazamiento, int XNacimiento,
                        int YNacimiento, int NivelOxigeno, bool HaySol,
                        int LimiteInanicion)
        {
            Constructor(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion);
        }

        private void Constructor(Control AreaDesplazamiento, int XNacimiento,
                                 int YNacimiento, int NivelOxigeno, bool HaySol,
                                 int LimiteInanicion)
        {
            // Asigna valores de nacimiento del ser vivo
            this.XNacimiento = XNacimiento;
            this.YNacimiento = YNacimiento;
            OxigenoAlmacenado = NivelOxigeno;
            this.HaySol = HaySol;
            this.LimiteInanicion = LimiteInanicion;

            // Inicializar random
            Rand = new Random();

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
            Location = new Point(this.XNacimiento, this.YNacimiento);
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
                Thread.Sleep(1000);
                AreaDesplazamiento.Update();
                Dispose();
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
                if (OxigenoAlmacenado <= 0)
                {
                    Thread.Sleep(1000);
                    Morir();
                }

                // Comprueba si hay sol
                if (!HaySol)
                {
                    Thread.Sleep(1000);
                    Morir();
                }

                // Nacer en posiciones aleatorias si las coordenadas de
                // nacimiento son iguales a 0
                if (XNacimiento == 0 && YNacimiento == 0)
                {
                    Location = new Point(Rand.Next(1, AreaDesplazamiento.Width - Width + LimiteAncho),
                                         Rand.Next(1, AreaDesplazamiento.Height - Height + LimiteAlto));
                }

                Nacio = true;
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

                    Thread.Sleep(50);

                    Hambre += Rand.Next(0, 25);

                    if (Hambre >= LimiteInanicion)
                    {
                        Morir();
                    }

                    if (OxigenoAlmacenado <= 0)
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
                while(!Muerto && Nacio)
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
                int MinComidaAGenerar;
                int MaxComidaAGenerar;

                MinComidaAGenerar = (int)(LimiteInanicion * 0.2);
                MaxComidaAGenerar = LimiteInanicion * 2;

                ComidaEncontrada = Rand.Next(MinComidaAGenerar, 1000);

                // Prevenir cualquier bug extraño
                // con valores menores a 0
                if ( ComidaEncontrada < 0)
                {
                    ComidaEncontrada = 0;
                }

                // Almacenar la comida encontrada
                ComidaIngerida += ComidaEncontrada;

                // "Comer"
                Hambre -= ComidaEncontrada;

                // Mostrar información acerca de la operación
                MessageBox.Show(
                    $"Ser Vivo Ha comido - Comida Encontada: {ComidaEncontrada} - Hambre: {Hambre} " +
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
