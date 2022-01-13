using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NetStore.Shared.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string ShortDescription { get; set; }
        [Required] public string LongDescription { get; set; }
        [Required] public double Price { get; set; }
        [Required] public int Stock { get; set; }
        public string Color { get; set; }
        public bool IsTopProduct { get; set; } = false;
        public string Ref { get; set; }


        public string CategoryId { get; set; }
        //[NotMapped] public byte[] ImgByte { get; set; }
        public string ImgUrl { get; set; }
        [JsonIgnore] public ICollection<OrderProduct> OrderProducts { get; set; }
        [JsonIgnore] public ICollection<CartItem> CartItems { get; set; }
        [JsonIgnore] public ICollection<Image> ProductImgs { get; set; }
    }
}