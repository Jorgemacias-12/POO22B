using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Componentes.CMessageBox
{
    public partial class DialogFrame : Form
    {

        public string Mensaje;
        public Image Imagen;

        public DialogFrame()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ShowMessage(string Caption,string Mensaje, Image Imagen)
        {
            this.Text = Caption;

            this.Mensaje = Mensaje;
            this.Imagen = Imagen;

            PbxIcon.BackgroundImage = Imagen;
            LblMensaje.Text = Mensaje;

            ShowDialog();
        }

        public void ShowMessage(string Caption, string Mensaje)
        {
            this.Text = Caption;
            this.Mensaje = Mensaje;

            ShowDialog();
        }

        public void ShowMessage(string Caption, string Mensaje, List<Image> Iconos, List<string> Nombres)
        {
            this.Text = Caption;
            this.Mensaje = Mensaje;

            int Indice;

            Indice = RandomIC.Next(0, Iconos.Count);

            PbxIcon.BackgroundImage = Iconos[Indice];
            LblMensaje.Text = $"{Mensaje}";

            ShowDialog();
        }

    }
}
