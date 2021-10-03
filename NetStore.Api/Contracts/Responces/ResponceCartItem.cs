using NetStore.Shared.Models;

namespace NetStore.Api.Contracts.Responces
{
    public class ResponceCartItem
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public Image Image { get; set; }
    }
}
