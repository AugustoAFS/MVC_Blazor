using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EletroPoint.Models;

namespace EletroPoint.data.Mappings
{
    public class AdminMapping : IEntityTypeConfiguration<AdminModel>
    {
        public void Configure(EntityTypeBuilder<AdminModel> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(a => a.Id_admin);

            builder.Property(a => a.Id_admin)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Nome)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(a => a.Cpf)
                .HasColumnType("decimal(11,0)")
                .IsRequired();

            builder.Property(a => a.Email)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(a => a.Funcao)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(a => a.Status)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
