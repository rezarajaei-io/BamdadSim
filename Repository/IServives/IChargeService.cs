using Repository.DTO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Repository.IServives
{
    public interface IChargeService
    {
        List<SelectListItem> ShowCharges();

        int ChargeSim(int simId, int chargeId);

        decimal GetChargePriceByChargeId(int chargeId);

        bool UpdateChargeStatus(int chargeId);

        IEnumerable<ShowChargesVIewModel> GetCharges();
        IEnumerable<ShowChargesVIewModel> GetChargesLog();
        void UpdateCharge(ShowChargesVIewModel charge);
        void DeleteCharge(int Id);
        int AddCharge(ShowChargesVIewModel charge);

    }
}
