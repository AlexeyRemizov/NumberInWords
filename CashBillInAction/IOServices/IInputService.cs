using System.Collections.Generic;

namespace CashBillInAction.IOServices
{
    /// <summary>
    /// InputService interface.
    /// </summary>
    public interface IInputService
    {
        /// <summary>
        /// Method for reading data.
        /// </summary>
        /// <returns>KeyValuePair instance.</returns>
        KeyValuePair<int, string> Readout();
    }
}

