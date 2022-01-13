using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Shared.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        public string Id { get; set; }

        public string ImgUrl { get; set; }
        public string ProductImgId { get; set; }

        [NotMapped] public byte[] ImgByte { get; set; }
    }
}