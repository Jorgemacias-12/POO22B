using POO22B_MZJA.src.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un Animal                                  |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CAnimal : CSerVivo
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CAnimal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) : 
                       base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
            Text = "A";
        }

        public void Nacer()
        {
            Thread Proceso;
            Color ColorAnimal;

            // Ser vivo obtiene su color
            ColorAnimal = ColorUtils.GenerateColorShade("red");

            // El Vegetal nace después de un tiempo

            Proceso = new Thread(() =>
            {
                BackColor = ColorAnimal;
                Nacio = true;
            });

            Proceso.Start();
        }

    }
}
