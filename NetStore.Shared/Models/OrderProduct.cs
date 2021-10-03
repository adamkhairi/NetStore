using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Shared.Models
{
    public class OrderProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}