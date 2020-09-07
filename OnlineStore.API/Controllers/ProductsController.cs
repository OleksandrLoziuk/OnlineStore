using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
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
    }
}