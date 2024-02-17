using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class AdminSmsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان پیام ")]

        public string Title { get; set; }
        [Display(Name = "محتوای پیام")]

        public string Content { get; set; }


        [Display(Name = "شماره فرستنده")]

        public string SenderNumber { get; set; }


        [Display(Name = "شمارنده گیرنده")]

        public string ReciverNumber { get; set; }
        [Display(Name = "زمان ارسال")]

        [DisplayFormat(DataFormatString = "{0: HH:mm, dd MMMM yyyy}")]
        [UIHint("PersianDatePicker")]

        public DateTime Time { get; set; }
    }
}
