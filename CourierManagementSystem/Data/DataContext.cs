using CourierManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
