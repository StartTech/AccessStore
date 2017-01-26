using System.Threading;
using System.Threading.Tasks;
using AccessStore.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessStore.Api.Controllers
{
    [Route("products")]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        //[Authorize(Policy = "User")]
        [AllowAnonymous]
        [Route("v1")]
        public async Task<IActionResult> Get()
        {
            Thread.Sleep(500);
            return await Success(_repository.Get(), "");
        }

    }
}
