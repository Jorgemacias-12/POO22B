using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Utils.Rand
{
    public class RandomIC
    {
        public static int Next(int MinValue, int MaxValue)
        {
            Random rand;

            rand = new Random();

            if (MaxValue == Int32.MaxValue)
            {

                if (MinValue == Int32.MinValue)
                {
                    var Value = rand.Next() % 0x10000;
                    var Value2 = rand.Next() % 0x10000;
                    return (Value << 16) | Value2;
                }

                return rand.Next(MinValue - 1, MaxValue) + 1;
            }

            return rand.Next(MinValue, MaxValue + 1); 
        }
    }
}
