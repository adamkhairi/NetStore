using System.ComponentModel.DataAnnotations.Schema;

namespace NetStore.Api.Contracts.Requests
{
    public class UpdateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped] public byte[] Img { get; set; }
        public string ImgUrl { get; set; }
    }
}
