using ElectroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroPoint.data.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<MarcaModel>
    {
        public void Configure(EntityTypeBuilder<MarcaModel> builder)
        {
            builder.ToTable("Marcas");

            builder.HasKey(m => m.Id_marca);

            builder.Property(m => m.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Status)
                .IsRequired();
        }
    }
}
