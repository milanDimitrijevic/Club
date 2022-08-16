using Clubv1._3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace clubv1._3.Database
{
    public class ClubDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Renting> Rents { get; set; }

        public ClubDbContext(DbContextOptions options) : base(options)
        {

        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}