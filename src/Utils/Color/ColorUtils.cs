using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Utils
{
    public class ColorUtils
    {

        private static readonly Random Rand = new Random();
        private static readonly object syncObject = new object();

        public static Color GetRandomColor()
        {
            lock (syncObject)
            {
                return Color.FromArgb(Rand.Next(0, 256), Rand.Next(0, 256), Rand.Next(0, 256));
            }
        }


        public static Color GenerateColorShade(string ColorName)
        {
            const int MAX = 150;
            const int MIN = 20;
            const int OFFSET = 1;

            int generatedNumber;
            Color ShadeColor;

            // Fallback color
            ShadeColor = Color.White;

            generatedNumber = (int)Math.Floor(Rand.NextDouble() * (MAX - MIN + OFFSET)) + MIN;

            switch (ColorName)
            {
                case "red":
                    ShadeColor = Color.FromArgb(generatedNumber, 0, 0);
                    break;
                case "green":
                    ShadeColor = Color.FromArgb(0, generatedNumber, 0);
                    break;
                case "blue":
                    ShadeColor = Color.FromArgb(0, 0, generatedNumber);
                    break;
            }

            return ShadeColor;
        }

    }
}
