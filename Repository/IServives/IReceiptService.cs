using Repository.DTO;
using System;
using System.Collections.Generic;

namespace Repository.IServives
{
    public interface IReceiptService
    {
        // decimal GetReceipt(int simId);
        IEnumerable<ShowReceiptViewModel> GetReceipt(int personId, List<int> allSimId);

        int PayReceipt(decimal price, int simId, DateTime time);



    }
}
