using DataLayer.Models;
using Mapster;
using Repository.DTO;
using Repository.IServives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Repository.Services
{
    public class ChargeServices : IChargeService
    {
        public DataLayer.Models.BamdadSimEntities _dbContext;
       
       public ChargeServices(BamdadSimEntities context)
        {
            _dbContext = context;
          //  _mapper = mapper;
        }

        public int AddCharge(ShowChargesVIewModel charge)
        {
            Charge chg = new Charge()
            {
                ChargeId = charge.ChargeId,
                ChargePrice = charge.ChargePrice,
                ChargeStatus = charge.Status

            };

            _dbContext.Charge.Add(chg);
            _dbContext.SaveChanges();
            return charge.ChargeId;
        }

        public int ChargeSim(int simId, int chargeId)
        {
            ChargeSim chs = new ChargeSim()
            {
                ChargeId = chargeId,
                SimId = simId,

            };
            _dbContext.ChargeSim.Add(chs);
            _dbContext.SaveChanges();

            return 1;
        }

        public void DeleteCharge(int Id)
        {
            var p = _dbContext.Charge.Find(Id);
            _dbContext.Charge.Remove(p);
            _dbContext.SaveChanges();
        }

        public decimal GetChargePriceByChargeId(int chargeId)
        {
            return (decimal)_dbContext.Charge.FirstOrDefault(i => i.ChargeId == chargeId).ChargePrice;
        }

        public IEnumerable<ShowChargesVIewModel> GetCharges()
        {
            var chargelist = _dbContext.Charge.Select(c => c).ProjectToType<ShowChargesVIewModel>();

            return chargelist;

        }

        public IEnumerable<ShowChargesVIewModel> GetChargesLog()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> ShowCharges()
        {


            return _dbContext.Charge.Where(s => s.ChargeStatus == true)
               .Select(c => new SelectListItem()
               {
                   Text = c.ChargePrice.ToString(),
                   Value = c.ChargeId.ToString()
               }).ToList();

        }

        public void UpdateCharge(ShowChargesVIewModel charge)
        {
            var p = _dbContext.Charge.Find(charge.ChargeId);
            p.ChargeId = charge.ChargeId;
            p.ChargePrice = charge.ChargePrice;
            p.ChargeStatus = charge.Status;


            _dbContext.SaveChanges();
        }

        public bool UpdateChargeStatus(int chargeId)
        {
            var entity = _dbContext.Charge.FirstOrDefault(e => e.ChargeId == chargeId);
            if (entity != null)
            {
                _dbContext.Entry(entity).Property(e => e.ChargeStatus).CurrentValue = false;
                _dbContext.SaveChanges();
            }
            return true;
        }
    }
}
