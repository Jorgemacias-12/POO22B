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
    // |  Clase que representa un Hongo                                   |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CHongo : CSerVivo
    {
        private List<Image> Hongos;

        public CHongo(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, 
                      int NivelOxigeno, bool HaySol, int LimiteInanicion) : 
               base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
            Hongos = new List<Image>()
            {
                Resources.mc_mushroom_red,
                Resources.mc_mushroom_brown,
                Resources.gi_hongo,
                Resources.gi_hongo_estelar,
                Resources.gi_hongo_rukkhashava
            };
        }

        public override void EnClic(object sender, EventArgs e)
        { 

        }

        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 4);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Hongos[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;

        }
    }
}
