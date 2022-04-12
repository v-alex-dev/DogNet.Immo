using DogNet.Immo.Data.Providers.Sql.Models;
using Microsoft.EntityFrameworkCore;

namespace DogNet.Immo.Data.Providers.Sql
{
    public class DogNetImmoDbContext : DbContext
    {
        public DogNetImmoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Realty> Realties { get; set; }
        public DbSet<RealtyType> RealtyTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RealtyUser> RealtiesUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

    }
}
