using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class SmsViewModel
    {

        [Display(Name = "عنوان پیام ")]

        public string Title { get; set; }
        [Display(Name = "محتوای پیام")]

        public string Content { get; set; }


        [Display(Name = "ارسال با سیم کارت")]

        public string Sender { get; set; }


        [Display(Name = "شماره تلفن گیرنده")]

        public string Reciver { get; set; }
        [Display(Name = "زمان ارسال")]

        public DateTime Time { get; set; }
    }
}
