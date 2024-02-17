using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class ReceiptServices : IReceiptService
    {
        public DataLayer.Models.BamdadSimEntities _dbContext;

        public ReceiptServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }
        public IEnumerable<ShowReceiptViewModel> GetReceipt(int personId, List<int> allSimId)
        {
            var showreceiptk = _dbContext.Simcard.Where(s => allSimId.Contains(s.SimId) && s.Type == false && s.SimBalance < 0).Select(p => new DTO.ShowReceiptViewModel()
            {
                SimId = p.SimId,
                Price = p.SimBalance,
                Owner = _dbContext.Person.Where(n => n.PersonId == personId).FirstOrDefault().Name,
                SimCart = p.Number
            });
            return showreceiptk;
        }
        public int PayReceipt(decimal price, int simId, DateTime time)
        {

            SimReceipt pr = new SimReceipt
            {
                Price = price,
                Time = time,
                SimId = simId
            };
            _dbContext.SimReceipt.Add(pr);
            _dbContext.SaveChanges();
            return pr.ReceiptId;
        }
    }
}
