using POO22B_MZJA.src.Clases;
using POO22B_MZJA.src.Utils;
using POO22B_MZJA.src.Utils.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private List<CParticula> Particulas;
        private List<CSerVivo> SeresVivos;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public DlgPrincipal()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            Particulas = new List<CParticula>();

            SeresVivos = new List<CSerVivo>();

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
            // Utilizar clase
            CSerVivo SerVivo;

            SerVivo = new CSerVivo(this.PnlP4AreaAmbiental, 10, 10);
            SerVivo.Nacer();
            SerVivo.Desplazar(1);

            SeresVivos.Add(SerVivo);

        }

        private void FBtnGVegetal_Click(object sender, EventArgs e)
        {
            CVegetal Vegetal;

            // Change constructor to rand pos
            Vegetal = new CVegetal(PnlP4AreaAmbiental, 10, 10);
            Vegetal.Nacer();
            Vegetal.Crecer();

        }

        private void FBtnGAnimal_Click(object sender, EventArgs e)
        {
            CAnimal Animal;

            Animal = new CAnimal(PnlP4AreaAmbiental, 10, 10);
            Animal.Nacer();
            Animal.Desplazar(1);
            SeresVivos.Add(Animal);
        }

        private void FBtnPersona_Click(object sender, EventArgs e)
        {
            CPersona Persona;

            Persona = new CPersona(PnlP4AreaAmbiental, PnlP4AreaAmbiental.Width / 2, PnlP4AreaAmbiental.Height / 2);
            Persona.Nacer();
            Persona.Desplazar(2);


            //while (SeresVivos.Count != 0 && TpbPractices.SelectedTab == TpbPractices.TabPages["TpgPractica4"])
            //{
            //    PnlP4AreaAmbiental.Refresh();
            //}

        }

        private void TpbPractices_SelectedIndexChanged(object sender, EventArgs e)
        {

            Debug.WriteLine($"{SeresVivos.Count} - {TpbPractices.SelectedTab}");

            while(SeresVivos.Count != 0 && 
                  TpbPractices.SelectedTab == TpbPractices.TabPages["TpgPractice4"])
            {
                PnlP4AreaAmbiental.Refresh();
            }
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
    }
}
