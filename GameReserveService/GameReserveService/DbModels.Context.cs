﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameReserveService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class game_reserveEntities : DbContext
    {
        public game_reserveEntities()
            : base("name=game_reserveEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<animal> animals { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<gpstracking> gpstrackings { get; set; }
    }
}