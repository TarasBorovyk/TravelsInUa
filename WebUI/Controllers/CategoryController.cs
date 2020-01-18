using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Categories.Commands.CreateCategory;
using Application.Categories.Queries.GetCategories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await Mediator.Send(new GetCategoriesQuery());
        }
    }
}