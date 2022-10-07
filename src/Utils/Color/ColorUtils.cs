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
            const int MIN = 100;

            Color ShadeColor;



            switch(ColorName)
            {
                case "green":
                    break;
                case "red":
                    break;
                case "blue":
                    break;
            }

            return Color.White;
        }

    }
}
