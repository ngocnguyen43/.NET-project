using WebAPI.Dtos;
using WebAPI.Models.Message;

namespace WebAPI.Services.interfaces
{
    public interface IAuth
    {
        public Response register(UserDto userDto);
    }
}
