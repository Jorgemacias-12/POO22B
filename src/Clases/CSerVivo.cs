using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser vivo                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CSerVivo : UserControl
    {
        // TODO: implementar método de movimiento en clase Animal
        
        /*
         * 1 -> DlgPractica 4
         * 2 -> CSerVivo
         * 
         * Clase Animal
         * 
         */

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // Atributos de la base
        private int XNacimiento;
        private int YNacimiento;

        // Atributos del áre de desplazamiento
        private Control AreaDesplazamiento;

        private bool Norte;
        private bool Sur;
        private bool Este;
        private bool Oeste;
        private int Velocidad;

        // Atributos de control
        private bool Nace;
        private bool RegresarACasa;

        // Atributos de ejecución
        private Thread ProcesoVida;


        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo()
        {

        }

    }
}
