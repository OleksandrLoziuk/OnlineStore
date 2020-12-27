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
        private readonly IBalanceRepository _balanceRepo;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        public ReceiptAdminController(IReceiptRepository repo, IBalanceRepository balanceRepo, IMapper mapper, IProductRepository productRepo)
        {
            _productRepo = productRepo;
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
                await _balanceRepo.SaveChangesAsync();
            }
            if (await _repo.AddItemAsync(itemToRepo))
            {
                var balanceToChange = await _balanceRepo.AllItems.FirstOrDefaultAsync(p => p.Product.ProductName == receiptForCreation.ProductName);
                if (balanceToChange != null)
                {
                    balanceToChange.Quantity += receiptForCreation.Quantity;
                    balanceToChange.Sum += receiptForCreation.Sum;
                    if (await _balanceRepo.SaveChangesAsync() > 0)
                    {
                        return Ok();
                    }

                }
                else
                {
                    BalanceForCreationDto balanceForCreation = _mapper.Map<BalanceForCreationDto>(receiptForCreation);
                    var itemToBalanceRepo = _mapper.Map<Balance>(balanceForCreation);
                    if (await _balanceRepo.AddItemAsync(itemToBalanceRepo))
                    {
                        return Ok();
                    }
                }
                return BadRequest("Something wrong!");
            }
            return BadRequest();
        }
        [HttpPut("{id}/edit")]
        public async Task<IActionResult> EditReceipt(int id, ReceiptForCreationDto receiptForCreation)
        {
            var itemFromReceiptRepo = await _repo.GetItemAsync(id);
            var balanceToChange = await _balanceRepo.AllItems.FirstOrDefaultAsync(b => b.ProductId == itemFromReceiptRepo.ProductId);

            if (balanceToChange != null)
            {
                balanceToChange.Quantity -= itemFromReceiptRepo.Quantity;
                balanceToChange.Sum -= itemFromReceiptRepo.Sum;

                balanceToChange.Quantity += receiptForCreation.Quantity;
                balanceToChange.Sum += receiptForCreation.Sum;

                if (await _balanceRepo.SaveChangesAsync() > 0)
                {
                    itemFromReceiptRepo.Quantity = receiptForCreation.Quantity;
                    itemFromReceiptRepo.Sum = receiptForCreation.Sum;

                    if (await _repo.SaveChangesAsync() > 0)
                    {
                        return Ok();
                    }
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var itemReceiptFromRepo = await _repo.GetItemAsync(id);
            var balanceToChange = await _balanceRepo.AllItems.FirstOrDefaultAsync(b => b.ProductId == itemReceiptFromRepo.ProductId);

            if (balanceToChange != null)
            {
                balanceToChange.Quantity -= itemReceiptFromRepo.Quantity;
                balanceToChange.Sum -= itemReceiptFromRepo.Sum;

                if (await _balanceRepo.SaveChangesAsync() > 0)
                {
                    if (await _repo.DeleteItemAsync(id))
                    {
                        return Ok();
                    }
                }
            }
            return BadRequest();
        }
    }


}