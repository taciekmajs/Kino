using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
