using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Clases
{
    // +------------------------------------------------------------------+
    // |  Clase que representa una persona.                               |
    // |  MZJA 30/08/22.                                                  |
    // +------------------------------------------------------------------+
    public class CPersona
    {
        // +------------------------------------------------------------------+
        // |  Atributo                                                        |
        // +------------------------------------------------------------------+

        private int Etnia;
        private string Nombre;
        private int Genero;
        private DateTime FechaNacimiento;
        private string Nacionalidad;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CPersona(int Genero, DateTime FechaNacimiento, string Nacionalidad)
        {
            this.Genero = Genero;
            this.FechaNacimiento = FechaNacimiento;
            this.Nacionalidad = Nacionalidad;

            Nombre = "";
            Etnia = 0;
        }

        // +------------------------------------------------------------------+
        // | Asigna el nombre de la persona                                   |
        // +------------------------------------------------------------------+
        public void SetNombre(string Nombre)
        {
            this.Nombre = Nombre;
        }

        // +------------------------------------------------------------------+
        // |  Obtiene el nombre de la persona                                 |
        // +------------------------------------------------------------------+
        public string GetNombre()
        {
            return Nombre;
        }


    }
}
