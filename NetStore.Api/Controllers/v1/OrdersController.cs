using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Services.Orders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetStore.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IOrdersService _orders { get; set; }
        
        public OrdersController(IOrdersService orders)
        {
            _orders = orders;
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _orders.PendingOrders();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] RequestOrder order)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _orders.Post(order);
            if (!result) return NoContent();
            return Ok(result);
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Completed()
        {
            var result = await _orders.CompletedOrders();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Pending()
        {
            var result = await _orders.PendingOrders();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Count()
        {
            var result = await _orders.Count();
            if (result.Counter <= 0) return NoContent();
            return Ok(result);
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ByUser(string id)
        {
            var result = await _orders.GetByUser(id);
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }
        
        // GET: api/<OrdersController>
        // [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> MarkCompleted(string id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _orders.MarkCompleted(id);
            if (!result) return BadRequest();
            return Ok(true);
        }
        
    }
}
