using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;
using OnlineStore.API.Helpers;
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
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly IPhotoRepository _photoRepo;
        public ProductsAdminController(IProductRepository repo, IMapper mapper, ICategoryRepository catRepo, IColorRepository colRepo, IOptions<CloudinarySettings> cloudinaryConfig, IPhotoRepository photoRepo)
        {
            _photoRepo = photoRepo;
            _catRepo = catRepo;
            _colRepo = colRepo;
            _mapper = mapper;
            _repo = repo;
            _cloudinaryConfig = cloudinaryConfig;
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }
        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.AllItems.Include(item => item.Photos).Include(item => item.Category).ToListAsync();

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

            var checkProduct = await _repo.AllItems.Where(p => p.ProductName == productForCreation.ProductName).FirstOrDefaultAsync();
            if (checkProduct != null)
            {
                return BadRequest("Товар с таким именем уже существует!");
            }

            var categoryFromRepo = await _catRepo.AllItems.Where(c => c.Name == productForCreation.CategoryName).FirstOrDefaultAsync();
            if (categoryFromRepo != null)
            {
                productToRepo.CategoryId = categoryFromRepo.Id;
            }
            else
            {
                return BadRequest("Категория не существует");
            }

            var colorFromRepo = await _colRepo.AllItems.Where(c => c.ColorName == productForCreation.ColorName).FirstOrDefaultAsync();
            if (colorFromRepo != null)
            {
                productToRepo.ColorId = colorFromRepo.Id;
                productToRepo.IsAvailable = true;
            }
            else
            {
                return BadRequest("Цвет не существует");
            }

            if (await _repo.AddItemAsync(productToRepo))
            {
                var prodToRet = _mapper.Map<ProductForListDto>(productToRepo);
                return Ok(prodToRet);
            }
            return BadRequest();
        }

        // PUT api/products/5
        [HttpPut("{id}/edit")]
        public async Task<IActionResult> EditProduct(int id, ProductForCreationDto productForCreation)
        {
            var productFromRepo = await _repo.GetItemAsync(id);
            var catFromRepo = await _catRepo.AllItems.FirstOrDefaultAsync(c => c.Name == productForCreation.CategoryName);
            var colFromRepo = await _colRepo.AllItems.FirstOrDefaultAsync(c => c.ColorName == productForCreation.ColorName);
            if(productFromRepo != null)
            {
                _mapper.Map(productForCreation, productFromRepo);
                productFromRepo.CategoryId = catFromRepo.Id;
                productFromRepo.ColorId = colFromRepo.Id;
                if(await _repo.SaveChangesAsync()>0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                var photosFromRepo = await _photoRepo.AllItems.Where(p => p.ProductId == id).ToListAsync();
                if(photosFromRepo.Count != 0)
                {
                    foreach (var item in photosFromRepo)
                    {
                        var deleteParams = new DeletionParams(item.PublicId);
                        _cloudinary.Destroy(deleteParams);
                        await _photoRepo.DeleteItemAsync(item.Id);
                    }
                    photosFromRepo = await _photoRepo.AllItems.Where(p => p.ProductId == id).ToListAsync();
                    if(photosFromRepo.Count == 0)
                    {
                        if(await _repo.DeleteItemAsync(id))
                            return Ok();
                    }
                }

                if(await _repo.DeleteItemAsync(id))
                    return Ok();
                return BadRequest();    

        }
        [HttpPost("{prodId}/edit/{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int prodId, int id)
        {
            var photoFromRepo = await _photoRepo.GetItemAsync(id);

            if(photoFromRepo.IsMain)
                return BadRequest("Это фото уже главное");
            
            var currentMainPhoto = await _photoRepo.AllItems.Where(p => p.ProductId == prodId).Where(p => p.IsMain == true).FirstOrDefaultAsync();
            currentMainPhoto.IsMain = false;

            photoFromRepo.IsMain = true;

            if( await _photoRepo.SaveChangesAsync()>0)
                return Ok();
            
            return BadRequest();
        }
        [HttpDelete("{prodId}/edit/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photoFromRepo = await _photoRepo.GetItemAsync(id);

            if(photoFromRepo.IsMain)
                return BadRequest("Невозможно удалить главное фото");

            var deleteParams = new DeletionParams(photoFromRepo.PublicId);
            var result = _cloudinary.Destroy(deleteParams);
            if(result.Result == "ok")
            {
                if(await _photoRepo.DeleteItemAsync(id))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        
    }
}