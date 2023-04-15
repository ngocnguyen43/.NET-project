using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Models.Message;
using WebAPI.Services.interfaces;
using WebAPI.Utils.Exceptions;

namespace WebAPI.Services
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext appDbContext , IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public Response create(ProductDto productDto)
        {
            productDto.Id = Guid.NewGuid();
            Product product = _mapper.Map<Product>(productDto);
            Response resp;
            try
            {
                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();
                Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
                resp = new Response.Builder(meta).Build();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Meta meta = new Meta.Builder("ERROR").WithStatusCode(401).Build();
                resp = new Response.Builder(meta).Build();
            }
            return resp;
        }

        public Response getAll()
        {
            if (true) throw new NotFoundException();
            Meta meta = new Meta.Builder("OK").WithStatusCode(200).WithErrorCode(12).Build();
            return new Response.Builder(meta).Build();
        }
    }
}
