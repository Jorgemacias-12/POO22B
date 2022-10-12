using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un error                                   |
    // |  MZJA 01/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CCliente
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private string CodigoCliente;
        private double Saldo;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CCliente(int Genero, DateTime FechaNacimiento, string Nacionalidad, string CodigoCliente)
            
        {
            this.CodigoCliente = CodigoCliente;
            Saldo = 0;
        }



    }
}
