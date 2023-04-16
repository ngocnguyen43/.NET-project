using CoreApiResponse;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Models.Message;
using WebAPI.Services.interfaces;
using WebAPI.Utils.Exceptions.ErrorHandler;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangHoaController : BaseController
    {
        private readonly IProduct iproductService;
        public HangHoaController(IProduct iproduct)
        {
            this.iproductService = iproduct;
        }
        [HttpGet(Name = "Get All Products")]
        [ProducesResponseType(typeof(Response), 200)]
        public string getAll()
        {
            return ErrorHandler.Handle(Response, () => iproductService.getAll());
        }
        [HttpPost]
        [ProducesResponseType(typeof(Meta), 200)]
        public string create([FromBody] ProductDto productDto)
        {
            return ErrorHandler.Handle(Response, () => iproductService.create(productDto));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Meta), 200)]
        public string delete([FromBody] string id)
        {
            return ErrorHandler.Handle(Response, () => iproductService.delete(id));
        }
        [HttpPatch]
        [ProducesResponseType(typeof(Meta), 200)]
        public string update([FromBody] ProductDto productDto)
        {
            return ErrorHandler.Handle(Response, () => iproductService.update(productDto));
        }

    }
}
