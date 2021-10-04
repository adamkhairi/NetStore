using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetStore.Api.Services.Categories;
using NetStore.Shared.Models;

namespace NetStore.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categories;

        public CategoriesController(ICategoryServices categories)
        {
            _categories = categories;
        }

        //[HttpGet(ApiRoutes.Category.GetAll)]
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var result = await _categories.Get();
            if (result == null) return NoContent();

            return Ok(result);
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [Authorize(Roles = "Admin")]
        //[HttpGet(ApiRoutes.Category.Get)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] string id)
        {
            var cat = await _categories.Get(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
        
        /// <summary>
        /// Count SubTotal of the CartItems By User
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [Authorize(Roles = "Admin")]
        //[HttpPost(ApiRoutes.Product.Create)]
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _categories.Post(category);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Count SubTotal of the CartItems By User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [Authorize(Roles = "Admin")]
        //[HttpDelete(ApiRoutes.Category.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string id)
        {
            await _categories.Delete(id);
            return Ok();
        }

        /// <summary>
        /// Count SubTotal of the CartItems By User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [Authorize(Roles = "Admin")]
        //[HttpPut(ApiRoutes.Category.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] string id, [FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var res = await _categories.Put(id, category);
            if (res == false) return NotFound();
            return Ok(category);
        }
    }
}