using System.Collections.Generic;
using System.Threading.Tasks;
using NetStore.Api.Contracts;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Shared.Models;

namespace NetStore.Api.Services.Products
{
    public interface IProductService
    {
        Task<ResponceProductDTO> Get(string id);
        Task<List<Product>> Get(GetAllProductsFilter filter = null, PaginationFilter paginationFilter = null);
        Task<List<Product>> GetByCategory(string id);
        Task<List<Product>> GetTopProducts();
        Task<bool> Post(AddProductDTO product);
        Task<Product> Put(string id, Product product);
        Task<bool> Delete(string id);

    }
}
