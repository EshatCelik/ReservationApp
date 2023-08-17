using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Core.Repository.InMemory
{
    public class InMemoryDBContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("exampleDatabase");
        }



        public DbSet<Entity.Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
