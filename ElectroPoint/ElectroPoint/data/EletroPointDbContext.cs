using ElectroPoint.data.Mappings;
using ElectroPoint.Models;
using Microsoft.EntityFrameworkCore;

public class EletroPointDbContext : DbContext
{
    public DbSet<AdminModel> Admins { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<CarrinhoModel> Carts { get; set; }
    public DbSet<EletronicosModel> Electronics { get; set; }
    public DbSet<MarcaModel> Marks { get; set; }

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