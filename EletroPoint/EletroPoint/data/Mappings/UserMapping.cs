using EletroPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletroPoint.data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");  // Tabela renomeada para "User"

            builder.HasKey(u => u.Id_user);

            builder.Property(u => u.Nome)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(u => u.Cpf)
                .HasColumnType("decimal(11,0)");

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(u => u.Senha)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(u => u.Funcao)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(u => u.Status)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.HasMany(u => u.Carrinhos)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
