using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ImageUploader;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NetStore.Api.Data;
using NetStore.Api.Services.Categories;
using NetStore.Shared.Models;

namespace NetNgStore.Services.Categories
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _db;

        public CategoryServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Delete(string id)
        {
            var delCategory = _db.Categories.Find(id);
            if (delCategory == null) return false;

            _db.Categories.Remove(delCategory);
            var delete = await _db.SaveChangesAsync();
            return delete > 0;
        }

        public async Task<Category> Get(string id)
        {
            var find = await _db.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return find;
        }

        public async Task<List<Category>> Get()
        {
            return await _db.Categories.ToListAsync();
            //var getItems = (Category)_db.Categories.OrderBy(i => i.Id);
            ////var getItems = await _db.Categories.ToListAsync();
            //string img = Convert.ToBase64String(getItems.Img);
            //string imageDataURL = string.Format("data:image/jpg;base64,{0}", img);
            ////var results = new Category()
            ////{
            ////    Id = getItems.Id,
            ////    Description = getItems.Description,
            ////    Name = getItems.Name,
            ////    Img = imageDataURL;
            ////}
            //return imageDataURL.ToList();
        }

        public async Task<Category> Post(Category category)
        {
            var res = false;
            if (category.Img != null)
            {
                var guid = Guid.NewGuid().ToString();
                var imgStream = new MemoryStream(category.Img != null ? category.Img : new byte[] { });
                var imgNewName = $"{guid}.jpg";
                var imgFolder = "wwwroot/imgs/categories";
                res = FilesHelper.UploadImage(imgStream, imgFolder, imgNewName);
                category.ImgUrl = category.Img != null ? imgFolder + "/" + imgNewName : null;
                category.Img = category.Img != null ? category.Img : null;
            }
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Put(string id, Category category)
        {
            var oldCat = _db.Categories.Find(id);
            if (oldCat == null) return false;
            var res = false;
            if (category.Img != null)
            {
                var guid = Guid.NewGuid().ToString();
                var imgStream = new MemoryStream(category.Img.Any() ? category.Img : new byte[] { });
                var imgNewName = $"{guid}.jpg";
                var imgFolder = "wwwroot/imgs/categories";
                res = FilesHelper.UploadImage(imgStream, imgFolder, imgNewName);
                oldCat.ImgUrl = category.Img != null ? imgFolder + "/" + imgNewName : null;
            }
            oldCat.Name = category.Name == null ? oldCat.Name : category.Name;
            oldCat.Description = category.Description == null ? oldCat.Name : category.Description;
            await _db.SaveChangesAsync();
            return true;
        }

        //MemoryStream ms = new();
        //await image.CopyToAsync(ms);
        //category.Img = ms.ToArray();
        //_db.Entry(category).State = EntityState.Modified;
        //await _db.SaveChangesAsync();
    }
}
