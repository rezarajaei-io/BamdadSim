﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BamdadSimEntities : DbContext
    {
        public BamdadSimEntities()
            : base("name=BamdadSimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Sms> Sms { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<Tariff> Tariff { get; set; }
        public virtual DbSet<ChargeSim> ChargeSim { get; set; }
        public virtual DbSet<SimReceipt> SimReceipt { get; set; }
        public virtual DbSet<Call> Call { get; set; }
        public virtual DbSet<Simcard> Simcard { get; set; }
    }
}
