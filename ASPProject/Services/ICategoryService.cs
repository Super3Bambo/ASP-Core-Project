using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();
        public List<Category> GetAllAsync();

        public Task<Category> GetDetails(int id);
        public Task<Category> GetDetailsName(string name);

        public Task Update(Category category);
        public Task Insert(Category category);
        public Task Delete(int id);

    }
}
