using System.Collections.Generic;
using System.Linq;
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
    [Route("api/orderadmin/{orderid}/[controller]")]
    public class StringsOrderAdminController : ControllerBase
    {
        private readonly IStringsOrderRepository _strOrdRepo;
        private readonly IMapper _mapper;
        public StringsOrderAdminController(IStringsOrderRepository strOrdRepo, IMapper mapper)
        {
            _mapper = mapper;
            _strOrdRepo = strOrdRepo;
        }

        
        [HttpGet(Name = "GetStringsOrder")]
        public async Task<IActionResult> GetStringsOrder(int orderid)
        {
            var stringsOrder = await _strOrdRepo.AllItems.Include(p => p.Product).Where(o => o.OrderId == orderid).ToListAsync();
            var strOrdToRet = _mapper.Map<IEnumerable<StingsOrderForListDto>>(stringsOrder);
            return Ok(strOrdToRet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStringOrder(int id)
        {
            if(await _strOrdRepo.DeleteItemAsync(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}