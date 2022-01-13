using System.Collections.Generic;
using System.Threading.Tasks;
using NetStore.Shared.Models;

namespace NetStore.Api.Services.Categories
{
   public interface ICategoryServices
   {
      Task<List<Category>> Get();
      Task<Category> Get(string categoryId);
      Task<Category> Post(Category category);
      Task<bool> Put(string categoryId, Category category);
      Task<bool> Delete(string categoryId);
   }
}