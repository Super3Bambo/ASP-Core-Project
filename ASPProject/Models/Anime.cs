using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public decimal Rating { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public Status State { get; set; }
        [Required]
        public string Studios { get; set; }
        [Required]
        public string Plot { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [Required]
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [DefaultValue(false)]
        public bool isPremium { get; set; }


        public virtual ICollection<UsersAnime> UsersAnimeList { get; set; }
        public virtual ICollection<AnimeCategory> animeCategories { get; set; }

    }
    /*
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
        Horror,
        Isekai,
        Mecha,
        Action
    }*/
    public enum Status
    {
        Airing,
        Finished,
        NotYet
    }
}
