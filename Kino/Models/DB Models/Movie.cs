using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kino.Models.DB_Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public DateTime ProjectionTime { get; set; }

        [ForeignKey("Genres")]
        public int GenreID { get; set; }
        public virtual Genre? Genre { get; set; }

        [ForeignKey("Directors")]
        public int DirectorID { get; set; }
        public virtual Director? Director { get; set; }

        public List<Movie_Actor>? Movie_Actors { get; set; }
    }
}
