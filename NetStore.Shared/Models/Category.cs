using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Shared.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
        [NotMapped]
        public byte[] Img { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}