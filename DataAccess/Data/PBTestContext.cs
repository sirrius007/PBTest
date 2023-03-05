using DataAccess.Configuration;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class PBTestContext : DbContext
{
    public PBTestContext(DbContextOptions<PBTestContext> options) : base(options)
    {
    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<RealEstate> RealEstates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OwnerConfig());
        modelBuilder.ApplyConfiguration(new RealEstateConfig());

        modelBuilder.Entity<Owner>().HasData(
            new Owner { Id = 1, FirstName = "Іван", MiddleName = "Сергійович", LastName = "Іваненко", Birthday = new DateTime(1980, 4, 5) },
            new Owner { Id = 2, FirstName = "Андрій", MiddleName = "Петрович", LastName = "Садовий", Birthday = new DateTime(1985, 7, 3) },
            new Owner { Id = 3, FirstName = "Петро", MiddleName = "Валерійович", LastName = "Гриценко", Birthday = new DateTime(1962, 11, 20) },
            new Owner { Id = 4, FirstName = "Ірина", MiddleName = "Валентинівна", LastName = "Кучор", Birthday = new DateTime(1992, 1, 15) },
            new Owner { Id = 5, FirstName = "Оля", MiddleName = "Володимирів", LastName = "Іваненко", Birthday = new DateTime(1980, 4, 5) },
            new Owner { Id = 6, FirstName = "Василина", MiddleName = "Володимирівна", LastName = "Зінченко", Birthday = new DateTime(1982, 5, 5) }
        );

        modelBuilder.Entity<RealEstate>().HasData(
           new RealEstate { Id = 1, Name = "Avalon Number 1", Address = "Ukraine, Ternopil, str. Dovjenka 10/2", Cost = 40000, OwnerId = 1 },
           new RealEstate { Id = 2, Name = "Avalon Number 1", Address = "Ukraine, Ternopil, str. Dovjenka 10/3", Cost = 42000, OwnerId = 1 },
           new RealEstate { Id = 3, Name = "New Britain", Address = "Ukraine, Lviv, str. Freedom 5/25", Cost = 50000, OwnerId = 2 },
           new RealEstate { Id = 4, Name = "Holland", Address = "Ukraine, Kyiv, str. Central 31/7", Cost = 35000, OwnerId = 3 },
           new RealEstate { Id = 5, Name = "Sultan Palace", Address = "Ukraine, Uzhorod, str. Iv.Franka 2/6", Cost = 32000, OwnerId = 3 },
           new RealEstate { Id = 6, Name = "American Square", Address = "Ukraine, Kharkiv, str. Sumska 15/1", Cost = 41000, OwnerId = 4 },
           new RealEstate { Id = 7, Name = "Viking Building", Address = "Ukraine, Lviv, str. Zelena 11/4", Cost = 47000, OwnerId = 5 }
       );

    }
}