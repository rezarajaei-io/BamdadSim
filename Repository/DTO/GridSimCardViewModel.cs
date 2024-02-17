using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class GridSimCardViewModel : SimCardViewModel
    {
        [Display(Name = "مالک")]
        public string UserName { get; set; }
    }
}
