using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        {
        }

        public DbSet<AppUser> Users {get; set;}
        public DbSet<Unit> Units {get; set;}
        public DbSet<UnitType> UnitType {get; set;}
    }
}