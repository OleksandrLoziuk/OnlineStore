using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Data.Interfaces;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAdminController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepo;
        private readonly IStringsOrderRepository _strOrdRepo;
        private readonly IOrderRepository _orederRepo;
        public OrderAdminController(IBalanceRepository balanceRepo, IStringsOrderRepository strOrdRepo, IOrderRepository orederRepo)
        {
            _orederRepo = orederRepo;
            _strOrdRepo = strOrdRepo;
            _balanceRepo = balanceRepo;
        }
    }
}