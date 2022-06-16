using Kino.Models.DB_Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kino.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie_Actor> Movie_Actors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
    }
}