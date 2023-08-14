using HospitalCrud.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalCrud.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Paciente> Pacientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PacienteMap());

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Pacientes");
            });


            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
