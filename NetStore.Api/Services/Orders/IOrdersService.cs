using System.Collections.Generic;
using System.Threading.Tasks;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;

namespace NetStore.Api.Services.Orders
{
    public interface IOrdersService
    {
        Task<List<ResponceOrderDto>> PendingOrders();
        Task<List<ResponceOrderDto>> CompletedOrders();
        Task<List<ResponceOrderDetailDto>> Get(string orderId);
        Task<CountResponce> Count();
        Task<List<ResponceOrderDto>> GetByUser(string userId);
        Task<bool> Post(RequestOrder order);
        Task<bool> MarkCompleted(string orderId);
    }
}
