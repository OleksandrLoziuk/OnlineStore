using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Data.Interfaces;
using OnlineStore.API.Dtos;
using OnlineStore.API.Models;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IClientRepository _clRepo;
        private readonly IStringsOrderRepository _strOrdRepo;
        private readonly IOrderRepository _ordRepo;
        public OrderController(IClientRepository clRepo, IStringsOrderRepository strOrdRepo, IOrderRepository ordRepo)
        {
            _ordRepo = ordRepo;
            _strOrdRepo = strOrdRepo;
            _clRepo = clRepo;

        }
        [HttpPost("add")]
        public async Task<IActionResult> AddOrder(ClientForOrderDto clientDto)
        {
            if (clientDto != null)
            {
                clientDto.DeliveryMethod = clientDto.DeliveryMethod.Substring(3);
                clientDto.PaymentMethod = clientDto.PaymentMethod.Substring(3);
                Client client = new Client
                {
                    ClientName = clientDto.ClientName,
                    ClientSurname = clientDto.ClientSurname,
                    Patronymic = clientDto.Patronymic,
                    PhoneNumber = clientDto.PhoneNumber,
                    Email = clientDto.Email,
                    DeliveryMethod = clientDto.DeliveryMethod,
                    Place = clientDto.Place,
                    PlaceNumber = clientDto.PlaceNumber,
                    PaymentMethod = clientDto.PaymentMethod
                };
                await _clRepo.AddItemAsync(client);
                Client clientForOrder = _clRepo.AllItems.LastOrDefault();
                double sum = 0;
                var strOrds = await _strOrdRepo.AllItems.Where(s => s.OrderId == 0).ToListAsync();
                foreach (var item in strOrds)
                {
                    sum += item.Amount;
                }
                if (clientForOrder != null)
                {
                    Order orderToDb = new Order
                    {
                        ClientId = clientForOrder.Id,
                        SumOrder = sum,
                        DateTimeOrder = DateTime.Now,
                        Status = "Новый"
                    };
                    await _ordRepo.AddItemAsync(orderToDb);
                    foreach (var item in strOrds)
                    {
                        item.OrderId = orderToDb.Id;
                        await _strOrdRepo.ChangeItemAsync(item);
                    }
                    return Ok();
                
                }
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteStringsOrder(int id)
        {
            var stringsOrderToDelete = await _strOrdRepo.AllItems.Where(s => s.OrderId == id).ToListAsync();
            if(stringsOrderToDelete!= null)
            {
                foreach( var item in stringsOrderToDelete)
                {
                    await _strOrdRepo.DeleteItemAsync(item.Id);
                }
                return Ok();
            }
            return BadRequest();
        }

    }


}