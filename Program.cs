namespace BullsCows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите режим игры (0 - игра с компьютером, 1 - игра с другом):");
            int gameMode = int.Parse(Console.ReadLine());
            var mode = GameMode.OnePlayer;
            switch (gameMode)
            {
                case 0:
                    mode = GameMode.OnePlayer;
                    break;
                case 1:
                    mode = GameMode.TwoPlayers;
                    break;
                default:
                    Console.WriteLine("Введите 0 или 1!");
                    break;
            }

            var bc = new BullsCows(mode);

        }
    }
}