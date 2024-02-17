using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class CallsViewModel
    {


        [Display(Name = "عنوان تماس ")]

        public string Title { get; set; }
        [Display(Name = "مدت زمان تماس")]

        public int CallDuration { get; set; }


        [Display(Name = "شماره تلفن مبدا تماس")]

        public string Sender { get; set; }


        [Display(Name = "شماره تلفن گیرنده تماس")]

        public string Reciver { get; set; }
        [Display(Name = "زمان تماس")]

        public DateTime Time { get; set; }
    }
}
