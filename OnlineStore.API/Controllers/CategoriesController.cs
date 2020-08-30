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
using OnlineStore.API.Models;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IProductRepository _prRep;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository repo, IProductRepository prRep, IMapper mapper)
        {
            _mapper = mapper;
            _prRep = prRep;
            _repo = repo;
        }
        // GET api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.AllItems.Include(item => item.photoCategory).ToListAsync();
            var categoriesToReturn =_mapper.Map<IEnumerable<CategoryForListDto>>(categories);
            return Ok(categoriesToReturn);
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var products = await _prRep.AllItems.Include(item => item.Photos).Where(p => p.CategoryId == id).ToListAsync();

            var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        }
        
        // GET api/categories/5/2
        [HttpGet("{idcat}/{idprod}")]
        public async Task<IActionResult> GetProduct(int idcat, int idprod)
        {
            var product = await _prRep.AllItems.Include(item => item.Color).Include(item => item.Category).Include(item => item.Photos).FirstOrDefaultAsync(x => x.Id == idprod);

            var productToReturn = _mapper.Map<ProductForDetailedDto>(product);

            return Ok(productToReturn);
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
