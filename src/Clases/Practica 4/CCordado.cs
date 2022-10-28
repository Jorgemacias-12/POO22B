using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    public class CCordado : CSerVivo
    {
        public CCordado(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, Oxigeno Oxigeno, bool HaySol, int LimiteInanicion) : base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
        }

        public override void EnClic(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
