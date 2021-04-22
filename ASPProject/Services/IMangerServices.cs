using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public interface IMangerServices<T>
    {
        public Task<List<T>> GetAll();
        public List<T> GetAllNotAsync();

        public Task<T> GetDetails(int id);
        public Task Update(T anime);
        public Task Insert(T anime);
        public Task Delete(int id);
        public Task Delete(int id,int id2);
        public Task Delete(int id, string id2);
        public Task<T> GetDetailsName(string name);




    }
}
