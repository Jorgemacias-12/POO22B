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
        private const int PORCENTAJE_MAXIMO = 100;
        public event EventHandler OxigenoConsumido;
        private int PorcentajeOxigeno;

        public int CapacidadMaxima
        {
            get; set;
        }

        public int ValorActual
        {
            get
            {
                return ValorActual;
            }
            set
            {
                ValorActual = value;
                OxigenoConsumido.Invoke(this, EventArgs.Empty);
            }
        }

        //private Thread ProcesoOxigeno;
        //private bool Ejecutar;


        public Oxigeno(int CapacidadMaxima)
        {
            this.CapacidadMaxima = CapacidadMaxima;
            //Ejecutar = true;
            ValorActual = CapacidadMaxima;
            PorcentajeOxigeno = 0;
        }

        //public void CicloOxigeno()
        //{
        //    ProcesoOxigeno = new Thread(() =>
        //    {
        //        while(Ejecutar)
        //        {

        //        }

        //    });

        //    ProcesoOxigeno.Start();
        //}

        public override string ToString()
        {
            // Calcular porcentaje de oxigeno

            PorcentajeOxigeno = ValorActual * PORCENTAJE_MAXIMO / CapacidadMaxima;

            return $"%{PorcentajeOxigeno}";
        }

    }
}
