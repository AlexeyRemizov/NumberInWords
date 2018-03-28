using System;

namespace CashBillInAction.Currency
{
    /// <summary>
    /// Implementation for Ukrainian language.
    /// </summary>
    public class UkrCurrency : ICurrency
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
            {
                if (number < 0)
                {
                    throw new Exception(ErrorMessage);
                }
                if (number == 0)
                    return "";
                else if (number <= 19)
                    return new string[] {"Один", "Два", "Три", "Чотири", "П`ять", "Шiсть", "Сiм", "Вісім",
         "Девять", "Десять", "Одиннадцать", "Дванадцять", "Тринадцять", "Чотирнадцять", "П`ятнадцять", "Шістнадцять",
         "сімнадцять", "вісімнадцять", "дев'ятнадцять"}[number - 1] + " ";
                else if (number <= 99)
                    return new string[] {"Двадцять", "Тридцять", "Сорок", "П`ятдесят", "Шістдесят", "Сімдесят",
         "Вісімдесят", "Дев'яносто"}[number / 10 - 2] + " " + GetInteger(number % 10);
                else if (number <= 199)
                    return "Одна Сотня " + GetInteger(number % 100);
                else if (number <= 999)
                    return GetInteger(number / 100) + "Сотнi " + GetInteger(number % 100);
                else if (number <= 1999)
                    return "Одна Тисяча " + GetInteger(number % 1000);
                else if (number <= 999999)
                    return GetInteger(number / 1000) + "Тисячi " + GetInteger(number % 1000);
                else if (number <= 1999999)
                    return "Один Мільйон " + GetInteger(number % 1000000);
                else if (number <= 999999999)
                    return GetInteger(number / 1000000) + "Мільйони " + GetInteger(number % 1000000);
                else if (number <= 1999999999)
                    return "Один Мільярд " + GetInteger(number % 1000000000);
                else
                    return GetInteger(number / 1000000000) + "Мільярди " + GetInteger(number % 1000000000);
            }
        }

        /// <summary>
        /// Method for counting a fractional part.
        /// </summary>
        /// <param name="number">Fractional part.</param>
        /// <returns>Inscription by word.</returns>
        public string GetRemainder(int number)
        {
            if (number == 0)
                return "";
            else if (number <= 19)
                return new string[] {"Один", "Два", "Три", "Чотири", "П`ять", "Шiсть", "Сiм", "Вісім",
         "Девять", "Десять", "Одиннадцать", "Дванадцять", "Тринадцять", "Чотирнадцять", "П`ятнадцять", "Шістнадцять",
         "сімнадцять", "вісімнадцять", "дев'ятнадцять"}[number - 1] + " Копiйок";
            else
                return new string[] {"Двадцять", "Тридцять", "Сорок", "П`ятдесят", "Шістдесят", "Сімдесят",
         "Вісімдесят", "Дев'яносто"}[number / 10 - 2] + " " + GetRemainder(number % 10);
        }

        #endregion
    }
}

