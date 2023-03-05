using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DataAccess.SharedConstants;

namespace DataAccess.Configuration
{
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
                .ToTable(Owners);

            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(o => o.RealEstates)
                .WithOne(r => r.Owner)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(p => p.MiddleName)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(p => p.Birthday)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
