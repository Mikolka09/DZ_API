using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 0;
            int a = Convert.ToInt32(args[0]);
            int b = Convert.ToInt32(args[1]);
            string c = args[2];
            switch (c)
            {
                case "+":
                    d = a + b;
                    break;
                case "-":
                    d = a - b;
                    break;
                case "/":
                    d = Math.Round(a / (double)b, 2);
                    break;
                case "*":
                    d = a * b;
                    break;
                default:
                    break;
            }

            Console.WriteLine("{0} {1} {2} = {3}", a, c, b, d);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для завершения");
            Console.ReadKey();
        }
    }
}
