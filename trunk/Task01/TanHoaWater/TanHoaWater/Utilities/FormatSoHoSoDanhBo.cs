using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanHoaWater.Utilities
{
    class FormatSoHoSoDanhBo
    {
        public static string sohoso(string _sohoso)
        {
            _sohoso = _sohoso.Insert(4, ".");
            _sohoso = _sohoso.Insert(9, ".");
            return _sohoso;
        }
        public static string sodanhbo(string _danhbo)
        {
            if (_danhbo.Length == 11)
            {
                _danhbo = _danhbo.Insert(4, "-");
                _danhbo = _danhbo.Insert(8, "-");
               
            }
            return _danhbo;
        }
    }
}
