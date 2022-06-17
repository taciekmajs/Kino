using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Movie_Actor
    {
        [Key]
        public int Id { get; set; }

        //Movie
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        //Actor 
        [Display(Name = "Actor")]
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }

    }
}
