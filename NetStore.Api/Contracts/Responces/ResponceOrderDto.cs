using System;

namespace NetStore.Api.Contracts.Responces
{
    public class ResponceOrderDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsOrderCompleted { get; set; }
        public string UserId { get; set; }
    }
}
