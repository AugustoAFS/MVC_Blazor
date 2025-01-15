using EletroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroPoint.data.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<CarrinhoModel>
    {
        public void Configure(EntityTypeBuilder<CarrinhoModel> builder)
        {
            builder.ToTable("Carrinho");  // Tabela renomeada para "Carrinho"

            builder.HasKey(c => c.Id_carrinho);

            builder.Property(c => c.Itens)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(c => c.Quantidade)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(c => c.Status)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Hora_da_cricao)
                .HasColumnType("datetime2")
                .HasPrecision(0);

            builder.HasOne(c => c.Usuario)
                .WithMany(u => u.Carrinhos)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
