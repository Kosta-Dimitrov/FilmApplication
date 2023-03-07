using FilmApplication.Identity;
using Microsoft.EntityFrameworkCore;
using FilmApplication.Models.Actors;
using FilmApplication.Models.Films;

namespace FilmApplication
{
    public class FilmContext:DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options)
               : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasMany(a => a.Films)
                .WithMany(f => f.Actors);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
