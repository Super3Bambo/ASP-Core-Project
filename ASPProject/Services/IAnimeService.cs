using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public interface IAnimeService
    {
        public Task<List<Anime>> GetAll();
        public List<Anime>GetAllNotAsync();

        public Task<Anime> GetDetails(int id);
        public Task Update(Anime anime);
        public Task Insert(Anime anime);
        public Task Delete(int id);





    }
}
