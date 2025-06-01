using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using library.Model;

namespace data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Adocao> Adocao { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Adocao>().ToTable("TB_ADOCAO");
            builder.Entity<Animal>().ToTable("TB_ANIMAL");
            builder.Entity<Local>().ToTable("TB_LOCAL");
            builder.Entity<Sensor>().ToTable("TB_SENSOR");
            builder.Entity<Pessoa>().ToTable("TB_PESSOA");
            builder.Entity<Report>().ToTable("TB_REPORT");

            // Corrige tipo BOOLEAN para Oracle (usa NUMBER(1))
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetColumnType("NUMBER(1)");
                    }
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(
                    "conn",
                    b => b.MigrationsAssembly("api")
                );
            }
        }
    }
}