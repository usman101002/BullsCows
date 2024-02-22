using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BullsCows
{
    // Я создаю поля firstPlayer, secondPlayer, user1, user2, а не просто firstPlayer и secondPlayer, потому что пользователи сначала загадывают числа,
    // а уже потомом происходит жеребьёвка, кто ходит первый, а кто второй. 
    public class TwoPlayersGame
    {
        private User firstPlayer { get; set; }
        private User secondPlayer { get; set; }
        private User user1 { get; set; }
        private User user2 { get; set; }

        private void Init()
        {
            IOHelper.Print("Добро пожаловать в игру  Быки и Коровы");
        }

        private (User, User) CreatePlayers()
        {
            IOHelper.Print("Введите имя первого игрока");

            var name1 = IOHelper.Input(">>");
            user1 = new User(name1);
            IOHelper.Print("Введите имя второго игрока");
            var name2 = IOHelper.Input(">>");
            user2 = new User(name2);

            IOHelper.Print("Игра начинается...");
            return (user1, user2);
        }

        private char[] GuessNumber(User user)
        {
            while (true)
            {
                IOHelper.Print($"Игрок {user.ToString()}, загадывайте число в соответствии с правилами игры");
                var userInput = IOHelper.Input(">>");

                if (IOHelper.Verificate(userInput, out var error))
                {
                    return userInput.ToCharArray();
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
            this.user1.Number = GuessNumber(this.user1);
            this.user2.Number = GuessNumber(this.user2);
        }

        private (User, User) ChooseWhoStart(User user1, User user2)
        {
            User firstPlayer, secondPlayer;
            Random rnd = new Random();
            int ranomNumber = rnd.Next(0, 2);
            if (ranomNumber == 0)
            {
                firstPlayer = user1;
                secondPlayer = user2;
            }
            else
            {
                firstPlayer = user2;
                secondPlayer = user1;
            }

            IOHelper.Print($"Игрок {firstPlayer} начинает игру!");
            return (firstPlayer, secondPlayer);
        }

        private void Compete(User firstPlayer, User secondPlayer)
        {
            while (true)
            {
                bool firstWin = false;
                bool secondWin = false;

                #region Действия первого игрока
                this.firstPlayer.Bulls = 0;
                this.firstPlayer.Cows = 0;

                IOHelper.Print($"Игрок {firstPlayer}, делайте ваш ход");
                var firstPlayerMove = IOHelper.Input(">>");

                if (string.IsNullOrEmpty(firstPlayerMove))
                    break;
                if (IOHelper.Verificate(firstPlayerMove, out var error))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (firstPlayerMove[i] == this.secondPlayer.Number[i])
                        {
                            this.firstPlayer.Bulls += 1;
                        }
                        else if (this.secondPlayer.Number.Contains(firstPlayerMove[i]))
                        {
                            this.firstPlayer.Cows += 1;
                        }
                    }

                    if (this.firstPlayer.Bulls == 4)
                    {
                        IOHelper.Print($"Игрок {this.firstPlayer} победил!");
                        firstWin = true;
                    }
                    else
                    {
                        IOHelper.Print($"Шаг игры: {this.firstPlayer}, Bulls: {this.firstPlayer.Bulls}, Cows: {this.firstPlayer.Cows}");
                    }

                    this.firstPlayer.Move += 1;
                }
                else
                {
                    IOHelper.Print(error);
                }
                #endregion

                #region Дейстия второго игрока
                this.secondPlayer.Bulls = 0;
                this.secondPlayer.Cows = 0;

                IOHelper.Print($"Игрок {secondPlayer}, делайте ваш ход");
                var secondPlayerMove = IOHelper.Input(">>");

                if (string.IsNullOrEmpty(secondPlayerMove))
                    break;
                if (IOHelper.Verificate(secondPlayerMove, out var error1))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (secondPlayerMove[i] == this.firstPlayer.Number[i])
                        {
                            this.secondPlayer.Bulls += 1;
                        }
                        else if (this.firstPlayer.Number.Contains(secondPlayerMove[i]))
                        {
                            this.secondPlayer.Cows += 1;
                        }
                    }

                    if (this.secondPlayer.Bulls == 4)
                    {
                        IOHelper.Print($"Игрок {secondPlayer} победил!");
                        secondWin = true;
                    }
                    else
                    {
                        IOHelper.Print($"Шаг игры: {secondPlayer.Move}, Bulls: {this.secondPlayer.Bulls}, Cows: {this.secondPlayer.Cows}");
                    }

                    this.secondPlayer.Move += 1;
                }
                else
                {
                    IOHelper.Print(error);
                }
                #endregion

                if (firstWin && secondWin)
                {
                    IOHelper.Print("Оба игрока победили");
                    break;
                }
                else if (firstWin && !secondWin)
                {
                    IOHelper.Print($"Победил игрок {firstPlayer}");
                    break;
                }
                else if (!firstWin && secondWin)
                {
                    IOHelper.Print($"Победил игрок {secondPlayer}");
                    break;
                }
            }
        }

        public void Run()
        {
            Init();
            (var player1, var player2) = CreatePlayers();
            ThinkOfANumber();
            (this.firstPlayer, this.secondPlayer) = ChooseWhoStart(player1, player2);
            Compete(this.firstPlayer, this.secondPlayer);

        }
    }
}

