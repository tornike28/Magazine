using Domain;
using Infrastructure.Confingurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class MagazineDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Magazines");

            builder.ApplyConfiguration(new PersonTypeConfiguration());
            builder.ApplyConfiguration(new SubjectTypeConfiguration());
            builder.ApplyConfiguration(new PersonSubjectTypeConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseNpgsql("server=localhost;Database=Magazines;User Id=postgres;Password=TokoToko12");
        }
    }
}
