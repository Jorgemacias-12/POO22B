using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser Protoctista (Algas)                 |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CProtoctista : CSerVivo
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Algas;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CProtoctista(Control AreaDesplazamiento, int XNacimiento, int YNacimiento,
                            int NivelOxigeno, bool HaySol, int LimiteInanicion) :
                base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
            // Incialización de lista de recurso para generar tipo
            Algas = new List<Image>()
            {
                Resources.mc_seagrass,
                Resources.mc_seagrass_2
            };
        }

        // +------------------------------------------------------------------+
        // |  Generar oxigeno para el ecosistema                              |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el funcionamiento de nacer de la clase padre      |
        // |  para incluir generación de tipo.                                |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Protoctista                      | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 1);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Algas[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
