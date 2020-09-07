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
    public class ColorsController : ControllerBase
    {
        private readonly IColorRepository _repo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _prodRepo;

        public ColorsController(IColorRepository repo, IMapper mapper, IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            var colors = await _repo.AllItems.ToListAsync();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            var color = await _repo.GetItemAsync(id);
            return Ok(color);
        }

        [HttpPost]
        public async Task<IActionResult> AddColor(ColorForCreationDto colorForCreationDto)
        {
            if (colorForCreationDto.ColorName == null)
                return BadRequest("Нет названия цвета");
            var colorToCreate = _mapper.Map<Color>(colorForCreationDto);

            var colorFromRepo = await _repo.AllItems.FirstOrDefaultAsync(p => p.ColorName == colorToCreate.ColorName);

            if (colorFromRepo != null)
                return BadRequest("Уже существует");

            if (await _repo.AddItemAsync(colorToCreate))
                return Ok(colorToCreate);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var checkColorInProducts = await _prodRepo.AllItems.FirstOrDefaultAsync(p => p.ColorId == id);
            if(checkColorInProducts == null)
            {
                if (await _repo.DeleteItemAsync(id))
                {
                    return Ok();
                }
            }
            return BadRequest("Что то пошло не так");
        }

    }
}