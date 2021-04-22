using ASPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public class AnimeCategoriesService : IMangerServices<AnimeCategory>
    {
        private readonly Context context;

        public AnimeCategoriesService(Context context)
        {
            this.context = context;
        }
        public async Task Delete(int id, int id2)
        {
            var deleted = context.AnimeCategories.Find(id, id2);
            context.AnimeCategories.Remove(deleted);
            await context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AnimeCategory>> GetAll()
        {
           return await context.AnimeCategories.ToListAsync();
        }

        public List<AnimeCategory> GetAllNotAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnimeCategory> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnimeCategory> GetDetailsName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(AnimeCategory animeCategory)
        {
            context.AnimeCategories.Add(animeCategory);
            await context.SaveChangesAsync();
        }

        public async Task Update(AnimeCategory animeCategory)
        {
            context.AnimeCategories.Update(animeCategory);
            await context.SaveChangesAsync();
        }
    }
}
