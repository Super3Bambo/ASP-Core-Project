using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public interface IAnimeCategoriesService
    {
        public Task<List<AnimeCategory>> GetAll();
        public Task Update(AnimeCategory animeCategory);
        public Task Insert(AnimeCategory animeCategory);
        public Task Delete(int id, int id2);
    }
}
