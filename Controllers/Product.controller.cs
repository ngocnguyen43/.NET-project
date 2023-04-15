using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Models.Message;
using WebAPI.Services.interfaces;
using WebAPI.Utils.Exceptions.ErrorHandler;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private IProduct iproduct;
        private static List<HangHoa> items = new List<HangHoa>();
        public HangHoaController(IProduct iproduct)
        {
            this.iproduct = iproduct;
        }
        [HttpGet]
        public string getAll()
        {
            return ErrorHandler.Handle(Response, () => iproduct.getAll());
        }
        [HttpPost]
        public Meta create(ProductDto productDto)
        {
            return new Meta.Builder("abc").Build();
        }
    }
}
