using ASPProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public class AnimeService : IMangerServices<Anime>
    {
        private readonly Context context;

        public AnimeService(Context context)
        {
            this.context = context;
        }

        public async Task Delete(int id)
        {
            var anime = await GetDetails(id);
            context.Anime.Remove(anime);
            await context.SaveChangesAsync();
        }

        public Task Delete(int id, int id2)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id, string id2)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Anime>> GetAll() { 
        
                        return await context.Anime.ToListAsync();

        }

        public List<Anime> GetAllNotAsync()
        {
            return  context.Anime.ToList();
        }

        public async Task<Anime> GetDetails(int id)
        {
            return await context.Anime.FirstOrDefaultAsync(m => m.ID == id);
        }

        public Task<Anime> GetDetailsName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(Anime anime)
        {
            context.Anime.Add(anime);
            await context.SaveChangesAsync(); 
        }

        public async Task Update(Anime anime)
        {
            context.Anime.Update(anime);
            await context.SaveChangesAsync();
        }
    }
}
