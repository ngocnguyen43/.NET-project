using WebAPI.Dtos;
using WebAPI.Models.Message;

namespace WebAPI.Services.interfaces
{
    public interface IProduct
    {
       public Response create(ProductDto product);
       public Response getAll();
    }
}
