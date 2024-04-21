using Authentication.Authorization.Helper.Helpers;
using ZAMY.Api.Dtos.Additions;
using ZAMY.Application.Services.Additions;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdditionsController(IAdditionsServices _additionService,IMapper _mapper) : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var addition = _additionService.GetById(id);
            if (addition == null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result:_mapper.Map<AdditionDto>(addition)));
        }

        [HttpGet("{Mealid}")]
        public IActionResult GetAll(int Mealid)
        {
            var additions = _additionService.GetAll(Mealid);
            if (additions == null || !additions.Any())
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<IEnumerable<AdditionDto>>(additions)));
        }

        [HttpPost]
        public IActionResult Add(CreateAdditionDto addition)
        {
            var addedAddition = _additionService.Add(_mapper.Map<Addition>(addition),addition.Img);
            if (addedAddition == null)
            {
                return Ok(ResponseFinal.BadRequest());
            }

            return Ok(ResponseFinal.Ok(Result:addedAddition));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EditAdditionDto updatedAddition)
        {
            var result = _additionService.Update(id, _mapper.Map<Addition>(updatedAddition),updatedAddition.Img);
            if (result == null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result:result));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _additionService.Delete(id);
            if (!deleted)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok());
        }
    }
}
