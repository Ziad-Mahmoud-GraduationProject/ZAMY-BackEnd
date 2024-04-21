namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController(IChoicesServices _choicesServices ,IMapper _mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var choice = _choicesServices.GetById(id);
            if (choice == null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<ChoiceDto>(choice)));
        }

        [HttpGet("{Mealid}")]
        public IActionResult GetAll(int Mealid)
        {
            var additions = _choicesServices.GetAll(Mealid);
            if (additions == null || !additions.Any())
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<IEnumerable<ChoiceDto>>(additions)));
        }

        [HttpPost]
        public IActionResult Add(ChoiceRequstDto choice)
        {
            var addedchoice = _choicesServices.Add(_mapper.Map<Choice>(choice));
            if (addedchoice == null)
            {
                return Ok(ResponseFinal.BadRequest());
            }

            return Ok(ResponseFinal.Ok(Result: addedchoice));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ChoiceRequstDto choice)
        {
            var result = _choicesServices.Update(id, _mapper.Map<Choice>(choice));
            if (result == null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: result));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _choicesServices.Delete(id);
            if (!deleted)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok());
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult ToggleStatus(int id)
        {
            var toggled = _choicesServices.ToggleStatus(id);
            if (!toggled)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok());
        }
    }
}
