namespace CashBillInAction.Currency
{
    /// <summary>
    /// Currency interface.
    /// </summary>
    public interface ICurrency
    {
        /// <summary>
        /// Method for counting the whole part.
        /// </summary>
        /// <param name="number">Whole part.</param>
        /// <returns>Inscription by word.</returns>
        string GetInteger(int number);

        /// <summary>
        /// Method for counting a fractional part.
        /// </summary>
        /// <param name="number">Fractional part.</param>
        /// <returns>Inscription by word.</returns>
        string GetRemainder(int number);
    }
}

