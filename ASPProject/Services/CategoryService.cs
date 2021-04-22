using ASPProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Services
{
    public class CategoryService : IMangerServices<Category>
    {
        private readonly Context context;

        public CategoryService(Context context)
        {
            this.context = context;
        }
        public async Task Delete(int id)
        {
            var category = await GetDetails(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        public Task Delete(int id, int id2)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, string id2)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            return await context.Categories.ToListAsync();
        }

        public List<Category> GetAllNotAsync()
        {
          return  context.Categories.ToList();      
        }

       

        public async Task<Category> GetDetails(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Category> GetDetailsName(string name)
        {
            return await context.Categories.FirstOrDefaultAsync(m => m.Name == name);

        }

        public async Task Insert(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }
    }
}
