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
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Hongos;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CHongo(Control AreaDesplazamiento, int XNacimiento, int YNacimiento,
                      Oxigeno Oxigeno, bool HaySol, int LimiteInanicion) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
            // Lista de imagenes para generar el tipo de hongo
            Hongos = new List<Image>()
            {
                Resources.mc_mushroom_red,
                Resources.mc_mushroom_brown,
                Resources.gi_hongo,
                Resources.gi_hongo_estelar,
                Resources.gi_hongo_rukkhashava
            };
        }

        // +------------------------------------------------------------------+
        // |  Hacer algo en clic (por definir)                                |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            Reproducirse();
        }

        // +------------------------------------------------------------------+
        // |  El hongo se reproduce, y nace otro hongo.                       |
        // +------------------------------------------------------------------+
        private void Reproducirse()
        {
            if (IsDisposed) return;

            for (int i = 0; i < 2; i++)
            {
                CHongo Hijo;

                Hijo = new CHongo(AreaDesplazamiento, 0, 0, Oxigeno, true, LimiteInanicion);
                Hijo.Nacer();
            }

            Morir();
        }

        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el funcionamiento de nacer de la clase padre      |
        // |  para incluir generación de tipo.                                |
        // +------------------------------------------------------------------+
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
