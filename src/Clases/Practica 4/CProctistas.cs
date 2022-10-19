using POO22B_MZJA.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser vivo                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CProtoctista : CSerVivo
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private Random Rand;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CProtoctista(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
            base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
            Rand = new Random();
        }
        
        private void GenerarTipo()
        {
            List<Image> TipoAlgas = new List<Image>()
            {
                Resources.mc_seagrass,
                Resources.mc_seagrass_2
            };

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            BackgroundImage = TipoAlgas[new Random().Next(0, 1)];
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public override void Nacer(int LimiteInanicion, ref int NivelOxigeno)
        {
            Thread Proceso;

            if (NivelOxigeno < 0) return;

            NivelOxigeno -= 1;

            GenerarTipo();

            // El Proctista nace.

            Proceso = new Thread(() =>
            {
                int X;
                int Y;

                // Inicializar variables de vitalidad
                Nacio = true;
                Muerto = false;
                Hambre = 0;
                ComidaIngerida = 0;
                this.LimiteInanicion = LimiteInanicion;

                X = Rand.Next(1, AreaDesplazamiento.Width - Width);
                Y = Rand.Next(1, AreaDesplazamiento.Height - Height);

                Location = new Point(X, Y);

                // El ser vivo crece
                Crecer();

            });

            Proceso.Start();
            
        }

    }
}
