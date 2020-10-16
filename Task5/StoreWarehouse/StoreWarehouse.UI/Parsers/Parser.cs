using System;

namespace StoreWarehouse.UI.Parsers
{
    static class Parser
    {
        public static int? ParseInt(string line)
        {
            if (int.TryParse(line, out int result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static DateTime? ParseDate(string line)
        {
            if (DateTime.TryParse(line, out DateTime result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
