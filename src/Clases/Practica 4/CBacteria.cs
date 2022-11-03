using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
        public List<CSerVivo> SeresVivos
        {
            get; set;
        }

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CBacteria(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, Oxigeno Oxigeno,
                         bool HaySol, int LimiteInanicion, List<CSerVivo> SeresVivos) :
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

            // Obtener los seres vivos
            this.SeresVivos = SeresVivos;
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
            Infectar();
        }

        // +------------------------------------------------------------------+
        // |  La bacteria entra en un huesped, y procede a infectarla.        |
        // +------------------------------------------------------------------+
        public void Infectar()
        {
            if (SeresVivos.Count == 1)
            {
                MessageBox.Show("¡No hay personas que infectar!", "¡Familia hoy no se come :C", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            for (int i = 0; i < SeresVivos.Count; i++)
            {

                if (SeresVivos[i].GetType() == typeof(CPersona))
                {
                    MessageBox.Show("He infectado a persona");
                    SeresVivos[i].Morir();
                    
                    MessageBox.Show("Persona ha muerto");
                    SeresVivos.RemoveAt(i);

                    using (SoundPlayer player = new SoundPlayer(Resources.Taco_Bell_Bong))
                    {
                        player.Stream.Position = 0;
                        player.Play();
                    }

                    break;
                }

                if (SeresVivos[i] is CAnimal)
                {
                    MessageBox.Show("He infectado a animal");
                    SeresVivos[i].Morir();
                    
                    MessageBox.Show($"{SeresVivos[i].Name} ha muerto");
                    SeresVivos.RemoveAt(i);

                    break;
                }

            }

        }


        // +------------------------------------------------------------------+
        // |  La bacteria nace, incluye el método que genera el tipo          |
        // |  de bacteria de manera (pseudo) aleatoria.                       |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            Oxigeno.ValorActual -= 10;
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
