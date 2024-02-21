using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsCows
{
    public class OnePlayerGame
    {
        private static Random rnd = new Random();
        private static int steps = 0, bulls = 0, cows = 0;
        private static char[] enigma;

        private void Init(int n = 4)
        {
            char[] abc = "0123456789".ToCharArray();

            for (int i = 0; i < 4; i++)
            {
                var j = rnd.Next(i + 1, 10);
                (abc[i], abc[j]) = (abc[j], abc[i]);
            }
            enigma = abc[..4];
        }

        private void Loop()
        {
            do
            {
                steps++;
                var hypothesis = IOHelper.Input(">>>");
                if (string.IsNullOrEmpty(hypothesis))
                    break;
                if (Verificate(hypothesis, out var error))
                {
                    bulls = 0; cows = 0;
                    for (int i = 0; i < 4; i++)
                        if (hypothesis[i] == enigma[i])
                            bulls++;
                        else if (enigma.Contains(hypothesis[i]))
                            cows++;
                    if (bulls == 4)
                        Console.WriteLine("You WIN!!!");
                    else
                        IOHelper.Print($"{steps}:  Bull:{bulls} Cows:{cows}");
                }
                else
                {
                    IOHelper.Print(error);
                }

            } while (bulls < 4);

        }

        private bool Verificate(string hypothesis, out string error)
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

        

        public void Run()
        {
            Init();
            Loop();
            IOHelper.Print("Заходи ещё!");

        }
    }
}

