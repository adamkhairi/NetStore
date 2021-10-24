using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageUploader;
using Microsoft.EntityFrameworkCore;
using NetStore.Api.Contracts;
using NetStore.Api.Contracts.Requests;
using NetStore.Api.Contracts.Responces;
using NetStore.Api.Data;
using NetStore.Shared.Models;

namespace NetStore.Api.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task<ResponceProductDTO> Get(string id)
        {
            //var images = _db.Images.Where(img => img.ProductImgId == id).ToList();
            return new ResponceProductDTO
            {
                Product = await _db.Products.SingleOrDefaultAsync(p => p.Id == id),
                Images = _db.Images.Where(img => img.ProductImgId == id).ToList()
            };
        }

        public async Task<CountResponce> Count()
        {
            return new CountResponce
            {
                Counter = await _db.Products.CountAsync()
            };
        }

        //TODO!:FixThis 
        public async Task<List<Product>> Get(GetAllProductsFilter filter = null,
            PaginationFilter paginationFilter = null)
        {
            var queryable = _db.Products.AsQueryable();
            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            queryable = AddFiltersOnQuery(filter, queryable);
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            var result = await queryable
                .OrderBy(i => i.Name)
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            return result;
        }

        private static IQueryable<Product> AddFiltersOnQuery(GetAllProductsFilter filter, IQueryable<Product> queryable)
        {
            if (!string.IsNullOrEmpty(filter?.n))
                queryable = queryable.Where(p => p.Name.Contains(filter.n));


            return queryable;
        }

        public async Task<List<Product>> GetByCategory(string id)
        {
            var result = await _db.Products.Where(p => p.CategoryId == id).ToListAsync();
            if (result.Count > 0)
                return result;
            return null;
        }

        public async Task<List<Product>> GetTopProducts()
        {
            var result = await _db.Products.Where(p => p.IsTopProduct == true).Take(6).ToListAsync();
            return result.Count <= 0 ? null : result;
        }
        //TODO!: Fix This

        public async Task<bool> Post(AddProductDTO product)
        {
            var imgList = new List<Image>();
            var returnn = false;
            if (product != null && product.ImgsByte != null && product.ImgsByte.Any())
            {
                product.ImgsByte?.ToList().ForEach(imgByte =>
                {
                    var imgStream = new MemoryStream(imgByte != null ? imgByte : new byte[] { });
                    var imgName = Guid.NewGuid().ToString();
                    var img = $"{imgName}.jpg";
                    var productImgFolder = "wwwroot/imgs/products";
                    var res = FilesHelper.UploadImage(imgStream, productImgFolder, imgName);

                    if (res)
                    {
                        returnn = false;
                        return;
                    }
                    else
                    {
                        imgList.Add(new Image
                        {
                            ProductImgId = product.Id,
                            ImgUrl = productImgFolder + "/" + img,
                        });
                    }
                });
            }

            var model = _mapper.Map<Product>(product);
            model.ImgUrl = imgList[0]?.ImgUrl ?? null;

            _db.Products.Add(model);
            imgList?.ForEach(img => { _db.Images.Add(img); });

            await _db.SaveChangesAsync();
            return returnn;
        }

        //public async Task<Product> Post(Product product)
        //{
        //    var imgStream = new MemoryStream(product.ImgByte != null ? product.ImgByte : new byte[] { });
        //    var imgName = Guid.NewGuid().ToString();
        //    var img = $"{imgName}.jpg";
        //    var productImgFolder = "wwwroot/imgs/products";
        //    var res = FilesHelper.UploadImage(imgStream, productImgFolder, imgName);

        //    if (!res)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        product.ImgUrl = product.ImgByte != null ? productImgFolder + "/" + img : null;
        //        product.ImgByte = product.ImgByte != null ? product.ImgByte : null;
        //        _db.Products.Add(product);
        //        await _db.SaveChangesAsync();
        //        return product;
        //    }
        //}

        public async Task<Product> Put(string id, Product product)
        {
            var oldProduct = _db.Products.Find(id);
            if (oldProduct == null) return null;

            oldProduct.Name = product.Name != null ? product.Name : oldProduct.Name;
            oldProduct.ShortDescription = product.ShortDescription != null
                ? product.ShortDescription
                : oldProduct.ShortDescription;
            oldProduct.LongDescription =
                product.LongDescription != null ? product.LongDescription : oldProduct.LongDescription;
            oldProduct.Price = product.Price != 0 ? product.Price : oldProduct.Price;
            oldProduct.Stock = product.Stock != 0 ? product.Stock : oldProduct.Stock;
            oldProduct.Color = product.Color != null ? product.Color : oldProduct.Color;
            oldProduct.Ref = product.Ref != null ? product.Ref : oldProduct.Ref;
            oldProduct.IsTopProduct = product.IsTopProduct;

            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Delete(string id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}