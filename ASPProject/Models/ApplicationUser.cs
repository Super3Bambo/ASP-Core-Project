﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }
        [PersonalData]
        public string Lastname { get; set; }
        [PersonalData]
        public DateTime Birthday { get; set; }
        public virtual ICollection<UsersAnime> UsersAnimeList { get; set; }
    }
}
