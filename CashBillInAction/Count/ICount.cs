using System.Collections.Generic;

namespace CashBillInAction.Count
{
    public interface ICount
    {
        KeyValuePair<int, int> Validate();

        string CashBill();
    }
}

