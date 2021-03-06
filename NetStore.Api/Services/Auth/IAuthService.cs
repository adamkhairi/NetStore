using System.Collections.Generic;
using System.Threading.Tasks;
using NetStore.Shared.Dto;

namespace NetStore.Api.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<List<object>> GetRolesList();
        Task<List<object>> GetUsersList();
    }

    //public class AddRoleModel
    //{
    //}
}