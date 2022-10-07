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
    // |  Clase que representa un ser vivo                                |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CSerVivo : FButton.FlatButton
    {
        // TODO: implementar método de movimiento en clase Animal
        
        /*
         * 1 -> DlgPractica 4
         * 2 -> CSerVivo
         * 
         * Clase Animal
         * 
         */

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+

        // Atributos de la base
        private int XNacimiento;
        private int YNacimiento;

        // Atributos del áre de desplazamiento
        private Control AreaDesplazamiento;

        private bool Norte;
        private bool Sur;
        private bool Este;
        private bool Oeste;
        private int Velocidad;

        // Atributos de control
        public bool Nacio;
        private bool RegresarACasa;
        public bool Muerto;

        // Atributos de ejecución
        private Thread ProcesoVida;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CSerVivo(Control AreaDesplazamiento, int XNacimiento, int YNacimiento)
        {
            // Inicializa atributos de la base
            this.XNacimiento = XNacimiento;
            this.YNacimiento = YNacimiento;

            // Inicializa atributos del ecosistema
            this.AreaDesplazamiento = AreaDesplazamiento;
            this.AreaDesplazamiento.Controls.Add(this);

            // Inicializa atributos de navegación
            Norte = false;
            Sur = true;
            Este = true;
            Oeste = false;
            Velocidad = 0;

            // Incializa atributos de control.
            Nacio = false;
            RegresarACasa = false;
            Muerto = false;

            // Incializa atributos de ejecución.
            ProcesoVida = null;

            // Propiedades del Ser Vivo.
            Location = new Point(this.XNacimiento, this.YNacimiento);
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 1;
            BackColor = Color.White;
            Name = "Particula";
            Size = new Size(32, 32);
            BringToFront();

        }

        // +------------------------------------------------------------------+
        // | Proceso de crecimiento del ser vivo                              |   
        // +------------------------------------------------------------------+
        public virtual void Crecer() { }

        // +------------------------------------------------------------------+
        // | Comienza el proceso de nacimiento                                |   
        // +------------------------------------------------------------------+
        public void Nacer()
        {
            Thread Proceso;
            Color ColorAleatorio;

            // Particula se colorea.
            ColorAleatorio = ColorUtils.GetRandomColor();

            // Enciende el dron después de un segundo.

            Proceso = new Thread(() =>
            {
                Thread.Sleep(1500);
                BackColor = ColorAleatorio;
                Nacio = true;
            });

            Proceso.Start();
        }

        public void Desplazar(int Velocidad)
        {
            // Variables de posición inicial
            int X;
            int Y;

            this.Velocidad = Velocidad;

            // Desplaza la particula por tiempo indefinido
            // NOTA: Se utiliza un hilo de ejecución, el cual deberá
            // ser  finalizazdo al término del programa.

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

        protected override void Dispose(bool disposing)
        {
            Muerto = true;
            base.Dispose(disposing);
        }

    }
}
