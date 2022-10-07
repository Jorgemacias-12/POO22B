using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Utils.Rng
{
    public class RandomEx : Random
    {

        private uint _boolBits;

        public RandomEx() : base()
        {

        }
        
        public bool NextBoolean()
        {
            _boolBits >>= 1;
            if (_boolBits <= 1) _boolBits = (uint)~this.Next();
            return (_boolBits & 1) == 0;
        }

    }
}
