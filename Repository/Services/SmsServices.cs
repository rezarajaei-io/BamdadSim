using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Services
{
    public class SmsServices : ISmsService
    {

        public DataLayer.Models.BamdadSimEntities _dbContext;
        public SmsServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }
        public int AddSms(SmsViewModel smvm, int SenderId, int ReciverId)
        {
            Sms sms = new Sms()
            {

                SmsTitle = smvm.Title,
                SmsContent = smvm.Content,
                Time = DateTime.Now,
                SenderId = SenderId,
                ReciverId = ReciverId

            };
            _dbContext.Sms.Add(sms);
            _dbContext.SaveChanges();
            return sms.SmsId;
        }


        public IEnumerable<SmsViewModel> ShowUserSmsList(List<int> SenderAllSimId)
        {

            var showsms = _dbContext.Sms.Where(s => SenderAllSimId.Contains(s.SenderId) || SenderAllSimId.Contains(s.ReciverId)).Select(p => new DTO.SmsViewModel()
            {
                Title = p.SmsTitle,
                Content = p.SmsContent,
                Sender = _dbContext.Simcard.Where(n => n.SimId == p.SenderId).FirstOrDefault().Number,
                Reciver = _dbContext.Simcard.Where(n => n.SimId == p.ReciverId).FirstOrDefault().Number,
                Time = p.Time
            });

            return showsms;


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


        public decimal GetSmsTariff()
        {
            return (decimal)_dbContext.Tariff.SingleOrDefault(p => p.TariffId == 1).SmsTarrif;
        }

        public void UpdateTariff(decimal calltarrif, decimal smstarrif)
        {

            var entity = _dbContext.Tariff.FirstOrDefault(t => t.TariffId == 1);
            if (entity != null)
            {
                _dbContext.Entry(entity).Property(e => e.CallTariff).CurrentValue = calltarrif;
                _dbContext.Entry(entity).Property(e => e.SmsTarrif).CurrentValue = smstarrif;
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<AdminSmsViewModel> GetAllSms()
        {
            var showsms = _dbContext.Sms.Select(p => new DTO.AdminSmsViewModel()
            {
                Id = p.SmsId,
                Title = p.SmsTitle,
                Content = p.SmsContent,
                SenderNumber = p.Simcard.Number,
                ReciverNumber = p.Simcard.Number,
                Time = p.Time

            });
            return showsms;
        }



        public void DeleteSms(int Id)
        {
            var p = _dbContext.Sms.Find(Id);
            _dbContext.Sms.Remove(p);
            _dbContext.SaveChanges();
        }

        public void UpdateSms(AdminSmsViewModel sm)
        {
            var s = _dbContext.Sms.Find(sm.Id);
            s.SmsTitle = sm.Title;
            s.SmsContent = sm.Content;
            s.SenderId = _dbContext.Simcard.First(p => p.Number == sm.SenderNumber).SimId;
            s.ReciverId = _dbContext.Simcard.First(p => p.Number == sm.ReciverNumber).SimId;

            s.Time = sm.Time;


            _dbContext.SaveChanges();
        }
    }
}
