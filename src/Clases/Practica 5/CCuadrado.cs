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
    // |  Clase que representa un Cuadrado / Rectangulo                   |
    // |  MZJA 01/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CCuadrado : CFigura
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        // Heredados

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CCuadrado(Control Container, Color FigureColor, int FigureWidth,
                         int FigureHeight) : 
               base(Container, FigureColor, FigureWidth, FigureHeight)
        {

        }

        public override int CalcularArea()
        {
            throw new NotImplementedException();
        }

        public override int CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        // +------------------------------------------------------------------+
        // |  Dibuja un cuadrado / rectangulo                                 |
        // +------------------------------------------------------------------+
        protected override void DibujarFigura()
        {
            // Dibujar cuadrado
            using (Graphics graficos = Graphics.FromImage(Lienzo))
            {
                graficos.FillRectangle(FigureBrush, Coordenadas.X, 
                                       Coordenadas.Y, Width,Height);

            }

            // Actualizar imagen
            Container.Invalidate();
        }
    }
}
