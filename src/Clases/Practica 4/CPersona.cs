using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una Persona                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CPersona : CHominidae
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Personas;
        private List<Stream> Audios;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CPersona(Control AreaDesplazamiento, int XNacimiento, int YNacimiento,
                        Oxigeno Oxigeno, bool HaySol, int LimiteInanicion) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
            // Lista de recursos
            Personas = new List<Image>()
            {
                Resources.mc_a_jorge,
                Resources.mc_a_notch,
                Resources.mc_a_ricardo,
                Resources.mc_a_shadoune,
                Resources.mc_a_steve
            };

            Audios = new List<Stream>()
            {
                Resources.Eso_es_el_mercado_amigo,
                Resources.Gus_sus,
                Resources.emoji_muriendo,
                Resources.Taco_Bell_Bong,
                Resources.spam_click
            };

        }

        // +------------------------------------------------------------------+
        // |  Acción de la persona                                            |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            if (IsDisposed) return;

            int indice;

            indice = RandomIC.Next(0, Audios.Count - 1);

            using (SoundPlayer player = new SoundPlayer(Audios[indice]))
            {
                player.Stream.Position = 0;
                player.Play();
            }
            
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el funcionamiento de nacer de la clase padre      |
        // |  para incluir generación de tipo.                                |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            Oxigeno.ValorActual -= 200;
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Persona.                         | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 4);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Personas[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
