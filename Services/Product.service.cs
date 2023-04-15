using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Message;
using WebAPI.Services.interfaces;
using WebAPI.Utils.Exceptions;

namespace WebAPI.Services
{
    public class ProductService : IProduct
    {
        public void create(IProduct product)
        {
            
            throw new NotImplementedException();
        }

        public Response getAll()
        {
            if (true) throw new NotFoundException();
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).WithErrorCode(12).Build();
            return new Response.Builder(meta).Build();
        }
    }
}
