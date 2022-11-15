using Microsoft.Win32;
using POO22B_MZJA.src.Clases;
using POO22B_MZJA.src.Clases.Practica_4;
using POO22B_MZJA.src.Clases.Practica_5;
using POO22B_MZJA.src.FToggleButton;
using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<CFigura> Figuras;
        private Oxigeno OxigenoEnAmbiente;
        private int LimiteInanicion;
        private int PreviusWidth;
        private int FiguraAncho;
        private int FiguraAlto;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public DlgPrincipal()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Particulas = new List<CParticula>();

            SeresVivos = new List<CSerVivo>();

            Figuras = new List<CFigura>();

            OxigenoEnAmbiente = new Oxigeno(3000);

            LimiteInanicion = 3000;

            LblOxygenIndicator.Text = $"Nivel de oxigeno: {OxigenoEnAmbiente}";
            PrgNivelOxigeno.Value = (int)OxigenoEnAmbiente.PorcentajeOxigeno;

            OxigenoEnAmbiente.OxigenoConsumido += OxigenoEnAmbiente_OxigenoConsumido;


        }

        // +------------------------------------------------------------------+
        // |  Actualizar el valor del oxigeno en tiempo real                  |
        // +------------------------------------------------------------------+
        private void OxigenoEnAmbiente_OxigenoConsumido(object sender, EventArgs e)
        {
            LblOxygenIndicator.Text = $"Nivel de oxigeno: {OxigenoEnAmbiente}";
            PrgNivelOxigeno.Value = (int)OxigenoEnAmbiente.PorcentajeOxigeno;
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

            // Inicializar valores practica 5
            FiguraAlto = 0;
            FiguraAncho = 0;
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
            CParticula Particula = new CParticula(10, 10, PnlP2Container);

            Particula.Enciende();
            Particula.Eleva(10);
            Particula.Desplaza(1);
            Particula.Rumbo(false, true, false, false);

            Particulas.Add(Particula);
        }

        private void FBtnP2PM_Click(object sender, EventArgs e)
        {
            new DlgMonitorParticula(Particulas).Show();
        }

        private void FBtnPX_Click(object sender, EventArgs e)
        {
            CParticula Particula = new CParticula(10, 10, PnlP2Container);

            Particula.Enciende();
            Particula.Eleva(10);
            Particula.Desplaza(1);
            Particula.Rumbo(false, false, true, false);

            Particulas.Add(Particula);
        }

        private void FBtnP4SerVivo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clase abstracta, no puede instanciarse", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FBtnGVegetal_Click(object sender, EventArgs e)
        {
            CVegetal Vegetal;

            Vegetal = new CVegetal(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion);
            Vegetal.Nacer();

            SeresVivos.Add(Vegetal);
        }

        private void FBtnGAnimal_Click(object sender, EventArgs e)
        {
            CAnimal Animal;

            Animal = new CAnimal(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion);
            Animal.Nacer();
            Animal.Desplazar(1);

            SeresVivos.Add(Animal);
        }

        private void FBtnPersona_Click(object sender, EventArgs e)
        {
            CPersona Persona;

            Persona = new CPersona(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion);

            Persona.Nacer();
            Persona.Desplazar(1);

            SeresVivos.Add(Persona);
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

            if (OxigenoEnAmbiente.ValorActual == 0)
            {
                foreach (CSerVivo ser_vivo in SeresVivos)
                {
                    ser_vivo.Morir();
                }
            }

            //TbxLimiteOxigeno.Text = $"{OxigenoEnAmbiente.ValorActual} - {OxigenoEnAmbiente.CapacidadMaxima}";

            //PnlP4AreaAmbiental.Update();

        }

        private void FBtnGHongo_Click(object sender, EventArgs e)
        {
            CHongo Hongo;

            Hongo = new CHongo(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion);
            Hongo.Nacer();

            SeresVivos.Add(Hongo);
        }

        private void FBtnGProtoctista_Click(object sender, EventArgs e)
        {
            CProtoctista Alga;

            Alga = new CProtoctista(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion);
            Alga.Nacer();

            SeresVivos.Add(Alga);
        }

        private void FBtnGBacteria_Click(object sender, EventArgs e)
        {
            CBacteria Bacteria;

            Bacteria = new CBacteria(PnlP4AreaAmbiental, 0, 0, OxigenoEnAmbiente, true, LimiteInanicion, SeresVivos);
            Bacteria.Nacer();
            Bacteria.Desplazar(1);

            SeresVivos.Add(Bacteria);
        }

        private void TbxLimiteInanicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(sender, e);
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

        private void ValidateField(object sender, KeyPressEventArgs e)
        {
            TextBox Input;

            Input = sender as TextBox;

            int value;

            int.TryParse(Input.Text, out value);

            if (value > int.MaxValue)
            {
                return;
            }

            Input.MaxLength = 9;

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

        private void BtnUpdateOxygenLimit_Click(object sender, EventArgs e)
        {
            if (TbxLimiteOxigeno.Text == "")
            {
                return;
            }

            OxigenoEnAmbiente.CapacidadMaxima = Convert.ToInt32(TbxLimiteOxigeno.Text);
        }

        private void FBtnOverflow_Click(object sender, EventArgs e)
        {
            if (FBtnOverflow.IsActive)
            {
                PnlP4AreaAmbiental.AutoScroll = false;
            }
            else
            {
                PnlP4AreaAmbiental.AutoScroll = true;
            }
        }

        private void Ejecutar(object sender)
        {
            FlatToggleButton target = sender as FlatToggleButton;

            for(int i = 0; i < PnlP5TopNav.Controls.Count; i++)
            {
                if (PnlP5TopNav.Controls[i] is FlatToggleButton)
                {
                    FlatToggleButton _ = (FlatToggleButton)PnlP5TopNav.Controls[i];

                    _.OverrideMethod = true;
                    _.IsActive = false;
                    _.BackColor = _.OldColor;

                }
            }

            target.IsActive = true;
            target.BackColor = target.ActiveColor;
        }

        private void PnlPerimeterColor_Click(object sender, EventArgs e)
        {
            PnlPerimeterColor.BackColor = ColorUtils.DialogColor();
        }

        private void PnlAreaColor_Click(object sender, EventArgs e)
        {
            PnlAreaColor.BackColor = ColorUtils.DialogColor();
        }

        private void TbxAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(sender, e);
        }

        private void TbxAncho_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxAncho.Text != string.Empty)
            {
                FiguraAncho = Convert.ToInt32(TbxAncho.Text);
            }
        }

        private void TbxAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateField(sender, e);
        }

        private void TbxAlto_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.Print($"{sender} - {e.KeyCode}");

            if (TbxAlto.Text != string.Empty)
            {
                FiguraAlto = Convert.ToInt32(TbxAlto.Text);
            }
        }

        private void CmbFiguras_SelectionChangeCommitted(object sender, EventArgs e)
        {

            // Checar variables de entrada
            if (FiguraAlto == 0 ||
                FiguraAncho == 0)
            {
                MessageBox.Show("Defina un ancho y un alto para la figura", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CmbFiguras.SelectedIndex = -1;

                return;
            }

            // Checar si se ha seleccionado un color
            if (PnlAreaColor.BackColor == Color.White ||
                PnlPerimeterColor.BackColor == Color.White)
            {
                MessageBox.Show("Seleccione dos colores para dar a la figura", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CmbFiguras.SelectedIndex = -1;

                return;
            }

            Debug.Print($"Valor {CmbFiguras.SelectedIndex} - {CmbFiguras.SelectedItem}");
        }
    }
}
