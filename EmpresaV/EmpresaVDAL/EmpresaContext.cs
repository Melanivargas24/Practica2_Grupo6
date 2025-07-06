using EmpresaVObjetos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace EmpresaVDAL;

public partial class EmpresaContext : DbContext
{
    public EmpresaContext(DbContextOptions<EmpresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<Telefono> Telefono { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasMany(c => c.Telefonos)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
