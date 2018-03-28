using CashBillInAction.Count;
using CashBillInAction.Currency;
using System;

namespace CashBillInAction.IOServices
{
    /// <summary>
    /// IOutputService implementation.
    /// </summary>
    public class OutputService : IOutputService
    {
        #region Private fields

        /// <summary>
        /// ICount instance.
        /// </summary>
        private ICount _count;

        #endregion

        #region Action

        /// <summary>
        /// The method outputs the number in words.
        /// </summary>
        public void Start()
        {
            var inputService = new InputService();
            if (inputService.Readout().Key == 1)
            {
                _count = new Count.Count(inputService, new USCurrency());
            }
            else
            {
                _count = new Count.Count(inputService, new UkrCurrency());
            }
            var output = _count.CashBill();

            Console.WriteLine(output);
            Console.WriteLine("Cash Bill done his work.");
        }

        #endregion
    }
}
