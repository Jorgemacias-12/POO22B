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
    // |  Clase que representa una persona.                               |
    // |  MZJA 30/08/22.                                                  |
    // +------------------------------------------------------------------+
    public class CPersona : CHomoSapiens
    {
        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private Random random;


        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CPersona(Control AreaDesplazamiento, int XNacimiento, int YNacimiento) :
            base(AreaDesplazamiento, XNacimiento, YNacimiento)
        {
            //this.Genero = Genero;
            //this.FechaNacimiento = FechaNacimiento;
            //this.Nacionalidad = Nacionalidad;

            //Nombre = "";
            //Etnia = 0;

            // Inicializar random

            random = new Random();

        }

        public void Nacer()
        {
            Thread Proceso;
            Color ColorDePiel;
            int X;
            int Y;

            // Persona obtiene su color de piel
            ColorDePiel = ColorUtils.GetPersonColor();

            Proceso = new Thread(() =>
            {
                BackColor = ColorDePiel;
                Nacio = true;

                // El vegetal tiene un punto aleatorio para nacer
                X = random.Next(10, AreaDesplazamiento.Width);
                Y = random.Next(10, AreaDesplazamiento.Height);

                // Aplicar la posición
                Location = new Point(X, Y);

            });

            Proceso.Start();

        }

        public void Desplazar()
        {
            Thread ProcesoVida;

            int X;
            int Y;

            ProcesoVida = new Thread(() =>
            {
                while (!Muerto)
                {
                    if (Nacio)
                    {
                        // Posición inical.
                        X = Location.X;
                        Y = Location.Y;

                        // Calcula desplazamiento

                        if (Norte)
                        {
                            Y -= 1;
                        }

                        if (Sur)
                        {
                            Y += 1;
                        }

                        if (Este)
                        {
                            X += 1;
                        }

                        if (Oeste)
                        {
                            X -= 1;
                        }

                        // Determinar rebote

                        if (X <= 0)
                        {
                            this.Oeste = false;

                            if (!RegresarACasa)
                            {
                                this.Este = true;
                            }

                        }

                        if (Y <= 0)
                        {
                            this.Norte = false;

                            if (!RegresarACasa)
                            {
                                this.Sur = true;
                            }

                        }

                        if (X >= AreaDesplazamiento.Width - Width)
                        {
                            this.Oeste = true;
                            this.Este = false;
                        }

                        if (Y >= AreaDesplazamiento.Height - Height)
                        {
                            this.Norte = true;
                            this.Sur = false;
                        }

                        // Posición final 
                        Location = new Point(X, Y);
                        Thread.Sleep(this.Velocidad);
                    }
                }
            });

            ProcesoVida.Start();

        }


    }
}
