using System.Threading.Tasks;
using AccessStore.Domain.CommandHandlers;
using AccessStore.Domain.Commands;
using AccessStore.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessStore.Api.Controllers
{
    [Route("orders")]
    public class OrderController : BaseController
    {
        private readonly IOrderRepository _repository;
        private readonly OrderHandler _handler;

        public OrderController(IOrderRepository repository, OrderHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        //[Authorize(Policy = "User")]
        [AllowAnonymous]
        [Route("v1/{number}")]
        public async Task<IActionResult> Get(string number)
        {
            return await Success(_repository.Get(number), "");
        }

        [HttpPost]
        //[Authorize(Policy = "User")]
        [AllowAnonymous]
        [Route("v1")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var user = User.Identity.Name;
            _handler.Handle(command);
            return await Success(command, "Pedido salvo com sucesso!");
        }
    }
}
