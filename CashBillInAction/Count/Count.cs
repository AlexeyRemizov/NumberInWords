using CashBillInAction.Currency;
using CashBillInAction.IOServices;
using System;
using System.Collections.Generic;

namespace CashBillInAction.Count
{
    /// <summary>
    /// ICount implementation.
    /// </summary>
    public class Count : ICount
    {
        #region Private fields

        /// <summary>
        /// IInputService instance.
        /// </summary>
        private readonly IInputService _inputService;

        /// <summary>
        /// ICurrency instance.
        /// </summary>
        private readonly ICurrency _currency;

        /// <summary>
        /// Flag for language definition.
        /// </summary>
        private readonly int _flag;


        #endregion

        #region .ctor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inputService">IInputService instance.</param>
        /// <param name="currency">ICurrency instance.</param>
        public Count(IInputService inputService, ICurrency currency)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _currency = currency ?? throw new ArgumentNullException(nameof(currency));
            _flag = _inputService.Readout().Key;
        }

        #endregion

        #region Action

        /// <summary>
        /// Validate data.
        /// </summary>
        /// <returns>Whole and fractional parts.</returns>
        public KeyValuePair<int, int> Validate()
        {
            var number = _inputService.Readout().Value;
            string[] separetors;
            if (_flag == 1)
            {
                separetors = number.Split('.');
            }
            else
            {
                separetors = number.Split(',');
            }
            if (separetors.Length == 1)
            {
                throw new Exception();
            }
            if ((Convert.ToInt64(separetors[0]) >= int.MaxValue) | (separetors[1].Length > 2))
            {
                throw new Exception();
            }

            return new KeyValuePair<int, int>(Convert.ToInt32(separetors[0]), Convert.ToInt32(separetors[1]));
        }

        /// <summary>
        /// CashBill do his work.
        /// </summary>
        /// <returns>Requested number by word.</returns>
        public string CashBill()
        {
            var numbers = Validate();
            var integerPartOfWord = _currency.GetInteger(numbers.Key);
            var remainderPartOfWord = _currency.GetRemainder(numbers.Value);
            if (_flag == 1)
                return integerPartOfWord + "Dollars " + remainderPartOfWord;
            else return integerPartOfWord + "Гривень " + remainderPartOfWord ;
        }

        #endregion
    }
}

