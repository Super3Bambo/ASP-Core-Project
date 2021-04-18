using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class GetCatAnimes
    {

        public Category Category { get; set; }
        public List<Anime> Member { get; set; }
        public List<Anime> NotMember { get; set; }
    }
}
