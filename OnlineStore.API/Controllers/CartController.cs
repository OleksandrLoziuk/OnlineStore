using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;
using OnlineStore.API.Models;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IStringsOrderRepository _repo;

        public CartController(IStringsOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCart(StringsOrderDto [] arr)
        {
            List<StringsOrder> StringsOrderToAdd = new List<StringsOrder>();
            for(int i = 0; i< arr.Length; i++)
            {
                StringsOrder str = new StringsOrder
                {
                    ProductId = arr[i].ProductId,
                    Quantity = arr[i].Quantity,
                    Amount = arr[i].Amount,
                    OrderId = 0
                };
                StringsOrderToAdd.Add(str);
            }
            if(await _repo.AddItemsAsync(StringsOrderToAdd) != -1)
              return Ok();
            return BadRequest("Error adding data");
        }
    }
}