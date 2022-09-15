using POO22B_MZJA.src.Utils;
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

            BackColor = ColorUtils.GetRandomColor();
            Location = new System.Drawing.Point(XBase, YBase);
            Size = new System.Drawing.Size(32, 32);

            Base.Controls.Add(this);
            this.BringToFront();

        }

        // +------------------------------------------------------------------+
        // | Comienza el funcionamiento del dron     |   
        // +------------------------------------------------------------------+
        public void Enciende()
        {
            // TODO
        }

        // +------------------------------------------------------------------+
        // | Eleva la particula                                               |   
        // +------------------------------------------------------------------+
        public void Eleva(int Altura)
        {

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
        public void Desplaza(bool Norte, bool Sur, bool Este, bool Oeste)
        {
            this.Norte = Norte;
            this.Sur = Sur;
            this.Este = Este;
            this.Oeste = Oeste;
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
