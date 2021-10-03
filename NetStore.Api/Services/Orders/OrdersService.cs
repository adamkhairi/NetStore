using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Api.Data;
using NetStore.Shared.Models;

namespace NetStore.Api.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OrdersService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ResponceOrderDto>> CompletedOrders()
        {
            var completed = new List<ResponceOrderDto>();
            var orders = await _db.Orders
                .Where(o => o.IsOrderCompleted == true)
                .ToListAsync();
            completed = _mapper.Map<List<ResponceOrderDto>>(orders);
            return !completed.Any() ? null : completed;
        }

        public async Task<List<ResponceOrderDto>> PendingOrders()
        {
            var orders = await _db.Orders
                .Where((o) => o.IsOrderCompleted == false)
                .ToListAsync();
            var pending = _mapper.Map<List<ResponceOrderDto>>(orders);
            return !pending.Any() ? null : pending;
        }

        public async Task<CountResponce> Count()
        {
            var res = await _db.Orders.LongCountAsync();
            return new CountResponce {Counter = (int) res};
        }

        public async Task<bool> Post(RequestOrder order)
        {
            if (order == null) return false;
            order.IsOrderCompleted = false;
            order.OrderPlaced = DateTime.Now;
            var newOrder = _mapper.Map<Order>(order);
            await _db.Orders.AddAsync(newOrder);
            var result = await _db.SaveChangesAsync();

            if (result < 1) return false;

            var cartItems = _db.CartItems.Where(cart => cart.UserId == newOrder.UserId && cart.IsChecked == true);
            await cartItems.ForEachAsync(async item =>
            {
                var orderProductDetail = new OrderProduct()
                {
                    Price = item.Price,
                    Qty = item.Qty,
                    TotalAmount = item.TotalAmount,
                    ProductId = item.ProductId,
                    OrderId = newOrder.Id,
                };
                await _db.OrderProducts.AddAsync(orderProductDetail);
            });
            _db.CartItems.RemoveRange(cartItems);
            result += await _db.SaveChangesAsync();
            return result > 1;
        }

        public async Task<List<ResponceOrderDetailDto>> Get(string orderId)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            var orderDetail = await _db.OrderProducts
                .Include(o => o.Product)
                .Include(o=>o.Order)
                .Where(o => o.OrderId == order.Id)
                .OrderByDescending(o=>o.Order.OrderPlaced)
                .Select<OrderProduct, ResponceOrderDetailDto>(o =>
                        _mapper.Map<ResponceOrderDetailDto>(o)
                    // new ResponceOrderDetailDto
                    // {
                    //     Price = o.Price,
                    //     Qty = o.Qty,
                    //     ProductName = o.Product.Name,
                    //     TotalAmount = o.TotalAmount
                    // }
                )
                .ToListAsync();
            return orderDetail.Any() ? orderDetail : null;
        }

        public async Task<List<ResponceOrderDto>> GetByUser(string userId)
        {
            var userOrders = await _db.Orders
                .OrderByDescending(o => o.OrderPlaced)
                .Where(o => o.UserId == userId)
                .Select<Order, ResponceOrderDto>(o =>
                    // new ResponceOrderDto
                    // {
                    //     Id = o.Id,
                    //     Address = o.Address,
                    //     Phone = o.Phone,
                    //     OrderPlaced = o.OrderPlaced,
                    //     
                    // }
                    _mapper.Map<ResponceOrderDto>(o)
                )
                .ToListAsync();
            return userOrders.Any() ? userOrders : null;
        }

        public async Task<bool> MarkCompleted(string orderId)
        {
            var extOrder = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (extOrder == null) return false;
            extOrder.IsOrderCompleted = true;
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }
    }
}