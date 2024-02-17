using System.ComponentModel.DataAnnotations;

namespace Repository.DTO
{
    public class RoleViewModel
    {
        [Display(Name = "آیدی نقش")]

        public int RoleId { get; set; }
        [Display(Name = "نام نقش")]

        public string RoleName { get; set; }
    }
}
