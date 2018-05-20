using System;

namespace CSharpBits.Common.Extension.Numeric
{
    public static class NumericUtility
    {
        public static Int32 ToInteger32(this Int64 input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch (Exception) { throw; }
        }

        public static string ToIntegerString(this decimal input)
        {
            try
            {
                return Convert.ToInt32(input).ToString();
            }
            catch (Exception) { throw; }
        }

        public static int ToInteger(this double input)
        {
            try
            {
                return Convert.ToInt32(Math.Floor(input));
            }
            catch (Exception) { throw; }
        }

        public static float ToFloat(this decimal input)
        {
            try
            {
                return (float)input;
            }
            catch (Exception) { throw; }
        }
    }
}
