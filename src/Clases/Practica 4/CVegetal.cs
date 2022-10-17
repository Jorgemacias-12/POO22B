﻿using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ContentAlignment = System.Drawing.ContentAlignment;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

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

            Text = "V";

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

            };

            RandomIndex = new Random().Next();

            Image = Vegetables[RandomIndex];
            ImageAlign = ContentAlignment.MiddleCenter;
        }

        public new void Nacer()
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