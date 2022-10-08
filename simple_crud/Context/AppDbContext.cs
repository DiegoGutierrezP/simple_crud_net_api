using Microsoft.EntityFrameworkCore;
using simple_crud.Models;

namespace simple_crud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estudiante>()
           .HasOne(p => p.colegio)
           .WithMany(b => b.estudiantes)
           .HasForeignKey(p => p.colegioId);
        }

        public DbSet<Colegio> colegio { get; set; }
        public DbSet<Estudiante> estudiante { get; set; }
    }
}
