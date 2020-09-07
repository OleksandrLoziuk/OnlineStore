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
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public CategoriesAdminController(ICategoryRepository repo, IPhotoCategoryRepository repoPhoto, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _repoPhoto = repoPhoto;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
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
            if (categoryForCreationDto != null)
            {
                var allCategories = _repo.AllItems.ToList();
                foreach (var item in allCategories)
                {
                    if (item.Name == categoryForCreationDto.Name)
                        return BadRequest("Наименование категории уже существует");
                }
                var categoryToCreation = _mapper.Map<Category>(categoryForCreationDto);
                if (await _repo.AddItemAsync(categoryToCreation))
                {
                    var catRet = _mapper.Map<CategoryToReturnDto>(categoryToCreation);
                    return Ok(catRet);
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}/edit")]
        public async Task<IActionResult> EditCategory(int id, CategoryForCreationDto categoryForCreation)
        {
            var category = await _repo.GetItemAsync(id);
            if (category != null)
            {
                _mapper.Map(categoryForCreation, category);
                if (await _repo.SaveChangesAsync() > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var photoFromRepo = await _repoPhoto.AllItems.FirstOrDefaultAsync(p => p.CategoryId == id);
            if (await _repo.DeleteItemAsync(id))
            {
                var deleteParams = new DeletionParams(photoFromRepo.PublicId);
                var result = _cloudinary.Destroy(deleteParams);
                return Ok();

            }
            return BadRequest("Хуйня вышла!");

        }
    }
}