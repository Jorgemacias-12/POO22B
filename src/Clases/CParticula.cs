using POO22B_MZJA.src.Utils;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +----------------------------------------------------------------------+
    // | Clase que representa una particula                                   |
    // | MZJA 08/09/2022                                                      |
    // +----------------------------------------------------------------------+
    public partial class CParticula : PictureBox
    {

        // +------------------------------------------------------------------+
        // | Atributos                                                        |   
        // +------------------------------------------------------------------+

        // Atributos de la base (coordenadas)
        private int XBase;
        private int YBase;

        // Atributos del área de vuelo (contendor)
        private Control AreaVuelo;

        // Atributos de navegación
        private int Altura;
        private bool Norte;
        private bool Sur;
        private bool Este;
        private bool Oeste;
        private int Velocidad;

        // Atributos de control (particula)
        private bool Encendido;
        private bool RegresarABase;
        private ToolTip ToolTipNombre;

        // Atributos de ejecución (runtime)
        Thread Proceso;

        // +------------------------------------------------------------------+
        // | Constructor                                                      |   
        // +------------------------------------------------------------------+
        public CParticula(int XBase, int YBase, Control AreaVuelo) : base()
        {
            InitializeComponent();

            int Contador;

            Contador = 0;

            // Inicializa atributos de la base
            this.XBase = XBase;
            this.YBase = YBase;

            // Inicializa atributos del área de vuelo
            this.AreaVuelo = AreaVuelo;
            AreaVuelo.Controls.Add(this);

            // Inicializa atributos de navegación
            Altura = 0;
            Norte = false;
            Sur = true;
            Este = true;
            Oeste = false;
            Velocidad = 0;

            // Incializa atributos de control.
            Encendido = false;
            RegresarABase = false;
            ToolTipNombre = new ToolTip();
            Contador++;

            // Incializa atributos de ejecución.
            Proceso = null;

            // Construye el dron.
            Location = new Point(this.XBase, this.YBase);
            BackColor = Color.White;
            Name = "Particula";
            Size = new Size(32, 32);
            BringToFront();

            // Asigna método clic
            Click += EnClic;

            // Asignación de atributos de la particula
            ToolTipNombre.AutoPopDelay = 5000;
            ToolTipNombre.InitialDelay = 1000;
            ToolTipNombre.ReshowDelay = 500;
            ToolTipNombre.ShowAlways = true;

            // Añadir tooltip a la particula
            ToolTipNombre.SetToolTip(this, $"{Contador}");

        }


        // +------------------------------------------------------------------+
        // | Comienza el funcionamiento del dron                              |   
        // +------------------------------------------------------------------+
        public void Enciende()
        {
            Thread Proceso;
            Color ColorAleatorio;

            // Particula se colorea.
            ColorAleatorio = ColorUtils.GetRandomColor();

            // Enciende el dron después de un segundo.

            Proceso = new Thread(() =>
            {
                Thread.Sleep(1000);
                BackColor = ColorAleatorio;
                Encendido = true;
            });

            Proceso.Start();

            // Incrementar contador de instancias
        }

        // +------------------------------------------------------------------+
        // | Cambia el rumbo de la particula                                  |   
        // +------------------------------------------------------------------+
        public void Rumbo(bool Norte, bool Sur, bool Este, bool Oeste)
        {
            this.Norte = Norte;
            this.Sur = Sur;
            this.Este = Este;
            this.Oeste = Oeste;
        }

        // +------------------------------------------------------------------+
        // | Eleva la particula                                               |   
        // +------------------------------------------------------------------+
        public void Eleva(int Altura)
        {
            this.Altura = Altura;
        }

        // +------------------------------------------------------------------+
        // | Desplaza la particula a una velocidad determinada                |   
        // +------------------------------------------------------------------+
        public void Desplaza(int Velocidad)
        {
            // Posición inicial
            int X;
            int Y;

            this.Velocidad = Velocidad;

            // Desplaza la particula por tiempo indefinido
            // NOTA: Se utiliza un hilo de ejecución, el cual deberá
            // ser  finalizazdo al término del programa.

            Proceso = new Thread(() =>
            {
                while (true)
                {
                    if (Encendido)
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

                            if (!RegresarABase)
                            {
                                this.Este = true;
                            }

                        }

                        if (Y <= 0)
                        {
                            this.Norte = false;

                            if (!RegresarABase)
                            {
                                this.Sur = true;
                            }

                        }

                        if (X >= AreaVuelo.Width - Width)
                        {
                            this.Oeste = true;
                            this.Este = false;
                        }

                        if (Y >= AreaVuelo.Height - Height)
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

            Proceso.Start();
        }

        // +------------------------------------------------------------------+
        // | Termina la partícula                                             |   
        // +------------------------------------------------------------------+
        public void Termina()
        {
            Proceso.Abort();
        }

        // +------------------------------------------------------------------+
        // | Deshabilita las operaciones de la particula                      |   
        // +------------------------------------------------------------------+
        public bool Apagar()
        {

            if (Altura == 0)
            {
                return true;
            }

            return false;

        }

        // +------------------------------------------------------------------+
        // | Ejecuta cuando haces clic                                        |   
        // +------------------------------------------------------------------+
        private void EnClic(object sender, EventArgs e)
        {

            if (Location.X <= 0 && Location.Y <= 0)
            {
                RegresarABase = false;
            }
            else
            {
                Norte = true;
                Sur = false;
                Este = false;
                Oeste = true;

                RegresarABase = true;

            }

        }
    }
}
