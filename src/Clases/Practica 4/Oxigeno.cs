using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    public class Oxigeno
    {

        public int CapacidadMaxima
        {
            get; set;
        }

        public int ValorActual
        {
            get; set;
        }

        private Thread ProcesoOxigeno;
        private bool Ejecutar;
       

        public Oxigeno(int CapacidadMaxima)
        {
            this.CapacidadMaxima = CapacidadMaxima;
            Ejecutar = true;
            ValorActual = CapacidadMaxima;
        }

        public void CicloOxigeno()
        {
            ProcesoOxigeno = new Thread(() =>
            {
                while(Ejecutar)
                {

                }
            });

            ProcesoOxigeno.Start();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
