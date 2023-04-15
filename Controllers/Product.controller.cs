using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Models.Message;
using WebAPI.Services.interfaces;
using WebAPI.Utils.Exceptions.ErrorHandler;
using WebAPI.Utils.Helpers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using AutoMapper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private IProduct iproduct;
        private IMapper _mapper;
        private static List<HangHoa> items = new List<HangHoa>();
        public HangHoaController(IProduct iproduct,IMapper imapper)
        {
            this.iproduct = iproduct;
            this._mapper = imapper;
        }
        [HttpGet]
        public string getAll()
        {
            return ErrorHandler.Handle(Response, () => iproduct.getAll());
        }
        [HttpPost]
        public string create([FromBody] ProductDto productDto)
        {
            return ErrorHandler.Handle(Response,() => iproduct.create(productDto));
        }
    }
}
