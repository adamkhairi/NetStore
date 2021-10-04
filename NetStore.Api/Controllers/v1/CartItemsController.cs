using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Services.CartItems;

namespace NetStore.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class CartItemsController : ControllerBase
    {
        public ICartItemsService _cartItems { get; }

        public CartItemsController(ICartItemsService cartItems)
        {
            _cartItems = cartItems;
        }
        
        // GET: CartItemsController
        /// <summary>
        ///  Return List of ResponceCartItem 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{id}")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> PostCartItem([FromBody] CartItemRequest cartItem)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _cartItems.Post(cartItem);
            return result == false ? BadRequest() : Ok(result);
        }

        /// <summary>
        /// Count CartItems by User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CountCartItems(string userId)
        {
            var result = await _cartItems.CountItems(userId);
            return result.Counter != 0 ? Ok(result) : NoContent();

        }

        /// <summary>
        /// Count SubTotal of the CartItems By User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> SubTotalCartItem(string userId)
        {
            var result = await _cartItems.SubTotal(userId);

            return result.TotalAmount != 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Count Total of the CartItems By User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> TotalItems(string id)
        {
            var result = await _cartItems.TotalItems(id);
            return result.TotalItems != 0 ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Delete All CartItems By User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(string userId)
        {
            var result = await _cartItems.Delete(userId);
            return result == false ? BadRequest() : Ok(result);
        }
    }
}
