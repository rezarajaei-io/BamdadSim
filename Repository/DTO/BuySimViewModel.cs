using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class BuySimViewModel
    {


        [Display(Name = "شماره سیم کارت")]

        public string SimNumber { get; set; }
        [Display(Name = "نوع سیمکارت")]

        public string SimType { get; set; }
        [Display(Name = "قیمت سیم کارت")]

        public decimal Price { get; set; }
    }
}
