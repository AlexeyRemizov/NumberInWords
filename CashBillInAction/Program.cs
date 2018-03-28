using CashBillInAction.Currency;
using System;
using System.Text;
using CashBillInAction.Count;
using CashBillInAction.IOServices;

namespace CashBillInAction
{
    /// <summary>
    /// Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IOutputService outputService = new OutputService();
            outputService.Start();

            Console.ReadKey();
        }
    }
}

