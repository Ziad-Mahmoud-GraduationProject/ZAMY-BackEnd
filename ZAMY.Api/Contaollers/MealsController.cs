namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController(IMealService _mealService) : ControllerBase
    {
        [HttpGet("GetById{Id}")]
        public IActionResult Get(int id)
        {
            var meal = _mealService.GetById(id);

            if(meal is null) return NotFound();

            return Ok(meal);
        }

        [HttpGet("Create")]
        public IActionResult Create(Meal meal,int mainCategory,int subCategory)
        {
             _mealService.Add(meal,mainCategory,subCategory,"s");

            if (meal is null) return NotFound();

            return Ok(meal);
        }
    }
}
