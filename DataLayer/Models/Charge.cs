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
    
    public partial class Charge
    {
        public int ChargeId { get; set; }
        public Nullable<decimal> ChargePrice { get; set; }
        public Nullable<bool> ChargeStatus { get; set; }
    
        public virtual ChargeSim ChargeSim { get; set; }
    }
}
