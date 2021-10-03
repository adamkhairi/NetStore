using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Shared.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsOrderCompleted { get; set; } = false;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}