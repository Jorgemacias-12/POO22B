using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
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
        protected Color ColorPerimetro;
        protected Color ColorArea;
        protected Control Container;
        protected Brush FigureBrush;
        protected Pen FigurePen;
        protected Bitmap Lienzo;
        protected Graphics graficos;
        protected int Ancho;
        protected int Alto;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CFigura(Control Container,
                       int Ancho,
                       int Alto,
                       Color ColorPerimetro,
                       Color ColorArea,
                       int PerimetroSize)
        {

            if (Container is null)
            {
                Debug.Print("Contenedor nulo :C");
                return;
            }

            // Almacenar contenedor
            this.Container = Container;

            // Almacenar tamaño de la figura
            this.Ancho = Ancho;
            this.Alto = Alto;

            // Guardar colores para dibujar la figura
            this.ColorPerimetro = ColorPerimetro;
            this.ColorArea = ColorArea;

            // Mantener la imagen del contenedor ajustada
            Container.BackgroundImageLayout = ImageLayout.Stretch;

            // Inicializar brush y pen
            FigureBrush = new SolidBrush(ColorArea);
            FigurePen = new Pen(ColorPerimetro, PerimetroSize);
        }

        // +------------------------------------------------------------------+
        // |  Inicializar eventos y lienzo                                    | 
        // +------------------------------------------------------------------+
        public void Inicializar()
        {
            // Añadir eventos
            Container.Click += Container_Click;
            Container.Paint += Container_Paint;
            Container.Resize += Container_Resize;

            // Inicializar objetos de gráficos
            if (Lienzo is null) Lienzo = new Bitmap(Container.Width, Container.Height);
        }

        // +------------------------------------------------------------------+
        // |  Elimina los eventos de pintura y clic especificos               |
        // +------------------------------------------------------------------+
        public void Finalizar()
        {
            Container.Click -= Container_Click;
            Container.Paint -= Container_Paint;
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

        // Dibujar la figura
        protected virtual void Dibujar() { }

        // +------------------------------------------------------------------+
        // |  Dibujar la figura cuando se hace click                          |
        // +------------------------------------------------------------------+
        private void Container_Click(object sender, EventArgs e)
        {
            MouseEventArgs _ = (MouseEventArgs)e; // Eventos

            if (_.Button == MouseButtons.Left)
            {
                // Guardar coordenadas donde se hace el click
                Coordenadas = _.Location;

                Debug.Print($"{sender} - {Coordenadas} - {graficos}");
                
                // Dibujar la figura 
                Dibujar();
            }
        }

        // +------------------------------------------------------------------+
        // |  Dibujar la figura en el lienzo                                  |
        // +------------------------------------------------------------------+
        private void Container_Paint(object sender, PaintEventArgs e)
        {
            Container.BackgroundImage = Lienzo;
        }

        private void Container_Resize(object sender, EventArgs e)
        {
            Debug.Print("Se volvio a dibujar todo");
            
        }
    }
}
