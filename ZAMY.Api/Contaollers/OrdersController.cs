using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok();
        }
    }
}
