using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;
using OnlineStore.API.Models;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAdminController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly IColorRepository _colRepo;
        private readonly ICategoryRepository _catRepo;
        public ProductsAdminController(IProductRepository repo, IMapper mapper, ICategoryRepository catRepo, IColorRepository colRepo)
        {
            _catRepo = catRepo;
            _colRepo = colRepo;
            _mapper = mapper;
            _repo = repo;
        }
        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.AllItems.Include(item => item.Photos).ToListAsync();

            var productsToReturn = _mapper.Map<IEnumerable<ProductForListDto>>(products);

            return Ok(productsToReturn);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repo.AllItems.Include(item => item.Color).Include(item => item.Category).Include(item => item.Photos).FirstOrDefaultAsync(x => x.Id == id);

            var productToReturn = _mapper.Map<ProductForDetailedDto>(product);

            return Ok(productToReturn);
        }

        // POST api/products
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductForCreationDto productForCreation)
        {
            var productToRepo = _mapper.Map<Product>(productForCreation);
            
            var categoryFromRepo = await _catRepo.AllItems.Where(c => c.Name == productForCreation.CategoryName ).FirstOrDefaultAsync();
            if(categoryFromRepo != null)
            {
                productToRepo.CategoryId = categoryFromRepo.Id;
            }
            else
            {
                return BadRequest("Категория не существует");
            }
                
            var colorFromRepo = await _colRepo.AllItems.Where(c => c.ColorName == productForCreation.ColorName).FirstOrDefaultAsync();
            if(colorFromRepo != null)
            {
                productToRepo.ColorId = colorFromRepo.Id;
                productToRepo.IsAvailable = true;
            }
            else
            {
               return BadRequest("Цвет не существует"); 
            }  
            if(await _repo.AddItemAsync(productToRepo))
            {
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string category)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}