using Microsoft.EntityFrameworkCore;
using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Extensions;

namespace PiensaPeru.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person>? People { get; set; }
        public DbSet<Supervisor>? Supervisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person Entity
            modelBuilder.Entity<Person>().ToTable("People");

            // Constraints
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().HasDiscriminator(p => p.PersonType);
            modelBuilder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            // Supervisor Constraints
            modelBuilder.Entity<Supervisor>().Property(s => s.Email).IsRequired();
            modelBuilder.Entity<Supervisor>().Property(s => s.Password).IsRequired();

            // Supervisor Seed Data

            modelBuilder.Entity<Supervisor>().HasData
                (
                    new Supervisor
                    {
                        Id = 100,
                        FirstName = "José",
                        LastName = "Quispe",
                        Email = "jose.quispe@gmail.com",
                        Password = "password123"
                    },

                    new Supervisor
                    {
                        Id = 101,
                        FirstName = "Olga",
                        LastName = "Pérez",
                        Email = "olga.perez@gmail.com",
                        Password = "password123"
                    }
                );

            // Relationships


            modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}
