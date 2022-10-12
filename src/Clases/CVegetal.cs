using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
            CrecimientoMaximo.X = random.Next(1, 250);
            CrecimientoMaximo.X = random.Next(1, 150);

            Text = "V";
        }

        public new void Nacer()
        {
            Thread Proceso;
            Color ColorVegetal;
            int X;
            int Y;

            // Vegetal obtiene su color
            ColorVegetal = ColorUtils.GenerateColorShade("green");
            
            Proceso = new Thread(() =>
            {
                BackColor = ColorVegetal;
                Nacio = true;

                // El vegetal tiene un punto aleatorio para nacer
                X = random.Next(10, AreaDesplazamiento.Width - CrecimientoMaximo.X);
                Y = random.Next(10, AreaDesplazamiento.Height - CrecimientoMaximo.Y);

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
                while(!Muerto)
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
