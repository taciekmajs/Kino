using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Actor
    {
        public enum GenderEnum {Male, Female }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Experience { get; set; }
        public GenderEnum Gender { get; set; }

        public List<Movie_Actor>? Movie_Actors { get; set; }
    }
}
