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

    public enum TypeOfTriangle
    {
        Right,
        Obtuse,
        Normal
    }

    public class CTriangulo : CFigura
    {
        TypeOfTriangle Type;
        public int Base;
        public int Altura;

        public CTriangulo(Control Container, int Ancho, int Alto, Color ColorPerimetro, Color ColorArea, int PerimetroSize) : base(Container, Ancho, Alto, ColorPerimetro, ColorArea, PerimetroSize)
        {
        }

        //public CTriangulo(Control Container,
        //                  Color FigureColor,
        //                  int FigureWidth,
        //                  int FigureHeight,
        //                  TypeOfTriangle Type) : base(Container,
        //                                            FigureColor,
        //                                            FigureWidth,
        //                                            FigureHeight)
        //{
        //    this.Base = FigureWidth;
        //    this.Altura = FigureHeight;
        //    this.Type = Type;
        //}

        public override int CalcularArea()
        {
            // Base * Altura / 2
            throw new NotImplementedException();
        }

        public override int CalcularPerimetro()
        {
            // Pitagoras padrino xD a^2 + b^2 con raiz cuadrada
            // Y sumar con base + altura
            throw new NotImplementedException();
        }

        private void CalcularPuntos(out PointF Vertice, out PointF Vertice2)
        {
            // Punto de vertice por defecto
            Vertice = new PointF(0, 0);
            Vertice2 = new PointF(0, 0);

            switch(Type)
            {
                case TypeOfTriangle.Normal:

                    Vertice.X = Coordenadas.X - Base;
                    Vertice.Y = (float)(Coordenadas.Y + (Base * Math.Sqrt(3)));

                    Vertice2.X = Coordenadas.X + Base;
                    Vertice2.Y = Coordenadas.Y + (float)(Base * Math.Sqrt(3));

                    break;

                case TypeOfTriangle.Obtuse:

                    Vertice.X = Coordenadas.X - Base;
                    Vertice.Y = Coordenadas.Y + Altura;

                    Vertice2.X = Coordenadas.X + Base;
                    Vertice2.Y = Coordenadas.Y + Altura;

                    break;
                
                case TypeOfTriangle.Right:

                    Vertice.X = Coordenadas.X;
                    Vertice.Y = (float)(Coordenadas.Y + (Base * Math.Sqrt(3)));

                    Vertice2.X = Coordenadas.X + Base;
                    Vertice2.Y = Coordenadas.Y + Base * 2;

                    break;

                default:
                    break;
            }


        }

        protected override void Dibujar()
        {
            // Dibujar triángulo
            using (Graphics graficos = Graphics.FromImage(Lienzo))
            {
                PointF Vertice;
                PointF Vertice2;

                CalcularPuntos(out Vertice, out Vertice2);

                graficos.FillPolygon(FigureBrush, new PointF[] { Coordenadas, Vertice, Vertice2 });
                graficos.SmoothingMode = SmoothingMode.HighQuality;

            }

            // Actualizar imagen
            Container.Invalidate();
        }
    }
}
