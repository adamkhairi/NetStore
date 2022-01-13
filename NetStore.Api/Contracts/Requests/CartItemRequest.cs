namespace NetStore.Api.Contracts.Requests
{
    public class CartItemRequest
    {
        public int Qty { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
    }
}
