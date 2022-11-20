using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    // +------------------------------------------------------------------+
    // |  Clase encargada del manejo de las figuras                       |
    // |  MZJA 15/11/22.                                                  |
    // +------------------------------------------------------------------+
    public class CFigureManager
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private CCuadrado Cuadrado;
        private CTriangulo Triangulo;
        private CCirculo Circulo;
        private Control Container;
        private DlgPropiedadesFigura FigureProps;
        public DialogResult DResult;
        private enum Figura
        {
            Cuadrado = 0,
            Circulo = 1,
            Triangulo = 2,
            Rectangulo = 3
        }

        public int FiguraAlto;
        public int FiguraAncho;
        public int PerimetroSize;
        public int Base;
        public int Altura;
        public int Radio;
        public Color Perimetro;
        public Color Area;

        //private CCirculo Circulo; // Reimplement class
        private int _TipoFigura;
        public int TipoFigura
        {
            get
            {
                return _TipoFigura;
            }

            set
            {
                // Establecer tipo de figura
                _TipoFigura = value;

                // Abrir diálogo de propiedades
                FigureProps = new DlgPropiedadesFigura(this);


                DResult = FigureProps.ShowDialog();

                if (DResult != DialogResult.OK)
                {
                    MessageBox.Show($"Necesitas llenar las propieadades para utilizar la figura {FigureProps.NombreFigura[TipoFigura]}",
                                    "¡Atención!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    return;
                }



                Debug.Print($"Variables {Container} {FiguraAlto}, {FiguraAncho}, {Area}, {Perimetro}, {PerimetroSize}");

                switch (_TipoFigura)
                {
                    case (int)Figura.Cuadrado:

                        FigureProps.ObtenerPropiedadesFigura(out FiguraAlto,
                                                     out FiguraAncho,
                                                     out Area,
                                                     out Perimetro,
                                                     out PerimetroSize);

                        Cuadrado = new CCuadrado(Container,
                                                           FiguraAncho,
                                                           FiguraAlto,
                                                           Perimetro,
                                                           Area,
                                                           PerimetroSize);
                        Cuadrado.Inicializar();

                        break;

                    case (int)Figura.Circulo:

                        FigureProps.ObtenerPropiedadesFigura(out FiguraAlto,
                                                     out FiguraAncho,
                                                     out Area,
                                                     out Perimetro,
                                                     out PerimetroSize);

                        Circulo = new CCirculo(Container,
                                                         FiguraAncho,
                                                         FiguraAlto,
                                                         Perimetro,
                                                         Area,
                                                         PerimetroSize);
                        Circulo.Inicializar();

                        break;

                    case (int)Figura.Triangulo:

                        FigureProps.ObtenerPropiedadesFigura(out Base,
                                                             out Altura,
                                                             out PerimetroSize,
                                                             out Area,
                                                             out Perimetro);

                        Triangulo = new CTriangulo(Container,
                                                              Base,
                                                              Altura,
                                                              Perimetro,
                                                              Area,
                                                              PerimetroSize);

                        Triangulo.Inicializar();

                        break;

                    case (int)Figura.Rectangulo:

                        FigureProps.ObtenerPropiedadesFigura(out FiguraAlto,
                                                             out FiguraAncho,
                                                             out Area,
                                                             out Perimetro,
                                                             out PerimetroSize);

                        CCuadrado Rectangulo = new CCuadrado(Container,
                                                             FiguraAncho,
                                                             FiguraAlto,
                                                             Perimetro,
                                                             Area,
                                                             PerimetroSize);

                        Rectangulo.Inicializar();

                        break;
                }

            }
        }

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CFigureManager(Control Container)

        {
            this.Container = Container;
        }

    }
}
