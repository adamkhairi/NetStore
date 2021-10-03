namespace NetStore.Api.Contracts.Responces
{
    public class ResponceOrderDetailDto
    {
        public double Price { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
