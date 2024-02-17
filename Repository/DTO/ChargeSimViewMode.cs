using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    class ChargeSimViewMode
    {
        [Display(Name = "قیمت شارژ ")]

        public decimal ChargePrice { get; set; }
        [Display(Name = "شماره تلفن")]

        public string PhoneNumber { get; set; }

    }
}
