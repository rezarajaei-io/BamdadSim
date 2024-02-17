using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class AdminCallViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان تماس ")]

        public string Title { get; set; }
        [Display(Name = "مدت زمان تماس")]

        public int CallDuration { get; set; }


        [Display(Name = "شماره برقرار کننده تماس ")]

        public string SenderNumber { get; set; }


        [Display(Name = "شماره  گیرنده تماس")]

        public string ReciverNumber { get; set; }
        [Display(Name = "زمان تماس")]

        public DateTime Time { get; set; }
    }
}
