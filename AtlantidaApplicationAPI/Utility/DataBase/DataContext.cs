using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AGENCIA> AGENCIA { get; set; }
        public DbSet<CARGO> CARGO { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<CLIENTEXPRODUCTO> CLIENTEXPRODUCTO { get; set; }
        public DbSet<EJECUTIVO> EJECUTIVO { get; set; }
        public DbSet<PERSONA> PERSONA { get; set; }
        public DbSet<PRODUCTO> PRODUCTO { get; set; }
        public DbSet<TIPOTRANSACCION> TIPOTRANSACCION { get; set; }
        public DbSet<TRANSACCION> TRANSACCION { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AGENCIA>().ToTable("AGENCIA").HasKey(p => new { p.id });
            modelBuilder.Entity<CARGO>().ToTable("CARGO").HasKey(p => new { p.id });
            modelBuilder.Entity<CLIENTE>().ToTable("CLIENTE").HasKey(p => new { p.id });
            modelBuilder.Entity<CLIENTEXPRODUCTO>().ToTable("CLIENTEXPRODUCTO").HasKey(p => new { p.id });
            modelBuilder.Entity<EJECUTIVO>().ToTable("EJECUTIVO").HasKey(p => new { p.id });
            modelBuilder.Entity<PERSONA>().ToTable("PERSONA").HasKey(p => new { p.id });
            modelBuilder.Entity<PRODUCTO>().ToTable("PRODUCTO").HasKey(p => new { p.id });
            modelBuilder.Entity<TIPOTRANSACCION>().ToTable("TIPOTRANSACCION").HasKey(p => new { p.id });
            modelBuilder.Entity<TRANSACCION>().ToTable("TRANSACCION").HasKey(p => new { p.id });
        }
    }
}
