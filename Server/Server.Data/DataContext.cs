using Microsoft.EntityFrameworkCore;
using Server.Core.Models;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employeeDB");
           // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employeeDb",
             //                              x => x.UseDateOnlyTimeOnly());
        }
    }
}
