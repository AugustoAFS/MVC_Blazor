using ElectroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroPoint.data.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<CarrinhoModel>
    {
        public void Configure(EntityTypeBuilder<CarrinhoModel> builder)
        {
            builder.ToTable("Carrinho");

            builder.HasKey(a => a.Id_carrinho);

            builder.Property(a => a.Id_carrinho)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Itens)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(a => a.Quantidade)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(a => a.Status)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Hora_da_cricao)
                .HasColumnType("datetime2")
                .HasPrecision(0);
           
            builder.HasOne(c => c.Usuario)
                .WithMany(u => u.Carrinhos)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}