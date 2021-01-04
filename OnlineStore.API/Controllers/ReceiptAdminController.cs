using System.Collections.Generic;
using System.Linq;
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
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptAdminController : ControllerBase
    {
        private readonly IReceiptRepository _repo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        public ReceiptAdminController(IReceiptRepository repo, IMapper mapper, IProductRepository productRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceipts()
        {
            var itemsFromRepo = await _repo.AllItems.Include(item => item.Product).ToListAsync(); 
            var itemsForReturn = _mapper.Map<IEnumerable<ReceiptForListDto>>(itemsFromRepo);
            return Ok(itemsForReturn);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToReceipt(ReceiptForCreationDto receiptForCreation)
        {
            var itemToRepo = _mapper.Map<Receipt>(receiptForCreation);
            var productFromRepo = await _productRepo.AllItems.Where(p => p.ProductName == receiptForCreation.ProductName).FirstOrDefaultAsync();
            if(productFromRepo!=null)
            {
                itemToRepo.ProductId = productFromRepo.Id;
                itemToRepo.Sum = itemToRepo.Quantity*productFromRepo.Cost;
                productFromRepo.IsAvailable = true;
            }
            if (await _repo.AddItemAsync(itemToRepo))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var itemReceiptFromRepo = await _repo.GetItemAsync(id);
            if (await _repo.DeleteItemAsync(id))
                return Ok();
            return BadRequest();
        }
    }


}