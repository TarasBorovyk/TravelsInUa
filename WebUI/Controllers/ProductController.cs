using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products.Commands.CreateProduct;
using Application.Products.Queries.GetProducts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> Get()
        //{
        //    return await Mediator.Send(new GetProductsQuery());
        //}
    }
}