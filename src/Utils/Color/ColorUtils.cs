using System;
using System.Collections.Generic;
using System.Drawing;

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

        public static void GetPersonColor(out Color SkinColor, out Color ForeColor)
        {
            List<Color> SkinColors;
            int GeneratedIndex;

            SkinColors = new List<Color>();

            SkinColors.Add(GetColor("#f3efee"));
            SkinColors.Add(GetColor("#efe6dd"));
            SkinColors.Add(GetColor("#ebd4c6"));
            SkinColors.Add(GetColor("#d7b6a5"));
            SkinColors.Add(GetColor("#9e7967"));
            SkinColors.Add(GetColor("#70361c"));
            SkinColors.Add(GetColor("#321b0f"));

            GeneratedIndex = Rand.Next(0, 7);

            int R;
            int G;
            int B;

            R = SkinColors[GeneratedIndex].R;
            G = SkinColors[GeneratedIndex].G;
            B = SkinColors[GeneratedIndex].B;

            if (R * 0.299 + G * 0.587 + B * 0.114 > 150)
            {
                ForeColor = ColorUtils.GetColor("#000");
            }
            else
            {
                ForeColor = ColorUtils.GetColor("#fff");
            }

            SkinColor = SkinColors[GeneratedIndex];
        }

    }
}
