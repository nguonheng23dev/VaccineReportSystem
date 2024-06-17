using Microsoft.EntityFrameworkCore;
using VaccineReportSystem.Models;

namespace VaccineReportSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VaccineCard> VaccineCards { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VaccineCard>().HasData(
                new VaccineCard { VaccineCardId = 1, CardType = "MOH" },
                new VaccineCard { VaccineCardId = 2, CardType = "MOD" }
            );

            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceId = 1, Name = "Phnom Penh" },
                new Province { ProvinceId = 2, Name = "Kandal" },
                new Province { ProvinceId = 3, Name = "Pursat" }
            );

            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { VisitorId = 1, Name = "Visitor 1", Doses = 5, ProvinceId = 1, VaccineCardId = 1 },
                new Visitor { VisitorId = 2, Name = "Visitor 2", Doses = 5, ProvinceId = 1, VaccineCardId = 2 },
                new Visitor { VisitorId = 3, Name = "Visitor 3", Doses = 1, ProvinceId = 2, VaccineCardId = 1 },
                new Visitor { VisitorId = 4, Name = "Visitor 4", Doses = 1, ProvinceId = 2, VaccineCardId = 1 },
                new Visitor { VisitorId = 5, Name = "Visitor 5", Doses = 3, ProvinceId = 3, VaccineCardId = 1 },
                new Visitor { VisitorId = 6, Name = "Visitor 6", Doses = 3, ProvinceId = 3, VaccineCardId = 2 }
            );
        }
    }
}
