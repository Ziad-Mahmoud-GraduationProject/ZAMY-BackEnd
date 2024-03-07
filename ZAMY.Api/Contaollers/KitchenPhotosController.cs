using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAMY.Application.Services.KitchenPhotos;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenPhotosController(IKitchenPhotoService _kitchenService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Add([FromForm]IFormFile imagefile)
        {
            var image = _kitchenService.Upload(imagefile);
            return Ok(image);
            //.Add(imagefile);

        }
    }
}
