using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    public class CVegetal : CSerVivo
    {

        private Point CrecimientoMaximo;
        private readonly Random random;
        private bool Crecido;
        private int TasaCrecimiento;

        public CVegetal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
            base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
            random = new Random();
            // Eliminar borde
            FlatAppearance.BorderSize = 0;

            // Definir crecimiento máximo del vegetal
            CrecimientoMaximo.X = random.Next(1, 75);
            CrecimientoMaximo.X = random.Next(1, 75);

            Click += CVegetal_Click;

        }

        private void CVegetal_Click(object sender, EventArgs e)
        {

        }

        public void GenerarTipo()
        {
            int RandomIndex;

            List<Image> Vegetables = new List<Image>()
            {
                Resources.mc_acacia_tr,
                Resources.mc_birch_tr,
                Resources.mc_jungle_tr,
                Resources.mc_oak_tr,
                Resources.mc_spruce_tr,
            };

            RandomIndex = RandomIC.Next(0, 4);

            BackColor = Color.Transparent;
            BackgroundImage = Vegetables[RandomIndex];
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public override void Nacer(int LimiteInanicion, ref int NivelOxigeno)
        {
            Thread Proceso;
            int X;
            int Y;

            // Vegetal obtiene una imagen de vegetal aleatoria
            GenerarTipo();

            Proceso = new Thread(() =>
            {
                Nacio = true;

                // El vegetal tiene un punto aleatorio para nacer
                X = random.Next(10, AreaDesplazamiento.Width - CrecimientoMaximo.X - Width);
                Y = random.Next(10, AreaDesplazamiento.Height - CrecimientoMaximo.Y - Height);

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

            W = 0;
            H = 0;

            // Definir tasa de crecimiento
            TasaCrecimiento = random.Next(1, 5);

            ProcesoCrecimiento = new Thread(() =>
            {
                while (!Muerto)
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
                }
            });

            ProcesoCrecimiento.Start();

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g;
            GraphicsPath GPath;

            g = pe.Graphics;

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            GPath = new GraphicsPath();

            GPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);

            Region = new Region(GPath);

        }

    }
}
