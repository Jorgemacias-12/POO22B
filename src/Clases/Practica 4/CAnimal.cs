using POO22B_MZJA.Properties;
using POO22B_MZJA.src.Componentes.CMessageBox;
using POO22B_MZJA.src.Utils.Rand;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO22B_MZJA.src.Clases.Practica_4
{
    // +------------------------------------------------------------------+
    // |  Clase que representa un ser Animal                              |
    // |  MZJA 29/09/22.                                                  |
    // +------------------------------------------------------------------+
    public class CAnimal : CSerVivo
    {

        // +------------------------------------------------------------------+
        // |  Atributos                                                       |
        // +------------------------------------------------------------------+
        private List<Image> Frutos;
        private List<string> NombreFrutos;

        // +------------------------------------------------------------------+
        // |  Constructor                                                     |
        // +------------------------------------------------------------------+
        public CAnimal(Control AreaDesplazamiento, int XNacimiento, int YNacimiento,
                       Oxigeno Oxigeno, bool HaySol, int LimiteInanicion) :
               base(AreaDesplazamiento, XNacimiento, YNacimiento, Oxigeno, HaySol, LimiteInanicion)
        {
            Frutos = new List<Image>()
            {
                Resources.mc_fruit_apple,
                Resources.mc_fruit_blueberry,
                Resources.mc_fruit_gapple,
                Resources.mc_fruit_orange,
                Resources.mc_fruit_sweet_berries
            };

            NombreFrutos = new List<string>()
            {
                "Apple",
                "Blueberry",
                "Green Apple",
                "Orange",
                "Sweet Berries"
            };
        }

        public override void Comer()
        {
            ProcesoComer = new Thread(() =>
            {
                int ComidaEncontrada;

                ComidaEncontrada = 0;

                int Indice;

                Indice = RandomIC.Next(0, Frutos.Count - 1);

                if (LimiteInanicion > 1000)
                {
                    ComidaEncontrada = Rand.Next(100, (int)(LimiteInanicion * 0.10));
                }

                if (LimiteInanicion < 1000)
                {
                    ComidaEncontrada = Rand.Next(0, (int)(LimiteInanicion * 0.10f));
                }

                // Prevenir cualquier bug extraño
                // con valores menores a 0
                if (ComidaEncontrada == 0)
                {
                    MessageBox.Show("No encontre comida :C", "Familia hoy no se come :C");
                    return;
                }

                // Almacenar la comida encontrada
                ComidaIngerida += ComidaEncontrada;

                // "Comer"
                Hambre -= ComidaEncontrada;

                // Mostrar información acerca de la operación
                new DialogFrame().ShowMessage($"Operación en {Name}", $"He comido {NombreFrutos[Indice]}, que tiene {ComidaEncontrada} puntos de comida, y mi hambre es de {Hambre} puntos, Comida ingerida: {ComidaIngerida} ", Frutos[Indice]);

            });

            ProcesoComer.Start();
        }


        // +------------------------------------------------------------------+
        // |  Sobrecarga del método Desplazar.                                |
        // +------------------------------------------------------------------+
        public override void Desplazar(int Velocidad)
        {
            base.Desplazar(Velocidad);
            base.Cansarse();
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el método de la clase padre.                      |
        // +------------------------------------------------------------------+
        public override void EnClic(object sender, EventArgs e)
        {
            if (IsDisposed) return; // Evitar excepcion de objeto disposed

            Comer();
        }

        // +------------------------------------------------------------------+
        // |  Sobreescribir el funcionamiento de nacer de la clase padre      |
        // |  para incluir generación de tipo.                                |
        // +------------------------------------------------------------------+
        public override void Nacer()
        {
            base.Nacer();
            Oxigeno.ValorActual -= 50;
            GenerarTipo();
        }

        // +------------------------------------------------------------------+
        // |  Generar el tipo según la clase Animal.                          | 
        // +------------------------------------------------------------------+
        protected override void GenerarTipo()
        {
            int IndiceGenerado;
            List<Image> Animales;
            List<string> Nombres;

            Animales = new List<Image>()
            {
                Resources.mc_axolotl,
                Resources.mc_cat,
                Resources.mc_chicken,
                Resources.mc_cow,
                Resources.mc_fox,
                Resources.mc_turtle
            };

            Nombres = new List<string>
            {
                "Ajolote",
                "Gato",
                "Pollo",
                "Vaca",
                "Zorro",
                "Tortuga"
            };


            IndiceGenerado = RandomIC.Next(0, 5);

            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;

            BackgroundImage = Animales[IndiceGenerado];
            BackgroundImageLayout = ImageLayout.Stretch;

            Name = Nombres[IndiceGenerado];
        }



    }
}
