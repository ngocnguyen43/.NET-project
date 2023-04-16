using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
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
        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public Response create(ProductDto productDto)
        {
            productDto.Id = Guid.NewGuid().ToString();
            Product product = _mapper.Map<Product>(productDto);
            Response resp;
            try
            {
                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();
                Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
                resp = new Response.Builder(meta).Build();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Meta meta = new Meta.Builder("ERROR").WithStatusCode(401).Build();
                resp = new Response.Builder(meta).Build();
            }
            return resp;
        }

        public Response delete(string id)
        {
            Response res;
            try
            {
                _appDbContext.Products.Where(x => x.Id == id).ExecuteDelete();
                _appDbContext.SaveChanges();
                Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
                res = new Response.Builder(meta).Build();
            }
            catch (Exception ex)
            {
                Meta meta = new Meta.Builder("ERROR").WithStatusCode(401).Build();
                res = new Response.Builder(meta).Build();
            }
            return res;
        }

        public Response  getAll()
        {
            Response resp;
            try
            {
                var data = _appDbContext.Products.OrderByDescending(m => m.createdAt).ToList();
                Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
                Body body = new Body.Builder(null).WithData(data).Build();
                resp = new Response.Builder(meta).WithBody(body).Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Meta meta = new Meta.Builder("Error").WithStatusCode(404).Build();
                resp = new Response.Builder(meta).Build();
            }
            return resp;
        }

        public Response update(ProductDto product)
        {
            Response res;
            try
            {
               Product? entity =  _appDbContext.Products.Find(product.Id);
                if (entity != null)
                {
                _appDbContext.Entry(entity).CurrentValues.SetValues(product);
                _appDbContext.SaveChanges();
                Meta meta = new Meta.Builder("OK").WithStatusCode(201).Build();
                res = new Response.Builder(meta).Build();
                }
                else
                {
                    Meta meta = new Meta.Builder("Product Not Found").WithStatusCode(404).Build();
                    res = new Response.Builder(meta).Build();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.StackTrace}");
                Meta meta = new Meta.Builder("ERROR").WithStatusCode(401).Build();
                res = new Response.Builder(meta).Build();
            }
            return res;
        }
    }
}
