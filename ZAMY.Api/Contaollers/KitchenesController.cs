using ZAMY.Domain.Entities;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchensController
        (IKitchenService _kitchenService,
        IMapper _mapper) : ControllerBase
    {


        [HttpGet("")]
        public ActionResult<ApiResponse> Get([FromQuery] PaginationParameters paginationParameters)
        {
            var kitchens = _mapper.Map<IEnumerable<KitchenDto>>(_kitchenService.GetAll(paginationParameters));

            return Ok(new ApiResponse()
            {
                Result = kitchens
            });

        }



        [HttpGet("id/{id}")]
        public ActionResult<ApiResponse> Get(int id)
        {
            var kitchen = _mapper.Map<KitchenDto>(_kitchenService.GetById(id));

            return new ApiResponse();

        }



        [HttpGet("name/{name}")]
        public ActionResult<ApiResponse> Get(string name, [FromQuery] PaginationParameters paginationParameters)
        {
            var kitchens = _mapper.Map<IEnumerable<KitchenDto>>(_kitchenService.GetKitchenName(name, paginationParameters));

            return new ApiResponse();

        }      
    }
}
