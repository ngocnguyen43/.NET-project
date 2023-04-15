using WebAPI.Models;

namespace WebAPI.Services.interfaces
{
    public interface IProduct
    {
       public void create(IProduct product);
       public Response getAll();
    }
}
