using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class SimCardViewModel
    {

        public int Id { get; set; }
        [Display(Name = "شماره سیم کارت")]
        public string Number { get; set; }
        [Display(Name = "آیدی شخص")]

        [Required(AllowEmptyStrings = true)]

        public int PersonId { get; set; }
        [Display(Name = " سیم کارت فعال است؟")]

        public bool SimActive { get; set; }
        [Display(Name = "سیم کارت اعتباری است؟")]

        public bool SimType { get; set; }
        [Display(Name = "شارژ یا بدهی سیمکارت")]

        public decimal Simbalance { get; set; }

        

    }
}
