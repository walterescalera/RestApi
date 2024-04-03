using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Contents
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build()
                .GetSection("ConnectionStrings")["LocalDbConnection"];

            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Person>().HasKey(u => u.PersonId);
            modelBuilder.Entity<Person>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Person>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<Person>().Property(u => u.Cuil).IsRequired();
            modelBuilder.Entity<Person>().Property(u => u.Gender).IsRequired();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}

