using POO22B_MZJA.src.Utils;
using POO22B_MZJA.src.Utils.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_5
{
    public partial class DlgPropiedadesFigura : Form
    {
        public int TipoFigura
        {
            get; set;
        }

        private int FiguraAlto;
        private int FiguraAncho;
        private int Base;
        private int Altura;
        private int Radio;
        private int PerimeterSize;
        private Color Perimetro;
        private Color Area;

        // Contiene el nombre de las figuras disponibles
        public List<string> NombreFigura;

        public DlgPropiedadesFigura(CFigureManager Manager)
        {
            InitializeComponent();

            // Inicializar lista de valores
            NombreFigura = new List<string>
            {
                "Cuadrado",
                "Circulo",
                "Triangulo",
                "Rectangulo"
            };

            TipoFigura = Manager.TipoFigura;

        }

        public void ObtenerPropiedadesFigura(out int FiguraAlto,
                                             out int FiguraAncho,
                                             out Color Area,
                                             out Color Perimetro,
                                             out int PerimetroSize)
        {
            FiguraAlto = this.FiguraAlto;
            FiguraAncho = this.FiguraAncho;
            Area = this.Area;
            Perimetro = this.Perimetro;
            PerimetroSize = this.PerimeterSize;
        }

        public void ObtenerPropiedadesFigura(out int Base,
                                             out int Altura,
                                             out int PerimetroSize,
                                             out Color Area,
                                             out Color Perimetro)
        {
            Base = this.Base;
            Altura = this.Altura;
            PerimetroSize = this.PerimeterSize;
            Area = this.Area;
            Perimetro = this.Perimetro;
        }

        private void DlgPropiedadesFigura_Load(object sender, EventArgs e)
        {
            // Indicar figura seleccionada
            this.Text += $" - {NombreFigura[TipoFigura]}";

            // Mostrar tipo de figura en label
            LblOperation.Text += $" {NombreFigura[TipoFigura]}";

            // Cargar tipo de figura en caracteristicas
            LblFiguraAlto.Text += $" {NombreFigura[TipoFigura]}: ";
            LblFiguraAncho.Text += $" {NombreFigura[TipoFigura]}: ";
        }

        private void SetColorDialogForeground(object sender)
        {
            Button _ = sender as Button;

            _.ForeColor = ColorUtils.GetForegroundColor(_.BackColor);
        }

        private void BtnAColor_Click(object sender, EventArgs e)
        {
            Area = ColorUtils.DialogColor();

            BtnAColor.BackColor = Area;

            SetColorDialogForeground(sender);
        }

        private void BtnPColor_Click(object sender, EventArgs e)
        {
            Perimetro = ColorUtils.DialogColor();

            BtnPColor.BackColor = Perimetro;

            SetColorDialogForeground(sender);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar datos aquí

            if (TbxAlto.Text == string.Empty ||
                TbxAncho.Text == string.Empty)
            {
                MessageBox.Show("Llene los campos de altura y anchura para continuar",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (Area == Color.Empty ||
                Perimetro == Color.Empty)
            {
                MessageBox.Show("Eliga un color valido para el perímetro y el área de la figura",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (PerimeterSize == 0)
            {
                MessageBox.Show("Eliga un valor númerico entre 1 y N para el grosor del perímetro",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            // Estado del diálogo exitoso!
            DialogResult = DialogResult.OK;

            Close();
        }

        private void TbxAlto_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxAlto_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxAlto.Text != String.Empty)
            {
                FiguraAlto = Convert.ToInt32(TbxAlto.Text);
            }
        }

        private void TbxAncho_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxAncho_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxAncho.Text != String.Empty)
            {
                FiguraAncho = Convert.ToInt32(TbxAncho.Text);
            }
        }

        private void TbxPerimeterSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxPerimeterSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxPerimeterSize.Text != String.Empty)
            {
                PerimeterSize = Convert.ToInt32(TbxPerimeterSize.Text);
            }
        }
    }
}
