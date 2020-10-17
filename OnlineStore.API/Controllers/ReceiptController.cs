using System.Collections.Generic;
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
    public class ReceiptController: ControllerBase
    {
        private readonly IReceiptRepository _repo;
        private readonly IBalanceRepository _balanceRepo;
        private readonly IMapper _mapper;
        public ReceiptController(IReceiptRepository repo, IBalanceRepository balanceRepo, IMapper mapper)
        {
            _mapper = mapper;
            _balanceRepo = balanceRepo;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetReceipts()
        {
            var itemsFromRepo = await _repo.AllItems.Include(item => item.Product).ToListAsync();
            var itemsForReturn = _mapper.Map<IEnumerable<ReceiptForListDto>>(itemsFromRepo);
            return Ok(itemsForReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddToReceipt(ReceiptForCreationDto receiptForCreation)
        {
            var itemToRepo = _mapper.Map<Receipt>(receiptForCreation);
            if(await _repo.AddItemAsync(itemToRepo))
            {
                var balanceToChange = await _balanceRepo.AllItems.FirstOrDefaultAsync(p => p.ProductId == receiptForCreation.ProductId);
                if(balanceToChange != null)
                {
                    balanceToChange.Quantity += receiptForCreation.Quantity;
                    balanceToChange.Sum += receiptForCreation.Sum;
                    if(await _balanceRepo.SaveChangesAsync()>0)
                    {
                        return Ok();
                    }

                }
                else
                {
                    BalanceForCreationDto balanceForCreation = _mapper.Map<BalanceForCreationDto>(receiptForCreation);
                    var itemToBalanceRepo = _mapper.Map<Balance>(balanceForCreation);
                    if(await _balanceRepo.AddItemAsync(itemToBalanceRepo))
                    {
                        return Ok();
                    }
                }
                return BadRequest("Something wrong!");
            }
            return BadRequest();
        }
    }
}