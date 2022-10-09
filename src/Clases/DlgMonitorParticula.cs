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

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una pelota.                                |
    // |  MZJA 25/08/22.                                                  |
    // +------------------------------------------------------------------+
    public partial class DlgMonitorParticula : Form
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<CParticula> Particulas;
        private Thread Proceso;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public DlgMonitorParticula(List<CParticula> Particulas)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            this.Particulas = Particulas;

        }

        private void DlgMonitorParticula_Load(object sender, EventArgs e)
        {
            FBtnActualizar_Click(null, null);
        }

        private void FBtnActualizar_Click(object sender, EventArgs e)
        {
            DgvMonitor.Rows.Clear();
            for (int i = 0; i < Particulas.Count; i++)
            {
                //DgvMonitor.Rows.Add(new string[]
                //{
                //    Particulas[i].GetHashCode().ToString(), Particulas[i].Name,
                //    Particulas[i].Location.X.ToString(),
                //    Particulas[i].Location.Y.ToString()
                //}); ;
                DgvMonitor.Rows.Add();
                DgvMonitor.Rows[i].Cells[0].Value = Particulas[i].GetHashCode().ToString();
                DgvMonitor.Rows[i].Cells[1].Value = Particulas[i].Name;
                DgvMonitor.Rows[i].Cells[1].Style.BackColor = Particulas[i].BackColor;
                DgvMonitor.Rows[i].Cells[2].Value = Particulas[i].Location.X;
                DgvMonitor.Rows[i].Cells[3].Value = Particulas[i].Location.Y;
            }
            
            LblTotalParticulas.Text = $"En este momento hay {DgvMonitor.Rows.Count} particulas activas";
            DgvMonitor.Refresh();
        }

        private void FBtnAutomatico_Click(object sender, EventArgs e)
        {
            Proceso = new Thread(() =>
            {

                while (true)
                {
                    FBtnActualizar_Click(null, null);
                    Thread.Sleep(1000);
                }

            });

            Proceso.Start();

        }

        private void DlgMonitorParticula_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.Reset();

            Proceso.Abort();

            //foreach (CParticula Particula in Particulas)
            //{
            //    Particula.Termina();
            //}

        }

    }
}
