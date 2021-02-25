using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fibonachi_DZ
{
    class Program
    {
        delegate List<uint> AsyncFibo(int strat, int end);
        static void Main(string[] args)
        {
            //Подсчет числа Фибонначи от нуля до границы указанной пользователем
            Console.WriteLine("\tПОДСЧЕТ ЧИСЛА ФИБОННАЧИ\n" +
                              "\t-----------------------");
            Console.WriteLine();
            Console.Write(" Укажите границу диапазона (конец диапазона): ");
            int start = 0;
            int end = Convert.ToInt32(Console.ReadLine());
            List<uint> result = new List<uint>(); ;
            AsyncFibo asyncFibo = (int st, int en) => 
            {
                List<uint> fibo = new List<uint>();
                uint a = 0, b = 1;
                fibo.Add(a);
                for (int i = st; i < en; i++)
                {
                    uint temp = a;
                    a = b;
                    b = temp + b;
                    if (a <= en)
                        fibo.Add(a);
                    else
                        break;
                }
                return fibo;
            };

            IAsyncResult ar = asyncFibo.BeginInvoke(start, end, null, null);
            while (!ar.IsCompleted)
            {
                result = asyncFibo.EndInvoke(ar);
            }
            Console.WriteLine();
            Console.WriteLine($" Числовой ряд Фибонначи от 0 до {end}: \n");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Для выхода нажмите любую кнопку!");
            Console.ReadLine();

        }

    }
}
