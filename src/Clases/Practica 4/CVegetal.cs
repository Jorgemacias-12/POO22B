using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Componentes.CMessageBox;
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
    // |  Clase que representa un Vegetal                                 |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CVegetal : CSerVivo
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Vegetales;
        private List<Image> Frutos;
        private List<string> NombreFrutos;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CVegetal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento,
                        int NivelOxigeno, bool HaySol, int LimiteInanicion) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
            // Inicializar recursos graficos
            Vegetales = new List<Image>()
            {
                Resources.mc_acacia_tr,
                Resources.mc_birch_tr,
                Resources.mc_jungle_tr,
                Resources.mc_oak_tr,
                Resources.mc_spruce_tr,
            };

            Frutos = new List<Image>()
            {
                Resources.mc_fruit_apple,
                Resources.mc_fruit_blueberry,
                Resources.mc_fruit_gapple,
                Resources.mc_fruit_orange,
                Resources.mc_fruit_sweet_berries
            };

            NombreFrutos = new List<string>()
            {
                "Apple",
                "Blueberry",
                "Green Apple",
                "Orange",
                "Sweet Berries"
            };
        }

        // +------------------------------------------------------------------+
        // |  Obtener una fruta del vegetal                                   |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 4);

            new DialogFrame().Show("¡Atención!",$"Se ha recogido la fruta: {NombreFrutos[IndiceGenerado]}", Frutos[IndiceGenerado]);
        }

        // +------------------------------------------------------------------+
        // |  Incluye el método que genera el tipo de vegetal de manera       |
        // |  aleatoria (pseudo)                                              |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Vegetal.                         | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;



            IndiceGenerado = RandomIC.Next(0, 4);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Vegetales[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
