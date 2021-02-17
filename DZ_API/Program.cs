using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace DZ_API
{
    public class WinAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool MessageBeep(uint type);

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint Beep(int Freq, int Duration);
    }
    class Program
    {
        static void Main(string[] args)
        {
            WinAPI.MessageBox(new IntPtr(0), "MYKOLA", "Name", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "MATIOS", "Surname", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "Age - 38", "Age", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "Married", "Family status", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "IT ACADEMY STEP", "Educational institution", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "PV-911", "Group", 0 | 64);
            WinAPI.MessageBox(new IntPtr(0), "Three (3)", "Semester", 0 | 64);

            WinAPI.MessageBeep(WinAPI.Beep(500, 500));
            WinAPI.MessageBeep(WinAPI.Beep(1500, 400));
            WinAPI.MessageBeep(WinAPI.Beep(900, 800));
            WinAPI.MessageBeep(WinAPI.Beep(2500, 600));
            WinAPI.MessageBeep(WinAPI.Beep(5500, 400));
            WinAPI.MessageBeep(WinAPI.Beep(4000, 500));
            WinAPI.MessageBeep(WinAPI.Beep(8000, 700));
            WinAPI.MessageBeep(WinAPI.Beep(300, 500));
            WinAPI.MessageBeep(WinAPI.Beep(1000, 600));
            WinAPI.MessageBeep(WinAPI.Beep(200, 500));
           

            Console.ReadKey();
        }
    }
}
