using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class ShowChargesVIewModel
    {
        public int ChargeId { get; set; }
        [Display(Name = "قیمت شارژ")]

        public decimal ChargePrice { get; set; }
        [Display(Name = "شارژ فعال است؟")]

        public bool Status { get; set; }

    }
}
