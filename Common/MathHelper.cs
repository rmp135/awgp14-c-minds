using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class MathHelper
    {
        public static int Clamp(int lower, int upper, int value)
        {
            if (value < lower)
                return lower;
            if (value > upper)
                return upper;
            return value;
        }
    }
}
