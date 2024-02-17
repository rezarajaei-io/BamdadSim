using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class ShowAccountViewModel
    {

        public int Id { get; set; }
        [Display(Name = "ایمیل")]

        public string Email { get; set; }
        [Display(Name = "پسورد")]

        public string Password { get; set; }
        [Display(Name = "آیدی نقش")]

        public int RoleId { get; set; }
    }
}
