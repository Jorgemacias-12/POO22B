using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un primate                                 |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CPrimate : CMammalia
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+


        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CPrimate(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {

        }

    }
}
