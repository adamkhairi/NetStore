using System.ComponentModel.DataAnnotations;

namespace NetStore.Shared.Dto
{
    public class AddRoleModel
    {
        [Required] public string UserId { get; set; }

        [Required] public string Role { get; set; }
    }
}