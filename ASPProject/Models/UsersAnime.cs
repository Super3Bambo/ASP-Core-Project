using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class UsersAnime
    {
        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Anime")]
        public int AnimeID { get; set; }
        public virtual Anime Anime { get; set; }
        public int Rating { get; set; }
    }
}
