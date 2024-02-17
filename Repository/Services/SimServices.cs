using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Repository.Services
{
    public class SimServices : ISimService
    {

        public DataLayer.Models.BamdadSimEntities _dbContext;

        public SimServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }

        public int AddSim(SimCardViewModel sim)
        {
            Simcard simcard = new Simcard()
            {
                Number = sim.Number,
                SimActive = sim.SimActive,
                Type = sim.SimType,
                SimBalance = sim.Simbalance,
                PersonId = sim.PersonId

            };
            _dbContext.Simcard.Add(simcard);
            _dbContext.SaveChanges();
            return simcard.SimId;
        }

        public void DeleteSim(int Id)
        {
            var p = _dbContext.Simcard.Find(Id);
            _dbContext.Simcard.Remove(p);
            _dbContext.SaveChanges();
        }



        public int GetSimIdByPersonId(int personid)
        {
            return _dbContext.Simcard.FirstOrDefault(s => s.PersonId == personid).SimId;

        }

        public IEnumerable<GridSimCardViewModel> GetSims()
        {
            var showsims = _dbContext.Simcard.Select(s => new DTO.GridSimCardViewModel()
            {

                Id = s.SimId,
                Number = s.Number,
                //PersonId = s.PersonId ?? 0,
                UserName = s.Person.Name,
                SimActive = s.SimActive,
                SimType = s.Type,
                Simbalance = s.SimBalance

            });
            return showsims;
        }

        public bool IsExistSim(string simnumber)
        {
            return _dbContext.Simcard.Any(u => u.Number == simnumber);
        }

        public bool IsSimActive(int Id)
        {
            return _dbContext.Simcard.FirstOrDefault(i => i.SimId == Id).SimActive;

        }

        public bool IsSimCredit(int Id)
        {
            return _dbContext.Simcard.SingleOrDefault(i => i.SimId == Id).Type;

        }


        // This Check List Of SimCarts there UserOwned Type Permanet => false and Credit => True
        public bool IsAllSimCredit(List<int> allsimId)
        {
            return _dbContext.Simcard.FirstOrDefault(i => allsimId.Contains(i.SimId)).Type;

        }
        public decimal GetSimBalance(int Id)
        {
            return _dbContext.Simcard.SingleOrDefault(i => i.SimId == Id).SimBalance;
        }

        public void UpdateSim(SimCardViewModel sim)
        {
            var s = _dbContext.Simcard.Find(sim.Id);
            s.Number = sim.Number;
            s.SimActive = sim.SimActive;
            s.Type = sim.SimType;
            s.SimBalance = sim.Simbalance;
            s.PersonId = sim.PersonId;



            _dbContext.SaveChanges();
        }

        public List<SelectListItem> GetSenderNumbers(int personId)
        {
            return _dbContext.Simcard.Where(s => s.PersonId == personId)
              .Select(c => new SelectListItem()
              {
                  Text = c.Number,
                  Value = c.SimId.ToString()
              }).ToList();
        }

        public List<int> GetAllSimIdByPersonId(int personid)
        {
            return _dbContext.Simcard.Where(s => s.PersonId == personid).Select(s => s.SimId).ToList();
        }

        public List<int> GetAllNoOwnerSimIds()
        {
            return _dbContext.Simcard.Where(s => s.PersonId == null).Select(s => s.SimId).ToList();

        }

        public IEnumerable<BuySimViewModel> GetBuySimCardsList(List<int> NoOwnerSimIds)
        {

            var showreceiptk = _dbContext.Simcard.Where(s => NoOwnerSimIds.Contains(s.SimId)).Select(p => new DTO.BuySimViewModel()
            {

                SimNumber = p.Number,
                Price = (decimal)p.SimPrice,
                SimType = p.Type.ToString()
            });
            return showreceiptk;

        }

        public int GetSimIdByNumber(string number)
        {
            return _dbContext.Simcard.SingleOrDefault(n => n.Number == number).SimId;
        }


        public bool BuySim(int simId, int personId)
        {
            var entity = _dbContext.Simcard.FirstOrDefault(e => e.SimId == simId);
            if (entity != null)
            {
                _dbContext.Entry(entity).Property(e => e.PersonId).CurrentValue = personId;
                _dbContext.SaveChanges();
            }
            return true;
        }

        public List<SelectListItem> GetReciverNumbers(int personId)
        {
            return _dbContext.Simcard.Where(s => s.PersonId != personId && s.PersonId != null)
              .Select(c => new SelectListItem()
              {
                  Text = c.Number,
                  Value = c.SimId.ToString()
              }).ToList();
        }

        public string GetSimNumberIdBySimId(int simid)
        {
            return _dbContext.Simcard.SingleOrDefault(n => n.SimId == simid).Number;

        }

        public List<SelectListItem> GetSimcartOwnerByPersonId(int personId)
        {
            return _dbContext.Person
            .Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.PersonId.ToString()
            }).ToList();
        }
    }
}
