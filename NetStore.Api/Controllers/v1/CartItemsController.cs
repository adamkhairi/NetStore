using System.Threading.Tasks;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _cartItems.Get(id);
            return result == null ? NoContent() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CartItemRequest cartItem)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _cartItems.Post(cartItem);
            return result == false ? BadRequest() : Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CountAsync(string id)
        {
            var result = await _cartItems.CountItems(id);
            return result.Counter != 0 ? Ok(result) : NoContent();

        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> SubTotal(string id)
        {
            var result = await _cartItems.SubTotal(id);

            return result.TotalAmount != 0 ? Ok(result) : NoContent();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> TotalItems(string id)
        {
            var result = await _cartItems.TotalItems(id);
            return result.TotalItems != 0 ? Ok(result) : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _cartItems.Delete(id);
            return result == false ? BadRequest() : Ok(result);
        }
    }
}
