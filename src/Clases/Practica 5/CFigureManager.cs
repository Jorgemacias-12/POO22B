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
        private Control Container;
        private CTriangulo Triangulo;
        private DlgPropiedadesFigura FigureProps;
        private DialogResult DResult;
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

            private set
            {
                // Establecer valor
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

                FigureProps.ObtenerPropiedadesFigura(out FiguraAlto, 
                                                     out FiguraAncho, 
                                                     out Area, 
                                                     out Perimetro, 
                                                     out PerimetroSize);

                Debug.Print($"Variables {FiguraAlto}, {FiguraAncho}, {Area}, {Perimetro}, {PerimetroSize}");

                switch(_TipoFigura)
                {
                    case (int)Figura.Cuadrado:
                        break;

                    case (int)Figura.Circulo:
                        break;

                    case (int)Figura.Triangulo:
                        break;

                    case (int)Figura.Rectangulo:
                        break;
                }

            }
        }

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CFigureManager(Control Container, int TipoFigura)

        {
            this.TipoFigura = TipoFigura;
            this.Container = Container;
        }

    }
}
