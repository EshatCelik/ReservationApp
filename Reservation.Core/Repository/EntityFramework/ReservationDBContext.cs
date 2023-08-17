using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entity;

namespace Reservation.Core.Repository.EntityFramework
{
    public class ReservationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ESHAT-CELIK\SQLEXPRESS;database=uMeet;Trusted_Connection=True");
        }


        public DbSet<Entity.Reservation> Reservations { get; set; } 
        public DbSet<Table> Tables { get; set; } 
    }
}
