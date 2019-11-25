using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IProductRepository _prRep;
        public CategoriesController(ICategoryRepository repo, IProductRepository prRep)
        {
            _prRep = prRep;
            _repo = repo;
        }
        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.ToListAsync();

            return Ok(categories);
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var products = await _prRep.AllItems.Where(p => p.CategoryId == id).ToListAsync();
            return Ok(products);
        }

        // POST api/categories
        [HttpPost]
        public void Post([FromBody] string category)
        {
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string category)
        {
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
