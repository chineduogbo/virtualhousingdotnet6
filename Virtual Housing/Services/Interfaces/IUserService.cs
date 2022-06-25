using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto model);
        Task<User> Login(LoginDto model);
    }
}
