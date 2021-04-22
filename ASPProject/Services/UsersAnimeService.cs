using ASPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public class UsersAnimeService : IMangerServices<UsersAnime>
    {
        private readonly Context context;

        public UsersAnimeService(Context context)
        {
            this.context = context;
        }

        public async Task Delete(int id1,string id2)
        {
            var deleted = context.UsersAnime.FirstOrDefault(oo=>oo.AnimeID==id1 &&oo.UserID== id2);
             context.UsersAnime.Remove(deleted);
            await context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, int id2)
        {
            throw new NotImplementedException();
        }

        public async Task< List<UsersAnime>> GetAll()
        {
          return  await context.UsersAnime.ToListAsync();
        }

        public List<UsersAnime> GetAllNotAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsersAnime> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersAnime> GetDetailsName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(UsersAnime useranime)
        {
            context.UsersAnime.Add(useranime);
            await context.SaveChangesAsync();
        }

        public async Task Update(UsersAnime useranime)
        {
            context.UsersAnime.Update(useranime);
            await context.SaveChangesAsync();
        }
    }
}
