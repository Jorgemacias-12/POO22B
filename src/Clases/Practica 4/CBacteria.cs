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
            base.Desplazar(Velocidad);
        }

        // +------------------------------------------------------------------+
        // |  Falta implementar funcionalidad                                 |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
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
