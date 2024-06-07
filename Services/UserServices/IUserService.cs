using DevPloyClasses.Dto.UserDtos;
using DevPloyClasses.Models;

namespace AgentBuilderApi.Services.UserServices
{
    /// <summary>
    /// User service interface mandatory for Dipendency Injection
    /// </summary>
    public interface IUserService
    {
        DataContext _dataContext { get; }

        Task<ServiceResponse<string>> LogIn(UserDtoLogIn user);
        Task<ServiceResponse<string>> Register(UserDtoRegister user);
        Task<ServiceResponse<bool>> GetOtp(UserModel user, string pasw);
        Task<ServiceResponse<string>> RefreshToken(UserModel user, string pasw);
    }
}
