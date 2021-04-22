using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public interface IUsersAnimeService
    {
        public Task<List<UsersAnime>> GetAll();
        public Task Update(UsersAnime useranime);
        public Task Insert(UsersAnime useranime);
        public Task Delete(int id,string id2);
    }
}
