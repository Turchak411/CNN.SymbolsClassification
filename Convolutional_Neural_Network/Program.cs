using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;

namespace Convolutional_Neural_Network
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

            // Повышение приоритета процесса
            //Process ps = Process.GetCurrentProcess();
            //ps.PriorityClass = ProcessPriorityClass.High;

            Application.Run(new MainForm());
        }
    }
}
