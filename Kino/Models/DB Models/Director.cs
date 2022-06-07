using System.ComponentModel.DataAnnotations;

namespace Kino.Models.DB_Models
{
    public class Director
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Imie i nazwisko")]
        public string Name { get; set; }

    }
}
