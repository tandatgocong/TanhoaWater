using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TanHoaWater.Utilities
{
    class Strings
    {
        public static string DoiDonViMet(double number)
        {
            string line = String.Format("{0:0.0}", number);
            string[] words = Regex.Split(line, "\\.");
            if (words.Length == 2)
            {
                return words[0] + "m" + words[1];
            }
            return words[0] + "m";
        }
    }
}
