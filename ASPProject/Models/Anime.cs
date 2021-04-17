using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class Anime
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public decimal Rating { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public Status State { get; set; }
        [Required]
        public string Studios { get; set; }
        [Required]
        public string Plot { get; set; }
        public virtual ICollection<UsersAnime> UsersAnimeList { get; set; }
    }
    public enum Category
    {
        Comedy,
        Drama,
        Sports,
        Supernatural,
        Shonen,
        Romance,
        Thriller,
        Seinen,
        Horrro,
        Isekai,
        Mecha,
        Action
    }
    public enum Status
    {
        Airing,
        Finished,
        NotYet
    }
}
