﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace app_ciudad
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A2A1B8_lamarqueBDEntities : DbContext
    {
        public DB_A2A1B8_lamarqueBDEntities()
            : base("name=DB_A2A1B8_lamarqueBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<eventos> eventos { get; set; }
        public virtual DbSet<mapa> mapa { get; set; }
        public virtual DbSet<reclamos> reclamos { get; set; }
        public virtual DbSet<registro> registro { get; set; }
        public virtual DbSet<sugerencia> sugerencia { get; set; }
    }
}
