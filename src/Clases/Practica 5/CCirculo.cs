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
    public class CCirculo : CFigura
    {
        public CCirculo(Control Container,
                        int Ancho,
                        int Alto,
                        Color ColorPerimetro,
                        Color ColorArea,
                        int PerimetroSize) : base(Container,
                                                  Ancho,
                                                  Alto,
                                                  ColorPerimetro,
                                                  ColorArea,
                                                  PerimetroSize)
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
            using (Graphics graficos = Graphics.FromImage(Lienzo))
            {
                graficos.SmoothingMode = SmoothingMode.AntiAlias;

                graficos.FillEllipse(FigureBrush, Coordenadas.X, Coordenadas.Y, Ancho, Alto);
                graficos.DrawEllipse(FigurePen, Coordenadas.X, Coordenadas.Y, Ancho, Alto);
            }

            Container.Invalidate();
        }
    }
}
