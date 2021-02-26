using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ThreeCopy_DZ
{

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Semaphore s = new Semaphore(3, 3, "MyApplication"))
            {
                if (s.WaitOne(TimeSpan.FromSeconds(0.5)))
                    Application.Run(new Form1());
                else
                {
                    if (MessageBox.Show("Извините, максимальное количесвто копий уже использовано!") == DialogResult.OK)
                    {
                        string name = "ThreeCopy_DZ";
                        Process[] proc = Process.GetProcesses();
                        foreach (Process item in proc)
                        {
                            if (item.ProcessName == name)
                                item.Kill();
                        }

                    }
                }
            }
        }
    }
}