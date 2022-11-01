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
                            Oxigeno Oxigeno, bool HaySol, int LimiteInanicion) :
                base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
            //// Incialización de lista de recurso para generar tipo
            Algas = new List<Image>()
            {
                Resources.mc_seagrass,
                Resources.mc_seagrass_2,
                Resources.img_alga,
                Resources.img_alga_2,
                Resources.img_alga_3,

            };
        }

        // +------------------------------------------------------------------+
        // |  Generar oxigeno para el ecosistema                              |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            int OxigenoGenerado;

            OxigenoGenerado = RandomIC.Next(0, (int)(Oxigeno.ValorActual * 0.10f));

            Oxigeno.ValorActual += OxigenoGenerado;

            if (Oxigeno.ValorActual > Oxigeno.CapacidadMaxima)
            {
                Oxigeno.CapacidadMaxima = Oxigeno.ValorActual;
            }

            MessageBox.Show($"He generado: {OxigenoGenerado} puntos de oxigeno, buen día");
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el funcionamiento de nacer de la clase padre      |
        // |  para incluir generación de tipo.                                |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            Oxigeno.ValorActual -= 10;
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Protoctista                      | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;

            IndiceGenerado = RandomIC.Next(0, 4);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Algas[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
