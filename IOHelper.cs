using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsCows
{
    public static class IOHelper
    {
        public static bool Verificate(string? hypothesis, out string error)
        {
            error = "";
            string errorMessage = "Гипотеза должна состоять из четырёх различных цифр";
            if (hypothesis.Length != 4)
                error = errorMessage;
            else if (hypothesis.Distinct().Count() != 4)
                error = errorMessage;
            else if (hypothesis.Any(c => !char.IsDigit(c)))
                error = errorMessage;
            return error == "";
        }

        public static string Input(string hint = "")
        {
            Console.Write(hint);
            return Console.ReadLine();
        }

        public static void Print(string? str)
        {
            Console.WriteLine(str);
        }
    }
}
