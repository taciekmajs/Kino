using System.ComponentModel.DataAnnotations;

namespace Kino.Models
{
    public class Actor
    {
        public enum EnumPlec { K,M}


        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Imie i nazwisko")]
        public string Name { get; set; }
        public int Eperience { get; set; }
        public EnumPlec Plec { get; set; }
    }
}
