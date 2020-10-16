using System;
using System.Globalization;

namespace Task_1
{
    class StringWithDouble : StringWithNumber
    {

        public StringWithDouble(string str)
        {
            Value = str.Trim();
        }

        public override string Result()
        {
            var strngs = Value.Split(' ');

            if (double.TryParse(strngs[1], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double number))
            {

                if (number > 0)
                {
                    if (number <= 5 && number > 0)
                    {
                        string output = string.Empty;
                        var index = strngs[1].IndexOf('.');
                        
                        for (int i = 0; i < (int)number; i++) 
                            output += strngs[0] + ' ';

                        output += strngs[0][..(strngs[1].Length - index)]+ ' ';

                        return output;
                    }
                    else
                    {
                        return $"Requested string {Value.Split(' ')[0]} was repeadet {Math.Round(number, 2)}";
                    }
                }
                else
                {
                    throw new Exception("Can not work with negative nubmers or zero");
                }

            }
            else
            {
                throw new Exception("This string does not contains [double] value");
            }

        }
    }
}
