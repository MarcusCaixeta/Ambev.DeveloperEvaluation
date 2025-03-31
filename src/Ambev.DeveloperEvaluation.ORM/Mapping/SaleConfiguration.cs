using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber)
               .IsRequired()
               .HasMaxLength(20)
               .ValueGeneratedOnAdd() 
               .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasIndex(s => s.SaleNumber)
               .IsUnique();

            builder.Property(s => s.CustomerId)
               .IsRequired();

            builder.Property(s => s.CompanyBranchId)
                   .IsRequired();
        }
    }
}
