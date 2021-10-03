using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public IMapper _mapper { get; }

        public StoreController(IProductService products, IMapper mapper, IUriService uriService)
        {
            _products = products;
            _mapper = mapper;
            _uriService = uriService;
        }

        //[HttpGet(ApiRoutes.Product.GetAll)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationQuery paginationQuery, [FromQuery] GetAllProductsQuery query)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);
            var filter = _mapper.Map<GetAllProductsFilter>(query);
            var result = await _products.Get(filter, paginationFilter);
            if (result == null) return BadRequest();

            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return Ok(new PagedResponce<Product>(result));
            }

            var nextPage = paginationFilter.PageNumber >= 1
                ? _uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;


            var previousPage = paginationFilter.PageNumber - 1 >= 1
                ? _uriService.GetAllUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

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

        //[HttpGet(ApiRoutes.Product.Get)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = await _products.Get(id);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        //[HttpGet(ApiRoutes.Product.GetByCat)]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByCategory([FromRoute] string id)
        {
            var result = await _products.GetByCategory(id);
            if (result == null) return BadRequest();

            return Ok(new Responce<ICollection<Product>>(result));
        }

        //[HttpGet(ApiRoutes.Product.GetTopProducts)]
        [HttpGet("[action]")]
        public async Task<IActionResult> TopProducts()
        {
            var result = await _products.GetTopProducts();
            if (result == null) return BadRequest();

            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost(ApiRoutes.Product.Create)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductDTO product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _products.Post(product);
            if (!result) return BadRequest();

            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPut(ApiRoutes.Product.Update)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _products.Put(id, product);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpDelete(ApiRoutes.Product.Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var result = await _products.Delete(id);
            if (result == false) return BadRequest();

            return Ok(result);
        }
    }
}