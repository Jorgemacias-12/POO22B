using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +----------------------------------------------------------------------+
    // | Clase que representa una particula                                   |
    // | MZJA 08/09/2022                                                      |
    // +----------------------------------------------------------------------+
    public partial class CParticula : PictureBox
    {

        // +------------------------------------------------------------------+
        // | Atributos                                                        |   
        // +------------------------------------------------------------------+
        public int Velocidad;

        // +------------------------------------------------------------------+
        // | Constructor                                                      |   
        // +------------------------------------------------------------------+
        public CParticula(int velocidad) : base()
        {
            InitializeComponent();
            Velocidad = velocidad;
        }

    }
}
