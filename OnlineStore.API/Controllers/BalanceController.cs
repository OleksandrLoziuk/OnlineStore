using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceRepository _repo;
        private readonly IMapper _mapper;

        public BalanceController(IBalanceRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance()
        {
            var itemsFromRepo = await _repo.AllItems.Include(item => item.Product).ToListAsync();
            var itemsForReturn = _mapper.Map<IEnumerable<BalanceForListDto>>(itemsFromRepo);
            return Ok(itemsForReturn);
        }
    }
}