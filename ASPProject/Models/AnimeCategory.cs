using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class AnimeCategory
    {
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [ForeignKey("Anime")]
        public int AnimeID { get; set; }

        public virtual Category Category { get; set; }
        public virtual Anime Anime { get; set; }

        


    }
}
