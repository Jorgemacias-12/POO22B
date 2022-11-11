using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    public class CCuadrado : CFigura
    {
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

        protected override void DibujarFigura()
        {
            base.DibujarFigura();
        }
    }
}
