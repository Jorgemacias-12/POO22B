
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    public class CCuadrado : CFigura
    {
        public CCuadrado(Control Container, 
                         int Ancho, 
                         int Alto, 
                         Color ColorPerimetro, 
                         Color ColorArea,
                         int PerimetroSize) : base(Container,
                                                 Ancho,
                                                 Alto,
                                                 ColorPerimetro,
                                                 ColorArea, PerimetroSize)
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

        protected override void Dibujar()
        {
            using (graficos = Graphics.FromImage(Lienzo))
            {
                // Dibuar el cuadrado
                graficos.FillRectangle(FigureBrush, // Dibujar Área
                                       Coordenadas.X,
                                       Coordenadas.Y,
                                       Ancho, Alto);

                graficos.DrawRectangle(FigurePen, // Dibujar Perimetro
                                       Coordenadas.X,
                                       Coordenadas.Y,
                                       Ancho, Alto);
            }

            Container.Invalidate();

        }
    }
}
