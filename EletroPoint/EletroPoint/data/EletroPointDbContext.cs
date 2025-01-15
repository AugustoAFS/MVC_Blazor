using EletroPoint.data.Mappings;
using EletroPoint.Models;
using Microsoft.EntityFrameworkCore;

public class EletroPointDbContext : DbContext
{
    // DbSets renomeados para serem mais consistentes com os nomes das entidades
    public DbSet<AdminModel> Admins { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<CarrinhoModel> Carrinhos { get; set; }
    public DbSet<EletronicosModel> Eletronicos { get; set; }
    public DbSet<MarcaModel> Marcas { get; set; }

    public EletroPointDbContext(DbContextOptions<EletroPointDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdminMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new CarrinhoMapping());
        modelBuilder.ApplyConfiguration(new EletronicosMapping());
        modelBuilder.ApplyConfiguration(new MarcaMapping());
    }
}
