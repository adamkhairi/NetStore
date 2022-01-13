using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Api.Data;
using NetStore.Shared.Dto;
using NetStore.Shared.Models;

namespace NetStore.Api.Services.CartItems
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CartItemsService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<ResponceCartItem>> Get(string userId)
        {
            var allCartItems = new List<ResponceCartItem>();

            var cartItem = await _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItem.Any()) return null;
            cartItem.ForEach(cart =>
           {
               var img = _db.Images.FirstOrDefault(i => i.ProductImgId == cart.ProductId);
               allCartItems.Add(new ResponceCartItem
               {
                   Id = cart.Id,
                   Price = cart.Price,
                   ProductName = cart.Product.Name,
                   ProductShortDescription = cart.Product.ShortDescription,
                   Qty = cart.Qty,
                   TotalAmount = cart.TotalAmount,
                   Image = img ?? null
               });
           });
            return allCartItems.Count > 0 ? allCartItems : null;
        }

        public async Task<bool> Post(CartItemRequest cartItem)
        {
            var cart = _db.CartItems.FirstOrDefault(c => c.ProductId == cartItem.ProductId && c.UserId == cartItem.UserId);

            var product = _db.Products.FirstOrDefault(p => p.Id == cartItem.ProductId);

            if (cart != null)
            {
                cart.Qty += cartItem.Qty;
                cart.TotalAmount = product.Price * cart.Qty;
            }
            else
            {
                var shoppingCart = new CartItem
                {
                    UserId = cartItem.UserId,
                    ProductId = cartItem.ProductId,
                    Qty = cartItem.Qty,
                    Price = product.Price,
                    TotalAmount = product.Price * cartItem.Qty,
                };
                _db.CartItems.Add(shoppingCart);
            }
            var result = await _db.SaveChangesAsync();
            return result > 0;
        }

        public async Task<CountResponce> CountItems(string userId)
        {
            var count = await _db.CartItems
                .Where(c => c.UserId == userId).CountAsync();
            var result = new CountResponce { Counter = count };
            return result;
        }

        public async Task<SubTotalAmountResponce> SubTotal(string id)
        {
            var totalPrice = await _db.CartItems
                .Where(c => c.UserId == id)
                .Select(c => c.TotalAmount)
                .SumAsync();
            var result = totalPrice <= 0 ? new SubTotalAmountResponce { TotalAmount = (double)0 } : new SubTotalAmountResponce { TotalAmount = totalPrice };
            return result;
        }

        public async Task<TotalItemsQtyResponce> TotalItems(string id)
        {
            var totalItems = await _db.CartItems
                .Where(c => c.UserId == id)
                .Select(c => c.Qty)
                .SumAsync();
            var result = totalItems <= 0 ? new TotalItemsQtyResponce { TotalItems = 0 } : new TotalItemsQtyResponce { TotalItems = totalItems };
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var cart = _db.CartItems
                .Where(c => c.UserId == id);
            _db.CartItems.RemoveRange(cart);
            var result = await _db.SaveChangesAsync();
            return result >= 0;
        }
    }
}
