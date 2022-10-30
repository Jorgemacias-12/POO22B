using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una Bacteria                               |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CBacteria : CSerVivo
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Bacterias;
        private Random Rand;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CBacteria(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, Oxigeno Oxigeno,
                         bool HaySol, int LimiteInanicion) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
            // Inicializar lista con rescursos graficos
            Bacterias = new List<Image>()
            {
                Resources.mc_bacteria,
                Resources.mc_bacteria_2,
                Resources.img_bacteria,
                Resources.img_bacteria_2,
                Resources.img_bacteria_3,
            };

            //Inicializar random
            Rand = new Random();
        }


        // +------------------------------------------------------------------+
        // |  La bacteria se mueve de manera erratica en el ambiente.         |
        // +------------------------------------------------------------------+
        public override void Desplazar(int Velocidad)
        {
            // Variables para almacenar posición del ser vivo
            int X;
            int Y;

            this.Velocidad = Velocidad;

            ProcesoDesplazamiento = new Thread(() =>
            {
                while (!Muerto && Nacio)
                {
                    // Obtener posición actual del ser vivo
                    X = Location.X;
                    Y = Location.Y;

                    // Generar movimiento erratico
                    if (RandomIC.Next(0, 1) == 0)
                    {
                        Norte = true;
                        Sur = false;
                    }
                    else
                    {
                        Sur = true;
                        Norte = false;
                    }

                    if (RandomIC.Next(0, 1) == 0)
                    {
                        Este = true;
                        Oeste = false;
                    }
                    else
                    {
                        Oeste = true;
                        Este = false;
                    }

                    // Banderas para control de dirección
                    if (Norte)
                    {
                        Y -= 1;
                    }

                    if (Sur)
                    {
                        Y += 1;
                    }

                    if (Este)
                    {
                        X += 1;
                    }

                    if (Oeste)
                    {
                        X -= 1;
                    }

                    // Cambiar a nueva posición
                    Location = new Point(X, Y);
                    Thread.Sleep(this.Velocidad);
                }
            });

            ProcesoDesplazamiento.Start();
        }

        // +------------------------------------------------------------------+
        // |  LLeva a cabo el proceso de mitosis de la bacteria.              |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            MessageBox.Show(ToString());

            Mitosis();

        }

        // +------------------------------------------------------------------+
        // |  La bacteria hace mitosis, muere y nacen otras dos.              |
        // +------------------------------------------------------------------+
        private void Mitosis()
        {
            int XOffset;
            int YOffset;

            for (int i = 0; i < 2; i++)
            {
                GenerarPosicion(out XOffset, out YOffset);

                CBacteria Hijo;

                Hijo = new CBacteria(AreaDesplazamiento, XOffset, YOffset, Oxigeno, true, LimiteInanicion);
                Hijo.Nacer();
                Hijo.Desplazar(1);
            }

            Morir();
        }

        private void GenerarPosicion(out int XNacimiento, out int YNacimiento)
        {

            XNacimiento = RandomIC.Next(Location.X - Width, Location.X);
            YNacimiento = RandomIC.Next(Location.Y - Height, Location.Y);

        }

        // +------------------------------------------------------------------+
        // |  La bacteria nace, incluye el método que genera el tipo          |
        // |  de bacteria de manera (pseudo) aleatoria.                       |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Obtiene información acerca de la bacteria.                      |
        // +------------------------------------------------------------------+
        public override string ToString()
        {
            return $"{GetType()} - Atributos de control: [Nacio: {Nacio}, Regresar a casa:{RegresarACasa}, Muerto: {Muerto}, Crecido: {Crecido}]";
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Bacteria                         | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 4);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Bacterias[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
