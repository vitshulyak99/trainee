using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task4.Exceptions;
using Task4.Provider.Interface;
using System.Linq;
using System.Globalization;

namespace Task4.LineHandlers
{
    static public class LineParser
    {
        public static int SymRepeats(string line, char sym)
        {
            
                if (string.IsNullOrEmpty(line))
                {
                    throw new ArgumentException("Argument does not match null or empty",
                        nameof(line));
                }

                return line.Where(s => s.Equals(sym)).Count();
           
           
        }

        public static string GetOnlyWordCharacterFromString(string line)
        {
            if (line is null)
            {
                throw new ArgumentNullException(nameof(line));
            }



            if (new Regex(@"([a-zA-Z],)+(-)*\d+$").IsMatch(line))
            {
                string result = "";
                var regex = new Regex(@"[a-zA-Z]");
                foreach (var sym in line)
                {
                    if (regex.IsMatch("" + sym))
                        result += sym;
                }

                return result.Length == 0 ? throw new InvalidInputStringException() : result;

            }
            else
            {
                throw new InvalidInputStringException();

            }
        }

        public static int GetOnlyNumber(string line)
        {



            if (line is null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            var regex = new Regex(@"([a-zA-Z],)+-*\d+$");
            var rNum = new Regex(@"-*\d+");

            if (!regex.IsMatch(line)) throw new InvalidInputStringException();
            else
            {
                var val = rNum.Match(line).Value;

                return int.Parse(val, CultureInfo.GetCultureInfo("en-US"));
            }

        }


        public static char RandomSymbolFromString(string line,IGenerateInteger random)
        {

            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentException("message", nameof(line));
            }

            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            return line.Length == 1 ? line[0] : line[random.Generate(0, line.Length - 1)];
        }
    }
}
