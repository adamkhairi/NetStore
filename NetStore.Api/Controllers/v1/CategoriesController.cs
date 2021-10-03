using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categories.Get();
            if (result == null) return BadRequest();

            return Ok(result);
        }

        // [Authorize(Roles = "Admin")]
        //[HttpGet(ApiRoutes.Category.Get)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var cat = await _categories.Get(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        // [Authorize(Roles = "Admin")]
        //[HttpPost(ApiRoutes.Product.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _categories.Post(category);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        // [Authorize(Roles = "Admin")]
        //[HttpDelete(ApiRoutes.Category.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _categories.Delete(id);
            return Ok();
        }

        // [Authorize(Roles = "Admin")]
        //[HttpPut(ApiRoutes.Category.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var res = await _categories.Put(id, category);
            if (res == false) return NotFound();
            return Ok(category);
        }
    }
}