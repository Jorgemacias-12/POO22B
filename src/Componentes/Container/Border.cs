using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO22B_MZJA.src.Componentes.Container
{
    public struct Border
    {
        private bool _All;
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;

        public static Border Empty = new Border(0);
        public Border(int all)
        {
            _All = true;
            _Top = (_Left = (_Right = (_Bottom = all)));
        }

        public int All
        {
            get
            {
                if (!_All)
                {
                    return -1;
                }
                return _Top;
            }

            set
            {
                if (!_All || _Top != value)
                {
                    _All = true;
                    _Top = (_Left = (_Right = (_Bottom)));
                }
            }
        }

        public int Left
        {
            get
            {
                return _Left;
            }

            set
            {
                if (_All || _Left != value)
                {
                    _All = false;
                    _Left = value;
                }
            }
        }

        public int Top
        {
            get
            {
                return _Top;
            }

            set
            {
                if (_All || _Top != value)
                {
                    _All = false;
                    _Top = value;
                }
            }
        }

        public int Right
        {
            get
            {
                return _Right;
            }

            set
            {
                if (_All || _Right != value)
                {
                    _All = false;
                    _Right = value;
                }
            }
        }

        public int Bottom
        {
            get
            {
                return _Bottom;
            }

            set
            {
                if (_All || _Bottom != value)
                {
                    _All = false;
                    _Bottom = value;
                }
            }

        }

    }

}
