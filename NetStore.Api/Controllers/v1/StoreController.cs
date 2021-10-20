using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetStore.Api.Contracts;
using NetStore.Api.Contracts.Queries;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Api.Services.Products;
using NetStore.Api.Services.UriService;
using NetStore.Shared.Models;

namespace NetStore.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class StoreController : ControllerBase
    {
        private readonly IProductService _products;
        private readonly IUriService _uriService;

        private IMapper Mapper { get; }

        public StoreController(IProductService products, IMapper mapper, IUriService uriService)
        {
            _products = products;
            Mapper = mapper;
            _uriService = uriService;
        }


        /// <summary>
        /// Count Products
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CountResponce), StatusCodes.Status200OK)]
        //[HttpGet(ApiRoutes.Product.Get)]
        [HttpGet("[action]")]
        public async Task<IActionResult> CountProducts()
        {
            var productCount = await this._products.Count();


            return Ok(productCount);
        }

        /// <summary>
        /// Get All Product Apply Pagination and Search
        /// </summary>
        /// <param name="paginationQuery"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(PagedResponce<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.Product.GetAll)]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationQuery paginationQuery,
            [FromQuery] GetAllProductsQuery query)
        {
            var paginationFilter = Mapper.Map<PaginationFilter>(paginationQuery);
            var filter = Mapper.Map<GetAllProductsFilter>(query);
            var result = await _products.Get(filter, paginationFilter);
            if (result == null) return BadRequest();

            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PagedResponce<Product>(result));
            }

            var nextPage = paginationFilter.PageNumber >= 1
                ? _uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize))
                    .ToString()
                : null;
            var firstPage = _uriService.GetAllUri(new PaginationQuery(1, paginationFilter.PageSize))
                    .ToString()
                ;
            var previousPage = paginationFilter.PageNumber - 1 >= 1
                ? _uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize))
                    .ToString()
                : null;

            //var paginationResponce = new PagedResponce<Product>(result);
            var paginationResponce = new PagedResponce<Product>
            {
                Data = result,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : null,
                NextPage = result.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
            return Ok(paginationResponce);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponceProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.Product.Get)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] string id)
        {
            var result = await _products.Get(id);
            if (result == null) return BadRequest();

            return Ok(result);
        }


        /// <summary>
        /// Get Products by Category Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Responce<List<Product>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.Product.GetByCat)]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] string id)
        {
            var result = await _products.GetByCategory(id);
            if (result == null) return BadRequest();

            return Ok(new Responce<List<Product>>(result));
        }

        /// <summary>
        /// Get Top Products
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Responce<List<Product>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //[HttpGet(ApiRoutes.Product.GetTopProducts)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTopProducts()
        {
            var result = await _products.GetTopProducts();
            if (result == null) return NoContent();

            return Ok(new Responce<List<Product>>(result));
        }


        /// <summary>
        /// Post New Product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Roles = "Admin")]
        //[HttpPost(ApiRoutes.Product.Create)]
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] AddProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _products.Post(product);
            if (!result) return BadRequest();

            return Ok(result);
        }

        /// <summary>
        ///  Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Roles = "Admin")]
        //[HttpPut(ApiRoutes.Product.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] string id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _products.Put(id, product);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Roles = "Admin")]
        //[HttpDelete(ApiRoutes.Product.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            var result = await _products.Delete(id);
            if (result == false) return BadRequest();

            return Ok(result);
        }
    }
}