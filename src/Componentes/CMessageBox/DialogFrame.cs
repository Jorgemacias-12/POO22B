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
            this.Close();
            this.Dispose();
        }

        public void Show(string Caption,string Mensaje, Image Imagen)
        {
            this.Text = Caption;

            this.Mensaje = Mensaje;
            this.Imagen = Imagen;

            PbxIcon.BackgroundImage = Imagen;
            LblMensaje.Text = Mensaje;

        }

    }
}
