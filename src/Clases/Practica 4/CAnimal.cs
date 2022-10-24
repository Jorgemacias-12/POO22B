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
    public class CAnimal : CSerVivo
    {
        public CAnimal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, 
                       int NivelOxigeno, bool HaySol, int LimiteInanicion) : 
               base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
        }

        public override void Desplazar(int Velocidad)
        {
            base.Desplazar(Velocidad);
            base.Cansarse();
        }

        public override void EnClic(object sender, EventArgs e)
        {
            base.Comer();
        }

        public override void Nacer()
        {
            base.Nacer();
            GenerarTipo();
        }

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
