using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BullsCows
{
    internal class TwoPlayersGame
    {
        private string nameUser1 { get; set; }
        private string nameUser2 { get; set; }


        private char[] numberOfUser1 { get; set; }


        private char[] numberOfUser2 { get; set; }

        private void Init()
        {
            IOHelper.Print("Добро пожаловать в игру  Быки и Коровы");
            IOHelper.Print("Введите имя первого игрока");

            this.nameUser1 = IOHelper.Input(">>");
            IOHelper.Print("Введите имя второго игрока");
            this.nameUser2 = IOHelper.Input(">>");

            IOHelper.Print("Игра начинается...");
        }

        private void UserThinking(string username)
        {
            while (true)
            {
                IOHelper.Print($"Игрок {username}, загадывайте число в соответствии с правилами игры");
                var usernameInput = IOHelper.Input(">>");

                if (IOHelper.Verificate(usernameInput, out var error))
                {
                    this.numberOfUser1 = usernameInput.ToCharArray();
                    break;
                }
                else
                {
                    IOHelper.Print(error);
                }
            }
        }

        private void ThinkOfANumber()
        {
            UserThinking(this.nameUser1);
            UserThinking(this.nameUser2);
        }

        private string ChooseWhoStart()
        {
            string res;
            Random rnd = new Random();
            int ranomNumber = rnd.Next(0, 2);
            if (ranomNumber == 0)
            {
                res = nameUser1;
            }
            else
            {
                res = nameUser2;
            }

            IOHelper.Print($"Игрок {res} начинает игру!");
            return res;
        }

        private void Compete(string firstPlayer)
        {
            IOHelper.Print($"Игрок {firstPlayer}, делайте ваш ход");
        }

        public void Run()
        {
            Init();
            ThinkOfANumber();
            var firstPlayer = ChooseWhoStart();

        }

    }
    
}

