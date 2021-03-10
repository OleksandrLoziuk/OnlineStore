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
    [Route("api/categoriesadmin/{categoryId}/[controller]")]
    [ApiController]
    public class PhotoCategoryController : ControllerBase
    {
        private readonly IPhotoCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly ICategoryRepository _repo;
        public PhotoCategoryController(IPhotoCategoryRepository repository, ICategoryRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _repository = repository;
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name="GetPhotoCategory")]
        public async Task<IActionResult> GetPhotoCategory(int id)
        {
            var photoCategoryFromRepo = await _repository.GetItemAsync(id);

            var photoCategory = _mapper.Map<PhotoCategoryForReturnDto>(photoCategoryFromRepo);
            
            return Ok(photoCategory);
        }

        [HttpGet(Name = "GetPhotosCategory")]
        public async Task<IActionResult> GetPhotosCategory(int categoryId)
        {
            var photoCategoryFromRepo = await _repository.AllItems.Where(p => p.CategoryId == categoryId).ToListAsync();
            return Ok(photoCategoryFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForCategory(int categoryId, [FromForm]PhotoCategoryForCreationDto photoCategoryForCreationDto)
        {
            var categoryFromRepo = await _repo.GetItemAsync(categoryId); 
            var file = photoCategoryForCreationDto.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(400).Crop("pad").Gravity("center") //.Corp("fill")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoCategoryForCreationDto.Url = uploadResult.Uri.ToString();
            photoCategoryForCreationDto.PublicId = uploadResult.PublicId;

            var photoCategory = _mapper.Map<PhotoCategory>(photoCategoryForCreationDto);
            var photoToCheck = await _repository.AllItems.FirstOrDefaultAsync(item => item.CategoryId == categoryId);
            if(photoToCheck!=null)
            {
                var deleteParams = new DeletionParams(photoToCheck.PublicId);
                var result = _cloudinary.Destroy(deleteParams);
                await _repository.ChangeItemAsync(photoCategory);
            }
            else
            {
                await _repository.AddItemAsync(photoCategory);
            }
 
              categoryFromRepo.photoCategory = photoCategory;
                 if(await _repo.SaveChangesAsync()>0)
                 {
                     var photoCategoryToReturn = _mapper.Map<PhotoCategoryForReturnDto>(photoCategory);
                     return CreatedAtRoute("GetPhotoCategory", new{id = photoCategory.Id}, photoCategoryToReturn);
                 }
            
            return BadRequest();

        }
        
    
        
    }
}