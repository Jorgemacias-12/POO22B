using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    public class CHomoSapien : CHominidae
    {
        public CHomoSapien(Control AreaDesplazamiento, int XNacimiento, int YNacimiento, int NivelOxigeno, bool HaySol, int LimiteInanicion) : base(AreaDesplazamiento, XNacimiento, YNacimiento, NivelOxigeno, HaySol, LimiteInanicion)
        {
        }
    }
}
