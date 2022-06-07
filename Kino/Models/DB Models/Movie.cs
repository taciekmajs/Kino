using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public int Duration { get; set; }
        public Director Director { get; set; }
        
        public DateTime ProjectionTime { get; set; }

    }
}
