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

            Particula = new CParticula(10, 10, PnlP2Container)
            {
                Name = "Particle",
                Image = Properties.Resources.icecube,
            };

            Thread.Sleep(500);

            Refresh();

            Particula.Enciende();

            Thread.Sleep(500);

            Proceso = new Thread(() =>
            {

                while (true)
                {
                    Particula.Desplaza();

                    Thread.Sleep(2);

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
