using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Repository.DTO
{
    public class ShowReceiptViewModel
    {

        [HiddenInput(DisplayValue = false)]
        public int SimId { get; set; }
        [Display(Name = "سیم کارت")]
        public string SimCart { get; set; }

        [Display(Name = "مبلغ بدهی")]
        public decimal Price { get; set; }
        [Display(Name = "مالک")]
        public string Owner { get; set; }


    }
}
