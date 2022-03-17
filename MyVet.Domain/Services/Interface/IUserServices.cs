using libreriaNeoris.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libreriaNeoris.Domain.Services.Interface
{
    public interface IUserServices
    {

        Task<ResponseDto> Login(UserDto user);
        Task<ResponseDto> GetAllUsers(string token);

    }
}
