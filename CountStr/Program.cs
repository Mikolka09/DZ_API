using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CountStr
{
    class Program
    {
        static void Main(string[] args)
        {
            string adres = args[0];
            string st = args[1];
            string s = "";
            string[] mass;
            StreamReader stream = new StreamReader(adres, Encoding.Default);
            while (!stream.EndOfStream)
            {
                s += stream.ReadLine();
            }
            mass = s.Split(' ');
            int count = 0;
            for (int i = 0; i < mass.Length; i++)
            {
                string ss = mass[i].Replace(",.!?:;", "");
                if (ss == st)
                    count++;
            }
            stream.Close();
            Console.WriteLine("Колличество повторений слова - {0} = {1}", st, count);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для завершения");
            Console.ReadKey();
        }
    }
}
