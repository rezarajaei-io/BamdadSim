//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SimReceipt
    {
        public int ReceiptId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public int SimId { get; set; }
    
        public virtual Simcard Simcard { get; set; }
    }
}
