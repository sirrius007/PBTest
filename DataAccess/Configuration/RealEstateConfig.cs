using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static DataAccess.SharedConstants;

namespace DataAccess.Configuration;

public class RealEstateConfig : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.ToTable(RealEstates);

        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Owner)
            .WithMany(p => p.RealEstates);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(p => p.Cost)
            .IsRequired()
            .HasPrecision(14, 2);
    }
}