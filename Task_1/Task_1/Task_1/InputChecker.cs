using System;
using System.Text.RegularExpressions;

namespace Task_1
{
    class InputChecker
    {
        readonly Regex _stringPattern = new Regex(@"^\w+");
        readonly Regex _numberPattern = new Regex(@"(\d+|\d+[.]\d+)$");
        readonly Regex _finalCheck = new Regex(@"^.+\s+(\d+|\d+[.]\d+)$");
        readonly Regex _floatCheck = new Regex(@"\d+([.]|[,])\d+");

        public StringWithNumber Check(string str)
        {
            bool spRes = _stringPattern.IsMatch(str),
                 npRes = _numberPattern.IsMatch(str),
                 fChk = _finalCheck.IsMatch(str);

            if (!spRes)
            {
                throw new Exception("String parameter is missing");
            }
            else if (!npRes)
            {
                throw new Exception("Number parameter is missing");
            }
            else if (!fChk)
            {
                throw new Exception("Invalid input string");
            }
            else
            {

                if (_floatCheck.IsMatch(str))
                {
                    return new StringWithDouble(str);
                }
                else
                {
                    return new StringWithInteger(str);
                }

            }
        }
    }
}
