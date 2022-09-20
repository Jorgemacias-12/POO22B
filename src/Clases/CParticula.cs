using POO22B_MZJA.src.Utils;
using System.Drawing;
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
        private int XBase;
        private int YBase;
        private int Altura;
        public int Velocidad;
        private bool Norte;
        private bool Sur;
        private bool Este;
        private bool Oeste;
        private Control Base;

        // +------------------------------------------------------------------+
        // | Constructor                                                      |   
        // +------------------------------------------------------------------+
        public CParticula(int XBase, int YBase, Control Base) : base()
        {
            InitializeComponent();

            this.XBase = XBase;
            this.YBase = YBase;
            this.Base = Base;

            Altura = 0;
            Norte = false;
            Sur = true;
            Este = true;
            Oeste = false;
            Velocidad = 2;
            BackColor = Color.White;
            Size = new System.Drawing.Size(32, 32);

            Base.Controls.Add(this);
            this.BringToFront();

        }

        // +------------------------------------------------------------------+
        // | Comienza el funcionamiento del dron                              |   
        // +------------------------------------------------------------------+
        public void Enciende()
        {
            BackColor = ColorUtils.GetRandomColor();
            Location = new System.Drawing.Point(XBase, YBase);
        }

        // +------------------------------------------------------------------+
        // | Eleva la particula                                               |   
        // +------------------------------------------------------------------+
        public void Eleva(int Altura)
        {
            this.Altura = Altura;
        }

        // +------------------------------------------------------------------+
        // | Desplaza la particula cambiando rumbo y velocidad                |   
        // +------------------------------------------------------------------+
        public void Desplaza(bool Norte, bool Sur, bool Este, bool Oeste, int Velocidad)
        {
            this.Norte = Norte;
            this.Sur = Sur;
            this.Este = Este;
            this.Oeste = Oeste;
            this.Velocidad = Velocidad;
        }

        // +------------------------------------------------------------------+
        // | Cambiar rumbo de la particula                                    |   
        // +------------------------------------------------------------------+
        public void Desplaza()
        {

            // Posición inicial
            int X;
            int Y;

            X = this.Location.X;
            Y = this.Location.Y;

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

            if (X <= 0)
            {
                this.Oeste = false;
                this.Este = true;
            }

            if (Y <= 0)
            {
                this.Sur = true;
                this.Norte = false;
            }

            if (X >= Base.Width - 32) // 32 is offset;
            {
                this.Este = false;
                this.Oeste = true;
            }

            if (Y >= Base.Height - 32)
            {
                this.Sur = false;
                this.Norte = true;
            }


            // Actualización de posición
            Location = new System.Drawing.Point(X, Y);

        }

        // +------------------------------------------------------------------+
        // | Cambiar la velocidad de la particula                             |   
        // +------------------------------------------------------------------+
        public void Desplaza(int Velocidad)
        {
            this.Velocidad = Velocidad;
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

    }
}
