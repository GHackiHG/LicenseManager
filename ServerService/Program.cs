using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ServerService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceController.Instance.OnLog += Logger;
            ServiceController.Instance.ExistFunc = x => ServiceController.Instance.DataBase.Where(y => y.Login == x.Login && y.Indentificator == x.Indentificator).Count() == 1;
            ServiceController.Instance.Initialize<ServiceImplementation>("188.190.214.3:26123");
            Console.ReadKey();
        }
        static void Logger(string message)
        {
            var time = DateTime.Now.ToString();
            Console.WriteLine($"{ time } | {message + Environment.NewLine}");
            File.AppendAllText("Logs.txt", $"{ time } | {message + Environment.NewLine}");
        }
    }
}
