using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un Animal                                  |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CAnimal : CSerVivo
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CAnimal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) : 
                       base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
        }

        private void GenerarTipo()
        {
            int GeneratedIndex;

            List<Image> Animales = new List<Image>()
            {
                Resources.mc_axolotl,
                Resources.mc_cat,
                Resources.mc_cow,
                Resources.mc_chicken,
                Resources.mc_fox,
                Resources.mc_turtle
            };

            GeneratedIndex = RandomIC.Next(0, 5);

            BackgroundImage = Animales[GeneratedIndex];
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public override void Nacer()
        {
            base.Nacer();

            Thread Proceso;

            // Ser vivo obtiene su color
            GenerarTipo();

            // El Vegetal nace después de un tiempo

            Proceso = new Thread(() =>
            {
                Nacio = true;
            });

            Proceso.Start();
        }

    }
}
