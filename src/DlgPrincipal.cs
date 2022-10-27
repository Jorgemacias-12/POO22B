using POO22B_MZJA.src.Clases;
using POO22B_MZJA.src.Clases.Practica_4;
using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        private List<CParticula> Particulas;
        private List<CSerVivo> SeresVivos;
        private Oxigeno OxigenoEnAmbiente;
        private int LimiteInanicion;
        private int PreviusWidth;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public DlgPrincipal()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Particulas = new List<CParticula>();

            SeresVivos = new List<CSerVivo>();

            OxigenoEnAmbiente = new Oxigeno(1500);

            LimiteInanicion = 3000;

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }

        // +------------------------------------------------------------------+
        // |  Cargar recursos del proyecto                                    |
        // +------------------------------------------------------------------+
        private void DlgPrincipal_Load(object sender, EventArgs e)
        {
            // UI Styles
            //PnlNavPractices
            //UI.PaintBorder(PnlNavPractices, ColorUtils.GetColor("#505050"), 1);
            // TODO: implement this in the Component code :D
            PreviusWidth = PnlSidebar.Width;
        }

        // +------------------------------------------------------------------+
        // | Pruebas de diagonales en sesión NC8.                             |
        // +------------------------------------------------------------------+
        private void FBtnPD_Click(object sender, EventArgs e)
        {
            CParticula Particula;

            Particula = new CParticula(10, 10, PnlP2Container);
            Particula.Enciende();
            Particula.Eleva(10);
            Particula.Desplaza(1);

            Particulas.Add(Particula);

        }

        // +------------------------------------------------------------------+
        // |  Diálogo cerrándose.                                             |
        // +------------------------------------------------------------------+
        private void DlgPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (CParticula Particula in Particulas)
            {
                Particula.Termina();
            }
        }

        private void FBtnPY_Click(object sender, EventArgs e)
        {
            Thread HiloPruebas;

            HiloPruebas = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    CParticula Particula;

                    Particula = new CParticula(10, 10, PnlP2Container);
                    Particula.Enciende();
                    Particula.Eleva(10);
                    Particula.Desplaza(1);

                    Particulas.Add(Particula);
                }
            });

            HiloPruebas.Start();

        }

        private void FBtnP2PX_Click(object sender, EventArgs e)
        {
            new DlgMonitorParticula(Particulas).Show();
        }

        private void FBtnP4SerVivo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clase abstracta, no puede instanciarse", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FBtnGVegetal_Click(object sender, EventArgs e)
        {
            CVegetal Vegetal;

            Vegetal = new CVegetal(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente.CapacidadMaxima, true, LimiteInanicion);
            Vegetal.Nacer();
        }

        private void FBtnGAnimal_Click(object sender, EventArgs e)
        {
            CAnimal Animal;

            Animal = new CAnimal(PnlP4AreaAmbiental, 10, 10, OxigenoEnAmbiente.CapacidadMaxima, true, LimiteInanicion);
            Animal.Nacer();
            Animal.Desplazar(1);
        }

        private void FBtnPersona_Click(object sender, EventArgs e)
        {
            CPersona Persona;

            Persona = new CPersona(PnlP4AreaAmbiental, 10, 10, OxigenoEnAmbiente.CapacidadMaxima, true, LimiteInanicion);

            Persona.Nacer();
            Persona.Desplazar(1);

        }

        private void PnlNavPractices_Paint(object sender, PaintEventArgs e)
        {
            Control Component;
            Rectangle ComponentRect;
            ButtonBorderStyle BorderStyle;
            Color BorderColor;
            int BorderSize;

            Component = sender as Panel;

            ComponentRect = new Rectangle(new Point(0, 0), Component.Size);

            BorderStyle = ButtonBorderStyle.Solid;

            BorderColor = ColorUtils.GetColor("#6457A6");
            BorderSize = 2;

            if (WindowState == FormWindowState.Maximized)
            {
                ControlPaint.DrawBorder(Component.CreateGraphics(),
                                    ComponentRect,
                                    BorderColor,
                                    0, // left
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize, // top
                                    BorderStyle,
                                    BorderColor,
                                    BorderSize, // right
                                    BorderStyle,
                                    BorderColor,
                                    0, // bottom
                                    BorderStyle);
            }

        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            if (TpbPractices.SelectedTab != TpbPractices.TabPages["TbpPractice4"])
            {
                return;
            }


            PnlP4AreaAmbiental.Update();

        }

        private void FBtnGHongo_Click(object sender, EventArgs e)
        {
            CHongo Hongo;

            Hongo = new CHongo(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente.CapacidadMaxima, true, LimiteInanicion);
            Hongo.Nacer();
        }

        private void FBtnGProtoctista_Click(object sender, EventArgs e)
        {
            CProtoctista Alga;

            Alga = new CProtoctista(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente.ValorActual, true, LimiteInanicion);
            Alga.Nacer();
        }

        private void FBtnGBacteria_Click(object sender, EventArgs e)
        {
            CBacteria Bacteria;

            Bacteria = new CBacteria(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente.ValorActual, true, LimiteInanicion);
            Bacteria.Nacer();
            Bacteria.Desplazar(1);
        }

        private void TbxLimiteInanicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void TbxLimiteInanicion_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxLimiteInanicion.Text != String.Empty)
            {
                LimiteInanicion = Convert.ToInt32(TbxLimiteInanicion.Text);
            }
        }

        private void FBtnSidebar_Click(object sender, EventArgs e)
        {
            Thread HideSideBar;               

            HideSideBar = new Thread(() =>
            {

                if (FBtnSidebar.IsActive)
                {
                    PnlSidebar.Width = 0;
                }

                if (!FBtnSidebar.IsActive)
                {
                    PnlSidebar.Width = PreviusWidth;
                }

            });

            HideSideBar.Start();
        }
    }
}
