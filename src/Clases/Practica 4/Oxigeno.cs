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
        private double _CapacidadMaxima;

        public double CapacidadMaxima
        {
            get
            {
                return _CapacidadMaxima;
            } 
            set
            {
                if (value < 0) return;

                _CapacidadMaxima = value;

                if (OxigenoConsumido != null)
                {
                    OxigenoConsumido.Invoke(this, EventArgs.Empty);
                }
            }
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

        public double PorcentajeOxigeno
        {
            get
            {
                try
                {
                    double Porcentaje = ValorActual * PORCENTAJE_MAXIMO / CapacidadMaxima;

                    Porcentaje = (Porcentaje * 10) / 10;

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
            return $"%{PorcentajeOxigeno.ToString("0.##")}";
        }

    }
}
