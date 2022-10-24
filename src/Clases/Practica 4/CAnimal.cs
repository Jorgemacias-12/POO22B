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
    // |  Clase que representa un ser vivo                                |
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
        public CAnimal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, 
                       int NivelOxigeno, bool HaySol, int LimiteInanicion) : 
               base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
        }

        // +------------------------------------------------------------------+
        // |  Sobrecarga del método Desplazar.                                |
        // +------------------------------------------------------------------+
        public override void Desplazar(int Velocidad)
        {
            base.Desplazar(Velocidad);
            base.Cansarse();
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el método de la clase padre.                      |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            base.Comer();
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
        // |  Generar el tipo según la clase Animal.                          | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;
            List<Image> Animales;

            Animales = new List<Image>()
            {
                Resources.mc_axolotl,
                Resources.mc_cat,
                Resources.mc_chicken,
                Resources.mc_cow,
                Resources.mc_fox,
                Resources.mc_turtle
            };

            IndiceGenerado = RandomIC.Next(0, 5);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Animales[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;

        }



    }
}
