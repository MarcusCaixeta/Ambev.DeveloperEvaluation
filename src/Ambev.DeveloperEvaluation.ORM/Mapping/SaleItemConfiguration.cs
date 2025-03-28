using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.ProductId)
                .IsRequired();

            builder.Property(s => s.ProductDescription)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Quantity)
                .IsRequired();

            builder.Property(s => s.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Discount)
                .HasColumnType("decimal(5,4)");

            builder.Property(s => s.IsCancelled)
                .HasDefaultValue(false);
        }
    }
}
