using System;
using System.Threading.Tasks;
using AccessStore.Data.Transactions;
using AccessStore.Domain.CommandHandlers;
using Microsoft.AspNetCore.Mvc;

namespace AccessStore.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Success(object result, string message)
        {
            try
            {
                _uow.Commit();
                return Ok(new
                {
                    success = true,
                    message = message,
                    data = result
                });
            }
            catch 
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Falha na requisição"
                });
            }
        }

        public async Task<IActionResult> Error(object result, string message)
        {
            return BadRequest(new
            {
                success = false,
                message = message,
                data = result
            });
        }
    }
}
