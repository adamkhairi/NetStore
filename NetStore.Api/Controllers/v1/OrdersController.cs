using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        /// <summary>
        /// Get Order By Id returns List ResponceOrderDetailDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOrder(string id)
        {
            var result = await _orders.Get(id);
            if (result == null) return BadRequest();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Post Order (Request Order)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromForm] RequestOrder order)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _orders.Post(order);
            if (!result) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Get All Completed Orders 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> CompletedOrders()
        {
            var result = await _orders.CompletedOrders();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Get All Pending Orders 
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> PendingOrders()
        {
            var result = await _orders.PendingOrders();
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Count All Orders
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> CountOrders()
        {
            var result = await _orders.Count();
            if (result.Counter <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Get Orders By User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderByUser(string id)
        {
            var result = await _orders.GetByUser(id);
            if (result.Count <= 0) return NoContent();
            return Ok(result);
        }

        // GET: api/<OrdersController>
        /// <summary>
        /// Mark Orders as Completed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> MarkOrderCompleted(string id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _orders.MarkCompleted(id);
            if (!result) return BadRequest();
            return Ok(true);
        }
    }
}