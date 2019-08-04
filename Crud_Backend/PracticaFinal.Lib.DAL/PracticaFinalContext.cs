using Microsoft.EntityFrameworkCore;
using PracticaFinal.Lib.Core;
using PracticaFinal.Lib.Models;
using PracticaFinal.Lib.Models.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaFinal.Lib.DAL
{
   public class PracticaFinalContext : DbContext
    {
        public PracticaFinalContext(DbContextOptions<PracticaFinalContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Furgo> Furgos { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
