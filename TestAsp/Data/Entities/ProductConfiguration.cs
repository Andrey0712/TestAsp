using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestAsp.Data.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<AppProduct>
    {
        public void Configure(EntityTypeBuilder<AppProduct> builder)
        {
            builder.ToTable("tblProducts");
            builder.HasKey(keys => new { keys.Id });

            builder.Property(nameItems => nameItems.Name)
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(descItems => descItems.Description)
                .HasMaxLength(4000)
                .IsRequired(true);
        }
    }
}
