using EletroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroPoint.data.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<MarcaModel>
    {
        public void Configure(EntityTypeBuilder<MarcaModel> builder)
        {
            builder.ToTable("Marca");

            builder.HasKey(m => m.Id_marca);

            builder.Property(m => m.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Status)
                .IsRequired();

            builder.HasMany(m => m.Eletronicos) 
                .WithOne(e => e.Marca) 
                .HasForeignKey(e => e.MarcaId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
