using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
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

        protected override void Cansarse()
        {
            base.Cansarse();
        }

        protected override void GenerarTipo()
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

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            BackgroundImage = Animales[GeneratedIndex];
            BackgroundImageLayout = ImageLayout.Stretch;
        }


        public override void Nacer(int LimiteInanicion, ref int NivelOxigeno)
        {
            Thread Proceso;

            // Comprobar si hay suficiente oxigeno
            if (NivelOxigeno < 0 ||
                NivelOxigeno > 100) return;

            // El ser vivo consume oxigeno al nacer
            NivelOxigeno -= 1;

            // Ser vivo obtiene su color
            GenerarTipo();

            // El Vegetal nace después de un tiempo

            Proceso = new Thread(() =>
            {
                Location = new Point(RandomIC.Next(1, AreaDesplazamiento.Width - Width),
                                     RandomIC.Next(1, AreaDesplazamiento.Height - Height));

                Crecer();

                Thread.Sleep(1000);
                Nacio = true;
            });

            Proceso.Start();
        }

    }
}
