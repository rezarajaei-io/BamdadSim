using System;

namespace Repository.DTO
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Sum { get; set; }
        public bool IsFinaly { get; set; }
    }
}
