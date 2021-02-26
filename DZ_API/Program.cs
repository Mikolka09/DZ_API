using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace DZ_API
{

    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1.
            //ProcessStartInfo info = new ProcessStartInfo("notepad.exe");
            //Process process = Process.Start(info);
            //process.WaitForExit();
            //Console.WriteLine("Код завершения = " + process.ExitCode);

            //Задание 2.
            //ProcessStartInfo info = new ProcessStartInfo("notepad.exe");
            //Process process = Process.Start(info);
            //bool b = true;
            //while (b)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Выберите действия: \n\n" +
            //        "\t1. Ожидать завершения приложения с выводом кода завершения?\n" +
            //        "\t2. Принудительно закрыть приложение?\n");
            //    Console.Write("Ваш выбор: ");
            //    int var = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine();
            //    if (var == 1)
            //    {
            //        process.WaitForExit();
            //        Console.WriteLine("Код завершения = " + process.ExitCode);
            //        b = false;
            //    }
            //    else if (var == 2)
            //    {
            //        process.Kill();
            //        Console.WriteLine("Приложение принудительно закрыто!");
            //        b = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Неправильно выбранное действие! Попробуйте еще раз!");
            //        Thread.Sleep(1500);
            //        b = true;
            //    }
            //}

            //Задание 3.
            //ProcessStartInfo info = new ProcessStartInfo("d:\\Users\\MIKOLKA\\DZ_API\\DZ_API\\Calculation\\bin\\Debug\\Calculation.exe");
            //info.WindowStyle = ProcessWindowStyle.Normal;
            //bool b = true;
            //while (b)
            //{
            //    Console.Clear();
            //    Console.Write("Введите аргументы через пробел типа (число число операция): ");
            //    string arg = Console.ReadLine();
            //    info.Arguments = arg;
            //    Process process = Process.Start(info);
            //    process.WaitForExit();
            //    Console.WriteLine();
            //    Console.Write("Хотите ввести новые аргументы?(Да-1, Нет-2): ");
            //    int var = Convert.ToInt32(Console.ReadLine());
            //    if (var != 1)
            //        b = false;
            //}
            //Console.WriteLine();
            //Console.WriteLine("ВЫХОД!");


            //Задание 4.
            ProcessStartInfo info = new ProcessStartInfo("D:\\Users\\MIKOLKA\\DZ_API\\DZ_API\\CountStr\\bin\\Debug\\CountStr.exe");
            info.WindowStyle = ProcessWindowStyle.Normal;
            bool b = true;
            while (b)
            {
                Console.Clear();
                string arg = "";
                Console.Write("Введите первый аргумент (адрес файла): ");
                string arg1 = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Введите второй аргумент (слово): ");
                string arg2 = Console.ReadLine();
                arg = arg1 + " " + arg2;
                info.Arguments = arg;
                Process process = Process.Start(info);
                process.WaitForExit();
                Console.WriteLine();
                Console.Write("Хотите ввести новые аргументы?(Да-1, Нет-2): ");
                int var = Convert.ToInt32(Console.ReadLine());
                if (var != 1)
                    b = false;
            }
            Console.WriteLine();
            Console.WriteLine("ВЫХОД!");


            //D:\\Probnik.txt



            Console.WriteLine();
            Console.WriteLine("Нажмите любую кнопку для завершения");
            Console.ReadKey();

        }
    }
}
