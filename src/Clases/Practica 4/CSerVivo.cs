using POO22B_MZJA.src.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser vivo                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CSerVivo : FButton.FlatButton
    {
        // TODO: implementar método de movimiento en clase Animal

        /*
         * 1 -> DlgPractica 4
         * 2 -> CSerVivo
         * 
         * Clase Animal
         * 
         */

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // Atributos de la base
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
        protected bool Crecio;
        protected double Hambre;
        protected double ComidaIngerida;
        protected double LimiteInanicion;
        private Random Rand;

        // Atributos de ejecución
        protected Thread ProcesoVida;
        private Thread ProcesoCansancio;
        private Thread ProcesoComer;
        private Thread ProcesoMuerte;
        private Thread ProcesoCrecer;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo(Control AreaDesplazamiento, int XNacimiento, int YNacimiento)
        {
            Constructor(AreaDesplazamiento, XNacimiento, YNacimiento);
        }

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo(Control AreaDesplazamiento)
        {
            Constructor(AreaDesplazamiento, 0, 0);
        }

        // +------------------------------------------------------------------+
        // |  Contiene el funcionamiento de inicialización                    |
        // +------------------------------------------------------------------+
        private void Constructor(Control AreaDesplazamiento, int XNacimiento, int YNacimiento)
        {
            // Inicializa atributos de la base
            this.XNacimiento = XNacimiento;
            this.YNacimiento = YNacimiento;

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
            Crecio = false;

            // Incializa atributos de ejecución.
            ProcesoVida = null;

            // Propiedades del Ser Vivo.
            Location = new Point(this.XNacimiento, this.YNacimiento);
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 1;
            BackColor = Color.White;
            Name = "Particula";
            Size = new Size(32, 32);
            BringToFront();

            // Accionar cuando hacemos clic en el
            Click += CSerVivo_Click;

        }

        protected virtual void GenerarTipo() { }

        // +------------------------------------------------------------------+
        // | El ser vivo                                                      |   
        // +------------------------------------------------------------------+
        private void CSerVivo_Click(object sender, EventArgs e)
        {
            Comer();
        }

        // +------------------------------------------------------------------+
        // | Proceso de crecimiento del ser vivo                              |   
        // +------------------------------------------------------------------+
        public virtual void Crecer() 
        {
            Padding p;

            ProcesoCrecer = new Thread( () =>
            {
                LimiteAlto = Rand.Next(40, 75);
                LimiteAncho = Rand.Next(40, 75);

                while(!Crecio)
                {
                    Thread.Sleep(500);

                    if (Width >= LimiteAncho && Height >= LimiteAlto) 
                    {
                        Crecio = true;
                    }
                    
                    Width += Rand.Next(1, 20);
                    Height += Rand.Next(1, 20);
                }

            });

            ProcesoCrecer.Start();

        }

        // +------------------------------------------------------------------+
        // |  Método virtual para colorear a un ser vivo                      |
        // +------------------------------------------------------------------+
        public Color Colorear()
        {
            return ColorUtils.GetRandomColor();
        }

        // +------------------------------------------------------------------+
        // | Comienza el proceso de nacimiento                                |   
        // +------------------------------------------------------------------+
        public virtual void Nacer(int LimiteInanicion, ref int NivelOxigeno)
        {
            Thread Proceso;
            Color ColorAleatorio;

            // Comprobar si hay suficiente oxigeno
            if (NivelOxigeno < 0 ||
                NivelOxigeno > 100) return; 

            // El ser vivo consume oxigeno al nacer
            NivelOxigeno -= 1;

            // Ser vivo obteiene su color de piel.
            ColorAleatorio = Colorear();

            // El ser vivo nace.

            Proceso = new Thread(() =>
            {
                Thread.Sleep(1500);
                BackColor = ColorAleatorio;

                // Inicializar variables de vitalidad
                Nacio = true;
                Muerto = false;
                Hambre = 0;
                ComidaIngerida = 0;
                this.LimiteInanicion = LimiteInanicion;

                // El ser vivo crece
                Crecer();

                // Ser vivo comienza a cansarse
                Cansarse();


            });

            Proceso.Start();
        }

        // +------------------------------------------------------------------+
        // | Genera un numéro aleátorio de hambre y lo va acumula             |   
        // +------------------------------------------------------------------+
        protected virtual void Cansarse()
        {
            ProcesoCansancio = new Thread(() =>
            {
                while (!Muerto && Nacio)
                {
                    Thread.Sleep(500);

                    Hambre += Rand.Next(1, 50);

                    // Ejecutar el método morir si la hambre acumulada  
                    // es mayor a 300
                    if (Hambre >= LimiteInanicion)
                    {
                        Morir();
                    }

                }

            });

            ProcesoCansancio.Start();

        }

        public virtual void Desplazar(int Velocidad)
        {
            // Variables de posición inicial
            int X;
            int Y;

            this.Velocidad = Velocidad;

            // Desplaza la particula por tiempo indefinido
            // NOTA: Se utiliza un hilo de ejecución, el cual deberá
            // ser  finalizazdo al término del programa.

            ProcesoVida = new Thread(() =>
            {
                while (!Muerto)
                {
                    if (Nacio)
                    {

                        // Posición inical.
                        X = Location.X;
                        Y = Location.Y;

                        // Calcula desplazamiento

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

                        // Determinar rebote

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

                        // Posición final 
                        Location = new Point(X, Y);
                        Thread.Sleep(this.Velocidad);
                    }
                }
            });

            ProcesoVida.Start();

        }

        public virtual void Comer()
        {
            // Generar cada segundo incrementar una variable de hambre
            ProcesoComer = new Thread(() =>
            {
                int ComidaEncontrada;

                ComidaEncontrada = Rand.Next(20, 100);

                if (ComidaEncontrada < 0)
                {
                    ComidaEncontrada = 0;
                }

                ComidaIngerida += ComidaEncontrada;

                Hambre -= ComidaEncontrada;

                MessageBox.Show(
                    $"Debug info: Comida Encontrada: {ComidaEncontrada}, Hambre: {Hambre}, Muerto? {Muerto} " +
                    $"Comida Ingerida: {ComidaIngerida}");

            });

            ProcesoComer.Start();

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

        protected override void Dispose(bool disposing)
        {
            Muerto = true;
            base.Dispose(disposing);
        }

    }
}
