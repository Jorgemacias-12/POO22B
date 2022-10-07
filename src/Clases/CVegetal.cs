using POO22B_MZJA.src.Utils;
using POO22B_MZJA.src.Utils.Rng;
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
    public class CVegetal : CSerVivo
    {

        private Point CrecimientoMaximo;
        private Random random = new Random();
        private bool Crecido;
        private int TasaCrecimiento;

        public CVegetal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
            base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
        }

        public new void Nacer()
        {
            Thread Proceso;
            Color ColorAleatorio;
            int X;
            int Y;

            // Ser vivo obtiene su color
            ColorAleatorio = ColorUtils.GenerateColorShade("green");

            // El Vegetal nace después de un tiempo

            Proceso = new Thread(() =>
            {
                BackColor = ColorAleatorio;
                Nacio = true;

                // El vegetal escoge un punto aleatorio para nacer
                X = random.Next(10, AreaDesplazamiento.Width - Size.Width);
                Y = random.Next(10, AreaDesplazamiento.Height - Size.Height);

                // Aplicar la posición
                Location = new Point(X, Y);

            });

            Proceso.Start();
        }

        public override void Crecer()
        {
            Thread ProcesoCrecimiento;

            int W;
            int H;

            bool CrecimientoEquitativo;

            CrecimientoEquitativo = new RandomEx().NextBoolean();

            W = 0;
            H = 0;

            // Definir del crecimiento máximo del vegetal de forma aleatoria
            CrecimientoMaximo.X = random.Next(1, 150);
            CrecimientoMaximo.Y = random.Next(1, 150);

            // Definir tasa de crecimiento
            TasaCrecimiento = random.Next(1, 20);

            ProcesoCrecimiento = new Thread( () =>
            {
                while (!Crecido)
                {

                    Thread.Sleep(1000);

                    if (Width > CrecimientoMaximo.X &&
                        Height > CrecimientoMaximo.Y)
                    {
                        Crecido = true;
                    }



                    W += TasaCrecimiento;
                    H += TasaCrecimiento;

                    Width += W;
                    Height += H;

                }
            });

            ProcesoCrecimiento.Start();

        }

    }
}
