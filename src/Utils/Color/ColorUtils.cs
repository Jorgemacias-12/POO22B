﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
            int generatedNumber;
            Color ShadeColor;

            // Fallback color
            ShadeColor = Color.Transparent;

            generatedNumber = Rand.Next(50, 150);

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

        public static Color GetColor(string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }

        public static Color GetPersonColor()
        {
            Color SkinColor;
            List<Color> SkinColors;
            int GeneratedIndex;

            SkinColors = new List<Color>();

            SkinColors.Add(GetColor("#f3efee"));
            SkinColors.Add(GetColor("#efe6dd"));
            SkinColors.Add(GetColor("#ebd4c6"));
            SkinColors.Add(GetColor("#d7b6a5"));
            SkinColors.Add(GetColor("#9e7967"));

            GeneratedIndex = Rand.Next(0, 5);

            SkinColor = SkinColors[GeneratedIndex];

            return SkinColor;
        }

        public void Desplazar()
        {
            Thread ProcesoDesplazar; 
        }

    }
}
