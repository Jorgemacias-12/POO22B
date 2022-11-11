using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    public class CCirculo : CFigura
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private int Radio;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CCirculo(Control Container, Color FigureColor, 
                        int FigureWidth, int FigureHeight, int Radio) : 
               base(Container, FigureColor, FigureWidth, FigureHeight)
        {
            if (Radio == 0)
            {
                Radio = 2;
            }

            this.Radio = Radio;
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
        // |  Dibuja un circulo                                               |
        // +------------------------------------------------------------------+
        protected override void DibujarFigura()
        {
            // Dibujar Circulo
            using (Graphics graficos = Graphics.FromImage(Lienzo))
            {
                graficos.FillEllipse(FigureBrush, Coordenadas.X,
                                     Coordenadas.Y, Width, Height);

            }

            // Actualizar imagen
            Container.Invalidate();
        }

    }
}
