﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Lamarque_ciudad
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DB_A2A1B8_netbd1Entities : DbContext
{
    public DB_A2A1B8_netbd1Entities()
        : base("name=DB_A2A1B8_netbd1Entities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<complain_bd> complain_bd { get; set; }

    public virtual DbSet<map> map { get; set; }

    public virtual DbSet<people_bd> people_bd { get; set; }

    public virtual DbSet<sug> sug { get; set; }

    public virtual DbSet<eventos_bd> eventos_bd { get; set; }

        public System.Data.Entity.DbSet<Lamarque_ciudad.Models.contacto_bd> contacto_bd { get; set; }

        public System.Data.Entity.DbSet<Lamarque_ciudad.Models.usuarios_bd> usuarios_bd { get; set; }

        public System.Data.Entity.DbSet<Lamarque_ciudad.Models.servicios_bd> servicios_bd { get; set; }
    }

}

