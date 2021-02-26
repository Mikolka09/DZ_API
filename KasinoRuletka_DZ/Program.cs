using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace KasinoRuletka_DZ
{
    public class Player
    {
        public string Name;
        public int MoneyStart;
        public int MoneyEnd;
        public int Rate;
        public int Number;

        public override string ToString()
        {
            return "  " + Name.PadRight(14) + MoneyStart.ToString().PadLeft(6) + MoneyEnd.ToString().PadLeft(8);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endGame = true;
            while (endGame)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tДОБРО ПОЖАЛОВАТЬ В КАЗИНО!\n" +
                                  "\t--------------------------\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tПрошу за стол нашей РУЛЕТКИ!\n" +
                                  "\t----------------------------\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tНачинаем Игру!\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\t");
                for (int i = 0; i < 28; i++)
                {
                    Console.Write("#");
                    Thread.Sleep(300);
                }

                Random rand = new Random();
                int CountPlayers = rand.Next(20, 100);
                List<Player> players = new List<Player>();
                for (int i = 0; i < CountPlayers; i++)
                {
                    players.Add(new Player()
                    {
                        Name = $"Игрок №{i + 1}",
                        MoneyStart = rand.Next(5000, 10000),
                        MoneyEnd = 0,
                        Rate = 0,
                        Number = 0
                    });
                }

                Thread[] threadsPlayer = new Thread[players.Count];
                for (int i = 0; i < threadsPlayer.Length; i++)
                {
                    threadsPlayer[i] = new Thread(Game);
                    threadsPlayer[i].Start(players[i]);
                }
                for (int i = 0; i < threadsPlayer.Length; i++)
                {
                    threadsPlayer[i].Join();
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n");
                Console.WriteLine("\t\tКОНЕЦ ИГРЫ!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\tВывод результатов игры:\n");
                Console.WriteLine("\t1. На экран\n\t2. В файл\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\tВаш выбор: ");
                Console.ForegroundColor = ConsoleColor.White;
                int var = Convert.ToInt32(Console.ReadLine());
                switch (var)
                {
                    case 1:
                        PrintScreen(players);
                        break;
                    case 2:
                        PrintFile(players);
                        break;
                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("\tЖелаете выйти из игры или запустить еще раз?(Выход-1, Перезапуск-2): ");
                Console.ForegroundColor = ConsoleColor.White;
                int var1 = Convert.ToInt32(Console.ReadLine());
                if (var1 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tСПАСИБО ЗА ИГРУ. ВЫХОД ИЗ ИГРЫ!");
                    endGame = false;
                }
                else
                    endGame = true;
                Console.ForegroundColor = ConsoleColor.White;

            }

            Console.ReadLine();
        }

        public static void Game(object obj)
        {
            Player player = (Player)obj;
            int moneySt = player.MoneyStart;
            Semaphore sem = new Semaphore(5, 5);
            Random rnd = new Random();
            bool end = true;
            sem.WaitOne();
            while (end)
            {
                int numb = rnd.Next(0, 36);
                player.Number = rnd.Next(0, 36);
                player.Rate = rnd.Next(50, 300);
                if (moneySt >= player.Rate)
                    moneySt -= player.Rate;
                else if (moneySt <= 50 && moneySt != 0)
                {
                    player.Rate = moneySt;
                    moneySt = 0;
                }
                else if (player.MoneyEnd >= player.Rate)
                    player.MoneyEnd -= player.Rate;
                else if (player.MoneyEnd > 50 && player.MoneyEnd < player.Rate)
                {
                    player.Rate = 50;
                    player.MoneyEnd -= 50;
                }
                if (player.Number == numb)
                    player.Rate *= 2;
                else
                    player.Rate = 0;
                player.MoneyEnd += player.Rate;
                if (moneySt <= 0 && player.MoneyEnd < 50)
                    end = false;
                else
                    end = true;
            }
            sem.Release();
        }

        public static void PrintScreen(List<Player> players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\tОТЧЕТ ИГРЫ ПО ВСЕМ ИГРОКАМ\n" +
                              "\t--------------------------\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  " + "Имя Игрока".PadRight(12) + "Start Сумма".PadRight(13) + "End Сумма".PadRight(11));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (var item in players)
            {
                Console.WriteLine(item.ToString());
            }

        }

        public static void PrintFile(List<Player> players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tСохранение файла\n" +
                                "\t----------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n\tУкажите имя файла: ");
            Console.ForegroundColor = ConsoleColor.White;
            string Name = Console.ReadLine().ToLower() + ".txt";
            using (StreamWriter sw = new StreamWriter(Name, false, Encoding.Default))
            {
                sw.WriteLine("\tОТЧЕТ ИГРЫ ПО ВСЕМ ИГРОКАМ\n" +
                             "\t--------------------------\n");
                sw.WriteLine("  " + "Имя Игрока".PadRight(12) + "Start Сумма".PadRight(13) + "End Сумма".PadRight(11));
                foreach (var item in players)
                {
                    sw.WriteLine(item.ToString());
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\tОтчет игры записан в файл по адресу: D:\\Users\\MIKOLKA\\DZ_API\\DZ_API\\KasinoRuletka_DZ\\bin\\Debug\\{Name}");
        }
    }
}
