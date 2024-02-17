using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "فیلد ایمیل مورد نمیتواند خالی باشد")]

        public string Email { get; set; }
        [Display(Name = "پسورد")]
        [Required(ErrorMessage = "فیلد پسورد مورد نمیتواند خالی باشد")]


        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]

        public bool RememberMe { get; set; }
    }
}
