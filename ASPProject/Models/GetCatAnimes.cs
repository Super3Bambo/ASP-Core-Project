using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class GetCatAnimes
    {

        //public Category Category { get; set; }
        //public List<Anime> Member { get; set; }
        //public List<Anime> NotMember { get; set; }

        public string CatID { get; set; }
        public string CatName { get; set; }

        public string AnimeID { get; set; }
        public string AnimeName { get; set; }
        public bool IsSelected { get; set; }
    }
}
