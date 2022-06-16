using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int AwardsNumber { get; set; }

        public IList<Movie>? Movies { get; set; }


    }
}
