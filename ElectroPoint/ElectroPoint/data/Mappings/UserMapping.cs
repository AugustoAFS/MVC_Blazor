using ElectroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroPoint.data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(a => a.Id_user);

            builder.Property(a => a.Nome)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(a => a.Cpf)
                .HasColumnType("decimal(11,0)");

            builder.Property(a => a.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(a => a.Senha)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(a => a.Funcao)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(a => a.Status)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasMany(u => u.Carrinhos)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.Id_carrinho)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
