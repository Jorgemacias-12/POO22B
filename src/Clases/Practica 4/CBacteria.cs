using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    public class CBacteria : CSerVivo
    {
        private Random random = new Random();

        public CBacteria(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
            base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
        }

        protected override void GenerarTipo()
        {
            int GeneratedIndex;

            List<Image> Mushroom = new List<Image>()
            {
                Resources.mc_bacteria,
                Resources.mc_bacteria_2,
            };

            GeneratedIndex = RandomIC.Next(0, 1);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            BackgroundImage = Mushroom[GeneratedIndex];
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public override void Nacer(int LimiteInanicion, ref int NivelOxigeno)
        {
            Thread Proceso;
            int X;
            int Y;

            // Comprobar si hay suficiente oxigeno
            if (NivelOxigeno < 0 ||
                NivelOxigeno > 100)
            {
                // El ser vivo consume oxigeno al nacer
                NivelOxigeno -= 1;
            }

            // Vegetal obtiene una imagen de vegetal aleatoria
            GenerarTipo();

            Crecer();

            Proceso = new Thread(() =>
            {
                Nacio = true;

                // El vegetal tiene un punto aleatorio para nacer
                X = random.Next(10, AreaDesplazamiento.Width - Width);
                Y = random.Next(10, AreaDesplazamiento.Height - Height);

                // Aplicar la posición
                Location = new Point(X, Y);

            });

            Proceso.Start();
        }

        public override void Desplazar(int Velocidad)
        {
            // Variables de posición inicial
            int X;
            int Y;

            this.Velocidad = Velocidad;

            // Desplaza la particula por tiempo indefinido
            // NOTA: Se utiliza un hilo de ejecución, el cual deberá
            // ser  finalizazdo al término del programa.

            ProcesoVida = new Thread(() =>
            {
                while (!Muerto)
                {
                    if (Nacio)
                    {

                        // Posición inical.
                        X = Location.X;
                        Y = Location.Y;

                        // Calcula desplazamiento

                        if (random.Next(0, 2) == 0)
                        {
                            Norte = true;
                            Sur = false;
                        }
                        else
                        {
                            Norte = false;
                            Sur = true;
                        }

                        if (random.Next(0, 2) == 0)
                        {
                            Este = true;
                            Oeste = false;
                        }
                        else
                        {
                            Este = false;
                            Oeste = true;
                        }

                        if (Norte)
                        {
                            Y -= 1;
                        }

                        if (Sur)
                        {
                            Y += 1;
                        }

                        if (Este)
                        {
                            X += 1;
                        }

                        if (Oeste)
                        {
                            X -= 1;
                        }

                        // Posición final 
                        Location = new Point(X, Y);
                        Thread.Sleep(this.Velocidad);
                    }
                }
            });

            ProcesoVida.Start();
        }

    }
}
