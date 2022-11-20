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
            PerimetroSize = PerimeterSize;
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

            switch (TipoFigura)
            {
                // Cuadrado
                case 0:

                    LblRadio.Visible = false;
                    LblBase.Visible = false;
                    LblAltura.Visible = false;

                    TbxRadio.Visible = false;
                    TbxBase.Visible = false;
                    TbxAltura.Visible = false;

                    break;

                // Circulo
                case 1:

                    LblBase.Visible = false;
                    LblAltura.Visible = false;

                    TbxBase.Visible = false;
                    TbxAltura.Visible = false;

                    break;

                // Triangulo
                case 2:

                    LblFiguraAlto.Visible = false;
                    LblFiguraAncho.Visible = false;
                    LblRadio.Visible = false;

                    TbxAlto.Visible = false;
                    TbxAncho.Visible = false;
                    TbxRadio.Visible = false;
                        

                    break;

                // Rectangulo
                case 3:

                    LblRadio.Visible = false;
                    LblBase.Visible = false;
                    LblAltura.Visible = false;

                    TbxRadio.Visible = false;
                    TbxBase.Visible = false;
                    TbxAltura.Visible = false;

                    break;
            }

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

            Debug.Print($"Tipo de figura {NombreFigura[TipoFigura]}");

            if (TipoFigura == 0 &&
                (TbxAlto.Text == string.Empty ||
                TbxAncho.Text == string.Empty))
            {
                MessageBox.Show("Llene los campos de altura y anchura para continuar",
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

            // Validación datos de Circulo

            if (TipoFigura == 1 && 
                TbxRadio.Text == string.Empty)
            {
                MessageBox.Show("El radio no puede ser 0 o no existente, introduzca un valor válido.",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (Area == Color.Empty ||
                Area == Color.White)
            {
                MessageBox.Show("Eliga un color valido para el área de la figura",
                                "¡Atención!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                return;
            }

            if (Perimetro == Color.Empty ||
                Perimetro == Color.White)
            {
                MessageBox.Show("Eliga un color valido para el perimetro de la figura",
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

            TbxAncho.Text = TipoFigura == 3 ? $"{FiguraAlto * 3}" : $"{FiguraAlto}";

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

            TbxAlto.Text = TipoFigura == 3 ? $"{FiguraAncho * 3}" : $"{FiguraAncho}";

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

        private void TbxRadio_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxRadio_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxRadio.Text != string.Empty)
            {
                Radio = Convert.ToInt32(TbxRadio.Text);
            }
        }

        private void TbxBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxBase.Text != string.Empty)
            {
                Base = Convert.ToInt32(TbxBase.Text);
            }
        }

        private void TbxAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            UI.ValidateTextBox(sender, e);
        }

        private void TbxAltura_KeyUp(object sender, KeyEventArgs e)
        {
            if (TbxAltura.Text != string.Empty)
            {
                Altura = Convert.ToInt32(TbxAltura.Text);
            }
        }
    }
}
