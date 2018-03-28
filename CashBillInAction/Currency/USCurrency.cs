using System;

namespace CashBillInAction.Currency
{
    /// <summary>
    /// Implementation for English language.
    /// </summary>
    public class USCurrency : ICurrency
    {
        #region Constant

        /// <summary>
        /// Error message.
        /// </summary>
        private const string ErrorMessage = "The number can not be negative.";

        #endregion

        #region Action

        /// <summary>
        /// Method for counting the whole part.
        /// </summary>
        /// <param name="number">Whole part.</param>
        /// <returns>Inscription by word.</returns>
        public string GetInteger(int number)
        {
            if (number < 0)
            {
                throw new Exception(ErrorMessage);
            }
            if (number == 0)
                return " ";
            else if (number <= 19)
                return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
         "Seventeen", "Eighteen", "Nineteen"}[number - 1] + " ";
            else if (number <= 99)
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
         "Eighty", "Ninety"}[number / 10 - 2] + " " + GetInteger(number % 10);
            else if (number <= 199)
                return "One Hundred " + GetInteger(number % 100);
            else if (number <= 999)
                return GetInteger(number / 100) + "Hundreds " + GetInteger(number % 100);
            else if (number <= 1999)
                return "One Thousand " + GetInteger(number % 1000);
            else if (number <= 999999)
                return GetInteger(number / 1000) + "Thousands " + GetInteger(number % 1000);
            else if (number <= 1999999)
                return "One Million " + GetInteger(number % 1000000);
            else if (number <= 999999999)
                return GetInteger(number / 1000000) + "Millions " + GetInteger(number % 1000000);
            else if (number <= 1999999999)
                return "One Billion " + GetInteger(number % 1000000000);
            else
                return GetInteger(number / 1000000000) + "Billions " + GetInteger(number % 1000000000);
        }

        /// <summary>
        /// Method for counting a fractional part.
        /// </summary>
        /// <param name="number">Fractional part.</param>
        /// <returns>Inscription by word.</returns>
        public string GetRemainder(int number)
        {
            if (number == 0)
                return " ";
            else if (number <= 19)
                return (new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
         "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
         "Seventeen", "Eighteen", "Nineteen"}[number - 1] + " Cents");
            else
                return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
         "Eighty", "Ninety"}[number / 10 - 2] + " " + GetRemainder(number % 10);
        }

        #endregion
    }
}

