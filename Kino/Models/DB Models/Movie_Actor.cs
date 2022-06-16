namespace Kino.Models.DB_Models
{
    public class Movie_Actor
    {
        public int Id { get; set; }

        //Movie
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        //Actor 
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
