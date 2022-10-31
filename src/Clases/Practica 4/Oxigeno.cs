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
        private int _ValorActual;

        public int CapacidadMaxima
        {
            get; set;
        }

        public int ValorActual
        {
            get
            {
                return this._ValorActual;
            }
            set
            {
                if (value < 0) return;
                
                this._ValorActual = value;
                if (OxigenoConsumido != null)
                {
                    OxigenoConsumido.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public int PorcentajeOxigeno
        {
            get
            {
                try
                {
                    int Porcentaje = ValorActual * PORCENTAJE_MAXIMO / CapacidadMaxima;
                    return Porcentaje >= 100 ? 100 : Porcentaje;
                }
                catch (DivideByZeroException ex) { }
                
                return 0;
            }
        }

        public Oxigeno(int CapacidadMaxima)
        {
            this.CapacidadMaxima = CapacidadMaxima;
            ValorActual = CapacidadMaxima;
        }

        public override string ToString()
        {
            return $"%{PorcentajeOxigeno}";
        }

    }
}
