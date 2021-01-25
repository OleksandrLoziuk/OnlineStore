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
    public class OrderAdminController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        private readonly IMapper _mapper;
        public OrderAdminController(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orderFromRepo = await _orderRepo.AllItems.Include(s => s.Status).Include(c => c.Client).ToListAsync();
            var orderToReturn = _mapper.Map<IEnumerable<OrderToListDto>>(orderFromRepo);
            return Ok(orderToReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
             var orderFromRepo = await _orderRepo.AllItems.Include(s => s.Status).Include(c => c.Client).FirstOrDefaultAsync(o => o.Id == id);
             if(orderFromRepo!= null)
             {
                 var orderToReturn = _mapper.Map<OrderForDetailDto>(orderFromRepo);
                 return Ok(orderToReturn);
             }
             return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if(await _orderRepo.DeleteItemAsync(id))
            {
                return Ok();
            }
            return BadRequest();
            
        }
    }
}