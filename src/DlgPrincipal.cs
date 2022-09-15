using POO22B_MZJA.src.Clases;
using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una pelota.                                |
    // |  MZJA 25/08/22.                                                  |
    // +------------------------------------------------------------------+

    public partial class DlgPrincipal : Form
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Thread> Procesos;
        private List<Image> Imagenes;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public DlgPrincipal()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Procesos = new List<Thread>();
            Imagenes = new List<Image>();

        }

        // +------------------------------------------------------------------+
        // |  Cargar recursos del proyecto                                    |
        // +------------------------------------------------------------------+
        private void DlgPrincipal_Load(object sender, EventArgs e)
        {
            Imagenes.Add(Properties.Resources.icecube_leftup);
            Imagenes.Add(Properties.Resources.icecube_left);
            Imagenes.Add(Properties.Resources.icecube_leftdown);
            Imagenes.Add(Properties.Resources.icecube_rightop);
            Imagenes.Add(Properties.Resources.Icecube_right);
            Imagenes.Add(Properties.Resources.icecube_rightdown);
        }

        // +------------------------------------------------------------------+
        // | Pruebas de diagonales en sesión NC8.                             |
        // +------------------------------------------------------------------+
        private void FBtnPD_Click(object sender, EventArgs e)
        {
            CParticula Particula;
            Thread Proceso;

            Particula = new CParticula(10,10, PnlP2Container)
            {
                Name = "Particle",
                Image = Properties.Resources.icecube,
            };

            Proceso = new Thread(() =>
            {

                bool RumboNorte = false;
                bool RumboSur = true;
                bool RumboEste = true;
                bool RumboOeste = false;

                int X;
                int Y;

                X = Particula.Location.X;
                Y = Particula.Location.Y;

                while (true)
                {

                    if (RumboNorte)
                    {
                        Y -= 1;
                    }

                    if (RumboSur)
                    {
                        Y += 1;
                    }

                    if (RumboEste)
                    {
                        X += 1;
                    }

                    if (RumboOeste)
                    {
                        X -= 1;
                    }

                    if (X <= 0)
                    {
                        RumboOeste = false;
                        RumboEste = true;
                    }

                    if (X >= PnlP2Container.Width - 32) // 32 is offset;
                    {
                        Particula.Image = Imagenes[0];
                        RumboEste = false;
                        RumboOeste = true;
                    }

                    if (Y >= PnlP2Container.Height - 32)
                    {
                        RumboSur = false;
                        RumboNorte = true;
                    }

                    if (Y <= 0)
                    {
                        RumboSur = true;
                        RumboNorte = false;
                    }

                    Thread.Sleep(2);

                    Particula.Location = new Point(X, Y);

                }
            });

            Proceso.Start();
            Procesos.Add(Proceso);

        }

        private void DlgPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Thread Proceso in Procesos)
            {
                Proceso.Abort();
            }
        }

        
    }
}
