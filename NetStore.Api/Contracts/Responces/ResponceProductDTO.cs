using System.Collections.Generic;
using NetStore.Shared.Models;

namespace NetStore.Api.Contracts.Responces
{
    public class ResponceProductDTO
    {
        public Product  Product{ get; set; }
        public List<Image> Images{ get; set; }
    }
}
