using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]

        public string Name { get; set; }

        [Display(Name = "جنسیت")]

        public bool Gender { get; set; }
        [Display(Name = "موجودی")]

        public decimal balance { get; set; }
        [Display(Name = "آدرس")]

        public string Address { get; set; }

    }
}
