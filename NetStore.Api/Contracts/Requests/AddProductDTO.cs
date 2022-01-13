using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Api.Contracts.Requests
{
    public class AddProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public bool IsTopProduct { get; set; } = false;
        public string CategoryId { get; set; }
        public string Ref { get; set; }

        [NotMapped] public List<byte[]> ImgsByte { get; set; }
        [NotMapped] public List<string> ImgsUrl { get; set; }
    }
}
