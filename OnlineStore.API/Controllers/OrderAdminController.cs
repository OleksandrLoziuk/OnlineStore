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
            var orderFromRepo = await _orderRepo.AllItems.ToListAsync();
            var orderToReturn = _mapper.Map<IEnumerable<OrderToListDto>>(orderFromRepo);
            return Ok(orderToReturn);
        }
    }
}