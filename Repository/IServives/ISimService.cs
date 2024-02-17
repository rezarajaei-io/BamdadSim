using Repository.DTO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Repository.IServives
{
    public interface ISimService
    {

        IEnumerable<GridSimCardViewModel> GetSims();

        List<SelectListItem> GetSenderNumbers(int personId);
        List<SelectListItem> GetReciverNumbers(int personId);
        List<SelectListItem> GetSimcartOwnerByPersonId(int personId);
        void UpdateSim(SimCardViewModel sim);
        void DeleteSim(int Id);
        int AddSim(SimCardViewModel sim);
        bool IsExistSim(string simnumber);

        bool IsSimCredit(int Id);
        bool IsAllSimCredit(List<int> allsimId);

        bool IsSimActive(int Id);

        decimal GetSimBalance(int Id);
        int GetSimIdByPersonId(int personid);
        int GetSimIdByNumber(string number);
        string GetSimNumberIdBySimId(int simid);
        bool BuySim(int simId, int personId);
        List<int> GetAllSimIdByPersonId(int personid);

        List<int> GetAllNoOwnerSimIds();


        IEnumerable<BuySimViewModel> GetBuySimCardsList(List<int> NoOwnerSimIds);
    }
}
