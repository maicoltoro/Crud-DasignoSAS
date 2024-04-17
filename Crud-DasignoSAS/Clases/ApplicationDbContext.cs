using Crud_DasignoSAS.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_DasignoSAS.Clases
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Datos");

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("PrimerNombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("SegundoNombre")
                    .HasColumnType("varchar(50)")
                    .IsRequired(false);

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("PrimerApellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("SegundoApellido")
                    .HasColumnType("varchar(50)")
                    .IsRequired(false);

                entity.Property(e => e.Sueldo)
                    .HasColumnName("Sueldo")
                    .HasColumnType("int");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FechaNacimiento")
                    .HasColumnType("Datetime");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("FechaCreacion")
                    .HasColumnType("Datetime")
                    .IsRequired(false);

                entity.Property(e => e.FechaModificacion)
                    .HasColumnName("FechaModificacion")
                    .HasColumnType("Datetime")
                    .IsRequired(false);
            });
        }
    }
}
