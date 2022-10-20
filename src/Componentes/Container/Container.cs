using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Componentes.Container
{
    public class Container : Panel
    {
        private readonly Rectangle ComponentRect;

        public bool IsDoubleBuffered
        {
            get; set;
        }

        public Color BorderColor
        {
            get; set;
        }

        public bool PaintBorder
        {
            get; set;
        }

        public Border Border;

        public Container()
        {
            DoubleBuffered = IsDoubleBuffered;

            ComponentRect = new Rectangle( new Point(0,0),
                                           Size);
            BorderStyle = BorderStyle.FixedSingle;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, ButtonBorderStyle.Solid);

        }

    }
}
