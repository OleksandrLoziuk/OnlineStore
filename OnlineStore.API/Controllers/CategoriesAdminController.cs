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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesAdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IPhotoCategoryRepository _repoPhoto;
        public CategoriesAdminController(ICategoryRepository repo, IPhotoCategoryRepository repoPhoto , IMapper mapper)
        {
            _repo = repo;
            _repoPhoto = repoPhoto;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.AllItems.Include(item => item.photoCategory).ToListAsync();
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryForListDto>>(categories);
            return Ok(categoriesToReturn);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repo.AllItems.Include(item => item.photoCategory).FirstOrDefaultAsync(x => x.photoCategory.CategoryId == id);
            var toRet = _mapper.Map<CategoryToReturnDto>(category);
            return Ok(toRet);

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory(CategoryForCreationDto categoryForCreationDto)
        {
            if(categoryForCreationDto != null)
            {
                var allCategories = _repo.AllItems.ToList();
                foreach (var item in allCategories)
                {
                    if(item.Name == categoryForCreationDto.Name)
                        return BadRequest("Наименование категории уже существует");
                }
                var categoryToCreation = _mapper.Map<Category>(categoryForCreationDto);
                if(await _repo.AddItemAsync(categoryToCreation))
                {
                    PhotoCategory photo = new PhotoCategory()
                    {
                        Url = "https://res.cloudinary.com/alcloud/image/upload/v1598367896/%D0%BD%D0%BE%D0%B2%D0%B8%D0%BD%D0%BA%D0%B0_xydkxl_qkwog8.jpg",
                        CategoryId = categoryToCreation.Id
                    };
                    if(await _repoPhoto.AddItemAsync(photo))
                    {
                        return Ok();
                    }
                }
            }
            return BadRequest();    
        }

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> EditCategory(int id, CategoryForCreationDto categoryForCreation)
        {
            var category = await _repo.GetItemAsync(id);
            if(category != null) 
            {
                _mapper.Map(categoryForCreation, category);
                if(await _repo.SaveChangesAsync()>0)
                {
                    return Ok();
                }    
            }
           return  BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if(await _repo.DeleteItemAsync(id))
            {
                return Ok("Категория удалена");

            }
            return BadRequest("Хуйня вышла!");
            
        }
    }
}