using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CashBillInAction.IOServices
{
    /// <summary>
    /// IInputService implementation.
    /// </summary>
    public class InputService : IInputService
    {
        #region Private fields

        /// <summary>
        /// Amount.
        /// </summary>
        private readonly string _amount;

        /// <summary>
        /// Flag for language definition.
        /// </summary>
        private readonly string _localization;

        #endregion

        #region Constant

        /// <summary>
        /// Language message.
        /// </summary>
        private const string LanguageMessage = "Hi, please, choose language.\n Language:\n 1. English\n 2. Ukrainian";

        /// <summary>
        /// Money message.
        /// </summary>
        private const string MoneyMessage = "Enter the amount of money:";

        /// <summary>
        /// Exception message.
        /// </summary>
        private const string ExceptionMessage = "Incorrect language.";

        #endregion

        #region .ctor

        /// <summary>
        /// Constructor.
        /// </summary>
        public InputService()
        {
            Console.WriteLine(LanguageMessage);
            _localization = Console.ReadLine() ?? throw new ArgumentNullException();
            Console.WriteLine(MoneyMessage);
            _amount = Console.ReadLine() ?? throw new ArgumentNullException();
        }

        #endregion

        #region Action

        /// <summary>
        /// Method for reading data.
        /// </summary>
        /// <returns>KeyValuePair instance, key is flag, value is amount.</returns>
        public KeyValuePair<int, string> Readout()
        {
            if (_localization.Length > 1 && (Convert.ToInt32(_localization) != 1 | Convert.ToInt32(_localization) != 2))
                throw new Exception(ExceptionMessage);
            var regex = new Regex("^[0-9]+$");
            KeyValuePair<int, string> keyValuePair;
            
            // TODO Verify "_amount" for invalid input like "h345.9" or "6792g9.84"
            //if (regex.IsMatch(_amount))
            //{
            //    keyValuePair = new KeyValuePair<int, string>(Convert.ToInt32(_localization), _amount);
            //}
            keyValuePair = new KeyValuePair<int, string>(Convert.ToInt32(_localization), _amount);
            //else throw new Exception();

            return keyValuePair;
        }

        #endregion
    }
}

