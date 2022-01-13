using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Api.Services.CartItems;

namespace NetStore.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItems;

        public CartItemsController(ICartItemsService cartItems)
        {
            _cartItems = cartItems;
        }

        // GET: CartItemsController
        /// <summary>
        ///  Return List of ResponceCartItem 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<ResponceCartItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ResponceCartItem>), StatusCodes.Status204NoContent)]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartItem(string userId)
        {
            var result = await _cartItems.Get(userId);
            return result == null ? NoContent() : Ok(result);
        }

        /// <summary>
        /// Post new CartItem
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> PostCartItem([FromBody] CartItemRequest cartItem)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _cartItems.Post(cartItem);
            return result == false ? BadRequest() : Ok(true);
        }

        /// <summary>
        /// Count CartItems by User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CountResponce), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> CountCartItems(string userId)
        {
            var result = await _cartItems.CountItems(userId);
            return result.Counter != 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Count SubTotal of the CartItems By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SubTotalAmountResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> SubTotalCartItem(string userId)
        {
            var result = await _cartItems.SubTotal(userId);

            return result.TotalAmount != 0 ? Ok(result) : NoContent();
        }
        
        /// <summary>
        /// Count Total of the CartItems By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TotalItemsQtyResponce), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> TotalItems(string userId)
        {
            var result = await _cartItems.TotalItems(userId);
            return result.TotalItems != 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        ///  Delete All CartItems By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCartItem(string userId)
        {
            var result = await _cartItems.Delete(userId);
            return result == false ? BadRequest("NoContent") : Ok(true);
        }
    }
}