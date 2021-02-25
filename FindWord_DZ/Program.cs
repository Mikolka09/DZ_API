using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace FindWord_DZ
{
    class Program
    {
        delegate int AsyncCountWord(StreamReader sr, string word);
        static void Main(string[] args)
        {
            //Поиск слова в файле в некоторой директории
            Console.WriteLine("\tПОИСК СЛОВА В ФАЙЛЕ НЕКОТОРОЙ ДИРЕКТОРИИ\n" +
                              "\t----------------------------------------");
            Console.WriteLine();
            Console.Write(" Укажите слово, которе требуется найти: ");
            string word = Console.ReadLine();
            Console.Write(" Укажите путь к Директории: ");
            string address = Console.ReadLine();
            int countWord = 0;
            if (Directory.Exists(address))
            {
                string[] files = Directory.GetFiles(address, "*.txt");
                foreach (var item in files)
                {
                    StreamReader sr = new StreamReader(item, Encoding.Default);
                    AsyncCountWord asyncCount = CountWord;
                    IAsyncResult ar = asyncCount.BeginInvoke(sr, word, null, null);
                    
                    while (!ar.IsCompleted)
                    {
                        countWord = asyncCount.EndInvoke(ar);
                        Console.WriteLine();
                        Console.WriteLine(" ОТЧЕТ ПОИСКА\n" +
                                          " ------------");
                        Console.WriteLine($"Название файла: {Path.GetFileName(item)}");
                        Console.WriteLine($"Путь к файла: {item}");
                        Console.WriteLine($"Количество вхождений слова '{word}': {countWord}");
                    }
                }

            }

            Console.ReadLine();
        }

        static int CountWord(StreamReader sr, string wr)
        {
            int count = 0;
            string st = "";
            while (!sr.EndOfStream)
            {
                st = sr.ReadLine();
                foreach (var item in st.Split())
                {
                    if (item.Contains(wr))
                        count++;
                }
            }
            return count;
        }
    }
}
