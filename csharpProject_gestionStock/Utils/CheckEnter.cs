using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Utils
{
    public static class CheckEnter
    {
        public static bool CheckIsNumber(string Number)
        {
            int value;
            return int.TryParse(Number, out value);
        }

        public static bool CheckIsFloat(string Number)
        {
            float value;
            return float.TryParse(Number, out value);
        }
    }
}
