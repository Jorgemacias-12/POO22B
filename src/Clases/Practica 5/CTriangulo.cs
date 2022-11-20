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
    public class CTriangulo : CFigura
    {

        public PointF Vertice;
        public PointF Vertice2;
        private int Base;
        private int Altura;

        public CTriangulo(Control Container,
                          int Base,
                          int Altura,
                          Color ColorPerimetro,
                          Color ColorArea,
                          int PerimetroSize) : base(Container,
                                                    Base,
                                                    Altura,
                                                    ColorPerimetro,
                                                    ColorArea,
                                                    PerimetroSize)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        public override int CalcularArea()
        {
            throw new NotImplementedException();
        }

        public override int CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        private void CalcularPuntos(out PointF Vertice, out PointF Vertice2)
        {
            // Inicializar puntos
            Vertice = new PointF(0, 0);
            Vertice2 = new PointF(0, 0);

            Vertice.X = Coordenadas.X - Base;
            Vertice.Y = (float)(Coordenadas.Y + (Altura * Math.Sqrt(3)));

            Vertice2.X = Coordenadas.X + Base;
            Vertice2.Y = Coordenadas.Y + (float)(Altura * Math.Sqrt(3));
        }

        protected override void Dibujar()
        {
            using (Graphics graficos = Graphics.FromImage(Lienzo))
            {
                graficos.SmoothingMode = SmoothingMode.AntiAlias;

                CalcularPuntos(out Vertice, out Vertice2);

                graficos.FillPolygon(FigureBrush, new PointF[] { Coordenadas, Vertice, Vertice2 });
                graficos.DrawPolygon(FigurePen, new PointF[] { Coordenadas, Vertice, Vertice2 });
            }

            Container.Invalidate();
        }
    }
}
