using System.Collections.Generic;
using System.Threading.Tasks;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;

namespace NetStore.Api.Services.CartItems
{
    public interface ICartItemsService
    {
        Task<List<ResponceCartItem>> Get(string id);
        Task<CountResponce> CountItems(string id);
        Task<SubTotalAmountResponce> SubTotal(string id);
        Task<TotalItemsQtyResponce> TotalItems(string id);
        Task<bool> Post(CartItemRequest cartItem);
        Task<bool> Delete(string id);
    }
}
