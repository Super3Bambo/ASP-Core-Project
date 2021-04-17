﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Models
{
    public class Context:IdentityDbContext
    {
     public   Context (DbContextOptions<Context> options) : base(options) { }
        public virtual DbSet<Anime> Anime { get; set; }
        public virtual DbSet<UsersAnime> UsersAnime { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersAnime>().HasKey(sc => new { sc.UserID, sc.AnimeID });
            base.OnModelCreating(builder);

        }



    }
}
