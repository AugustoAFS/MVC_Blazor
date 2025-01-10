using ElectroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroPoint.data.Mappings
{
    public class EletronicosMapping : IEntityTypeConfiguration<EletronicosModel>
    {
        public void Configure(EntityTypeBuilder<EletronicosModel> builder)
        {
            builder.ToTable("Eletronicos");

            builder.HasKey(e => e.Id_eletronicos);

            builder.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Cor)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Descricao)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Marca)
                .WithMany()
                .HasForeignKey(e => e.MarcaId);
        }
    }
}