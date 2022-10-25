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

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CBacteria(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, int NivelOxigeno, 
                         bool HaySol, int LimiteInanicion) : 
               base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
            // Inicializar lista con rescursos graficos
            Bacterias = new List<Image>()
            {
                Resources.mc_bacteria,
                Resources.mc_bacteria_2
            };
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
                    if (RandomIC.Next(0,1) == 0)
                    {
                        Norte = true;
                        Sur = false;
                    }
                    else
                    {
                        Sur = true;
                        Norte = false;
                    }

                    if (RandomIC.Next(0,1) == 0)
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

                    // Evitar que el ser vivo salga del ecosistema

                    if (X <= 0)
                    {
                        this.Oeste = false;

                        if (!RegresarACasa)
                        {
                            this.Este = true;
                        }

                    }

                    // Cambiar a nueva posición
                    Location = new Point(X, Y);
                    Thread.Sleep(this.Velocidad);
                }
            });

            ProcesoDesplazamiento.Start();
        }

        // +------------------------------------------------------------------+
        // |  Falta implementar funcionalidad                                 |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            MessageBox.Show($"D: {Muerto} - N: {Nacio}");
        }

        // +------------------------------------------------------------------+
        // |  Incluye el método que genera el tipo de bacteria de manera      |
        // |  aleatoria (pseudo)                                              |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Bacteria                         | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 1);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Bacterias[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
