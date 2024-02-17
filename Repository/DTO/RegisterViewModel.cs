using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class RegisterViewModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "جنسیت")]

        public bool Gender { get; set; }
        [Display(Name = "آدرس")]

        public string Address { get; set; }
        [Display(Name = "ایمیل")]

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]

        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "کلمه عبور ضعیف است")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
