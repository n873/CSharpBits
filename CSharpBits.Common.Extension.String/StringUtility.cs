using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpBits.Common.Extension.String
{
    public static class StringUtility
    {
        public static bool IsAlphaNumeric(this string input)
        {
            try
            {
                return new Regex("^[a-zA-Z0-9]*$").IsMatch(input.Trim());
            }
            catch (Exception) { throw; }
        }

        public static bool IsAlpha(this string input)
        {
            try
            {
                return new Regex("^[a-zA-Z]*$").IsMatch(input.Trim());
            }
            catch (Exception) { throw; }
        }

        public static bool IsInteger(this string input, out int number)
        {
            try
            {
                return int.TryParse(input, out number);
            }
            catch (Exception) { throw; }
        }

        public static bool IsInteger64(this string input, out Int64 output)
        {
            try
            {
                return Int64.TryParse(input, out output);
            }
            catch (Exception) { throw; }
        }

        public static bool IsDecimal(this string input, out decimal output)
        {
            try
            {
                return Decimal.TryParse(input, out output);
            }
            catch (Exception) { throw; }
        }

        public static bool IsBoolean(this string input, out bool output)
        {
            try
            {
                return bool.TryParse(input, out output);
            }
            catch (Exception) { throw; }
        }

        public static List<string> ToStringList(this string input)
        {
            try
            {
                var output = input.Contains("#") ? input.Split('#')
                    : input.Contains(",") ? input.Split(',')
                    : input.Contains("|") ? input.Split('|')
                    : input.Contains("_") ? input.Split('_')
                    : input.Contains("-") ? input.Split('-')
                    : input.Contains(";") ? input.Split(';')
                    : new string[] { input };

                if (output != null && output.Length > 0)
                    return output.ToList();

                return null;
            }
            catch (Exception) { throw; }
        }

        public static List<int> ToIntegerList(this string input)
        {
            try
            {
                var ouputValues = new List<int>();
                var splitValues =
                     input.Contains("#") ? input.Split('#')
                   : input.Contains(",") ? input.Split(',')
                   : input.Contains("|") ? input.Split('|')
                   : input.Contains("_") ? input.Split('_')
                   : input.Contains("-") ? input.Split('-')
                   : input.Contains(";") ? input.Split(';')
                   : new string[] { input };

                if (splitValues != null && splitValues.Length > 0)
                    foreach (var value in splitValues)
                    {
                        int parsedValue;
                        var parsed = Int32.TryParse(value, out parsedValue);
                        if (parsed)
                            ouputValues.Add(parsedValue);
                    }

                return ouputValues;
            }
            catch (Exception) { throw; }
        }
    }
}
