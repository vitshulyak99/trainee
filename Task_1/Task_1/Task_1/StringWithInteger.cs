using System;
using System.Globalization;
using Task_1.Exceptions;

namespace Task_1
{
    internal class StringWithInteger : StringWithNumber
    {

        public StringWithInteger(string str)
        {
            Value = str;
        }

        public override string Result()
        {
            try
            {

                if (int.TryParse(Value.Split(' ')[1], out int number))
                {

                    string str = Value.Split(' ')[0];
                    string output = string.Empty;
                    if (number == 13)
                        return DateTime.UtcNow.ToString(new CultureInfo("en-US"));//6

                    else
                    if (number == 777)
                        throw new JackpotException("Jackpot!");//7
                    else
                    if (number == 888)
                        throw new ImmortalityException("Immportality");//8
                    else
                    if (number >= 0 && number <= 5)
                    {

                        for (int j = 0; j < number; ++j)
                        {
                            output += $"{str} ";
                        }

                        return output;

                    }
                    else
                    {
                        return $"Requested string {str} was repeadet {number}";//5
                    }


                }
                else
                {
                    throw new Exception("This string does not contains [int] value");
                }

            }
            catch (ImmortalityException ex)
            {
                Console.WriteLine("Immortality is impossible");
                throw;
            }
        }
    }
}