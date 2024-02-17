using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class CallServices : ICallService
    {

        public DataLayer.Models.BamdadSimEntities _dbContext;
        public CallServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }
        public int AddCall(CallsViewModel calvm, int SenderId, int ReciverId)
        {
            Call cal = new Call()
            {

                CallTitle = calvm.Title,
                CallDuration = calvm.CallDuration,
                SenderId = SenderId,
                Time = DateTime.Now,
                ReciverId = ReciverId

            };
            _dbContext.Call.Add(cal);
            _dbContext.SaveChanges();
            return cal.CallId;
        }

        public void DeleteCall(int Id)
        {
            var p = _dbContext.Call.Find(Id);
            _dbContext.Call.Remove(p);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AdminCallViewModel> GetAllCalls()
        {
            var showsms = _dbContext.Call.Select(p => new DTO.AdminCallViewModel()
            {
                Id = p.CallId,
                Title = p.CallTitle,
                CallDuration = p.CallDuration,
                SenderNumber = p.Simcard.Number,
                ReciverNumber = p.Simcard.Number,
                Time = p.Time

            });
            return showsms;
        }

        public decimal GetCallTariff()
        {
            return (decimal)_dbContext.Tariff.SingleOrDefault(p => p.TariffId == 1).CallTariff;
        }

        public IEnumerable<CallsViewModel> ShowUserCallList(List<int> SenderAllSimId)
        {
            var showcall = _dbContext.Call.Where(s => SenderAllSimId.Contains(s.SenderId) || SenderAllSimId.Contains(s.ReciverId)).Select(p => new DTO.CallsViewModel()
            {
                Title = p.CallTitle,
                CallDuration = p.CallDuration,
                Sender = _dbContext.Simcard.Where(n => n.SimId == p.SenderId).FirstOrDefault().Number,
                Reciver = _dbContext.Simcard.Where(n => n.SimId == p.ReciverId).FirstOrDefault().Number,
                Time = p.Time
            });

            return showcall;
        }

        public bool UpdateBalanceById(int Id, decimal newBalance)
        {
            var entity = _dbContext.Simcard.FirstOrDefault(e => e.SimId == Id);
            if (entity != null)
            {
                _dbContext.Entry(entity).Property(e => e.SimBalance).CurrentValue = newBalance;
                _dbContext.SaveChanges();
            }
            return true;
        }

        public void UpdateCalls(AdminCallViewModel cl)
        {
            var s = _dbContext.Call.Find(cl.Id);
            s.CallTitle = cl.Title;
            s.CallDuration = cl.CallDuration;
            s.SenderId = _dbContext.Simcard.First(p => p.Number == cl.SenderNumber).SimId;
            s.ReciverId = _dbContext.Simcard.First(p => p.Number == cl.ReciverNumber).SimId;
            s.Time = cl.Time;


            _dbContext.SaveChanges();
        }

        public decimal UpdateCallTariff()
        {
            throw new NotImplementedException();
        }
    }
}
