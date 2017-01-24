using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccessStore.Api.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Success(object result, string message)
        {
            return Ok(new
            {
                success = true,
                message = message,
                data = result
            });
        }

        public async Task<IActionResult> Error(object result, string message)
        {
            return Ok(new
            {
                success = false,
                message = message,
                data = result
            });
        }
    }
}
