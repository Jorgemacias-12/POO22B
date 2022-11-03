using System;
using System.Collections.Generic;
using System.Threading;
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

        // +------------------------------------------------------------------+
        // |  Encender el double buffering (formulario)                       |
        // +------------------------------------------------------------------+
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_COMPOSITED = 0x02000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;  // WS_EX_COMPOSITED
                return cp;
            }
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
                DgvMonitor.Rows.Add(new string[]
                {
                    Particulas[i].GetHashCode().ToString(),
                    Particulas[i].Name,
                    Particulas[i].Location.X.ToString(),
                    Particulas[i].Location.Y.ToString()
                });

                DgvMonitor.Rows[i].Cells[1].Style.BackColor = Particulas[i].BackColor;
            }

            DgvMonitor.Refresh();

            LblTotalParticulas.Text = $"En este momento hay {DgvMonitor.Rows.Count} particulas activas";
            
        }

        private void FBtnAutomatico_Click(object sender, EventArgs e)
        {
            Proceso = new Thread(() =>
            {

                while (FBtnAutomatico.IsActive)
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


            if (Proceso is null)
            {
                return;
            }

            Proceso.Abort();
        }

    }
}
