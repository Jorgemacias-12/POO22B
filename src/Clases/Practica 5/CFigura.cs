using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una figura                                 |
    // |  MZJA 01/09/22.                                                  |
    // +------------------------------------------------------------------+
    public abstract class CFigura
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        protected int Area;
        protected int Perimetro;
        protected Point Coordenadas;
        protected Color ColorFigura;
        protected Control Container;
        protected Brush FigureBrush;
        protected Pen FigurePen;
        protected Bitmap Lienzo;
        protected int Width;
        protected int Height;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CFigura(Control Container, Color FigureColor, int FigureWidth, int FigureHeight)
        {
            // Obtener contenedor principal
            this.Container = Container;

            // Obtener el tamaño de la figura
            this.Width = FigureWidth;
            this.Height = FigureHeight;

            // Guardar color 
            this.ColorFigura = FigureColor;

            // Añadir evento manejador de pintura para las figuras
            Container.Click += Container_Click;

            // Mantener imagen del contenedor ajustada
            Container.BackgroundImageLayout = ImageLayout.Stretch;

            // Añadir evento cuando se pinta
            Container.Paint += Container_Paint;

            // Inicializar lienzo virtual
            Lienzo = new Bitmap(Container.Width, Container.Height);

            // Incializar solid brush con color entrante
            FigureBrush = new SolidBrush(FigureColor);
        }

       

        // +------------------------------------------------------------------+
        // |  Calcula el área de la figura                                    |
        // +------------------------------------------------------------------+
        public abstract int CalcularArea();

        // +------------------------------------------------------------------+
        // |  Calcula el perimetro de la figura                               |
        // +------------------------------------------------------------------+
        public abstract int CalcularPerimetro();

        // +------------------------------------------------------------------+
        // |  Permite cambiar el color de la figura                           |
        // +------------------------------------------------------------------+
        public void CambiarColor(Color NuevoColor)
        {

        }

        protected virtual void DibujarFigura()
        {
            // Dibujar linea de ejemplo :D
            using(Graphics graficos = Graphics.FromImage(Lienzo))
            {
                Pen pencil = new Pen(ColorFigura, 10);
                graficos.DrawLine(pencil, Coordenadas, new Point(Width, Height));
            }

            Container.Invalidate();
        }

        // +------------------------------------------------------------------+
        // |  Dibujar la figura cuando se hace click                          |
        // +------------------------------------------------------------------+
        private void Container_Click(object sender, EventArgs e)
        {
            // Guardar coordenadas donde se hace el click
            Coordenadas = Container.PointToClient(Cursor.Position);

            // Dibujar figura
            DibujarFigura();

            MessageBox.Show(Coordenadas.ToString());
        }

        // +------------------------------------------------------------------+
        // |  Dibujar la figura en el lienzo                                  |
        // +------------------------------------------------------------------+
        private void Container_Paint(object sender, PaintEventArgs e)
        {
            Container.BackgroundImage = Lienzo;
        }

    }
}
