using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class GridSmsViewModel : SmsViewModel
    {
        public string SenderNumber { get; set; }
        public string ReciverNumber { get; set; }
    }
}
