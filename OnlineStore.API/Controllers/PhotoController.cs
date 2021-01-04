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
    
    [Route("api/productsadmin/{productId}/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        
        private readonly IPhotoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        private readonly IProductRepository _repo;
        public PhotoController(IPhotoRepository repository, IProductRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
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
        
        [HttpGet("{id}", Name="GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repository.GetItemAsync(id);

            var photoCategory = _mapper.Map<PhotoForDetailedDto>(photoFromRepo);
            
            return Ok(photoCategory);
        }

        [HttpGet(Name = "GetPhotos")]
        public async Task<IActionResult> GetPhotosCategory(int productId)
        {
            var photosFromRepo = await _repository.AllItems.Where(p => p.ProductId == productId).ToListAsync();
            return Ok(photosFromRepo);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPhoto(int productId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            var productFromRepo = await _repo.GetItemAsync(productId); 
            var file = photoForCreationDto.File;
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

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Photo>(photoForCreationDto);
            var checkIsMainPhoto = await _repository.AllItems.FirstOrDefaultAsync(p => p.IsMain == true && p.ProductId == productFromRepo.Id);
            if(checkIsMainPhoto != null)
            {
                photo.IsMain = false;
            }
            else
            {
                photo.IsMain = true;
            }
            
            photo.ProductId = productFromRepo.Id;
            if(await _repository.AddItemAsync(photo))
            {
                 var photoForReturn = _mapper.Map<PhotoForReturnDto>(photo);
                return CreatedAtRoute("GetPhoto", new {id = photo.Id} , photoForReturn);
            }
            return BadRequest();

        }
    }
}