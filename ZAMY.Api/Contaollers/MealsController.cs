using ZAMY.Api.Dtos.meals;
using ZAMY.Application.Services.Kitchens;
using ZAMY.Application.Services.SubCategories;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController(IMealService _mealService,
        IKitchenService _kitchenService,
        IMainCategoryService _mainCategoryService,
        ISubCategoryService _subCategoryService
        ) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery]PaginationParameters paginationParameters)
        {
            var meal = _mealService.GetAll(paginationParameters);

            if (meal is null) return NotFound($"Not Found Any Meal !");

            return Ok(meal);
        }
        [HttpGet("GetById{Id}")]
        public IActionResult Get(int id)
        {
            var meal = _mealService.GetById(id);

            if(meal is null) return NotFound($"Not Found Any Meal has {id} Id !");

            return Ok(meal);
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateMealDTO dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var kitchenid= _kitchenService.GetById(dto.KitchenId);
            if(kitchenid == null) 
                return NotFound($"Not Found Any kitchen has {dto.KitchenId} Id !");
          /*  var k = _kitchenService.IsExists(dto.KitchenId);
             return NotFound($"Not Found Any Meal has {dto.KitchenId} Id !"); */

            var maincategoryid = _mainCategoryService.GetById(dto.MainCategoryId);
            if (maincategoryid == null)
                return NotFound($"Not Found Any MainCategory has {dto.MainCategoryId} Id !");

            var subcategoryid = _subCategoryService.GetById(dto.SubCategoryId);
            if (subcategoryid == null)
                return NotFound($"Not Found Any SubCategory has {dto.SubCategoryId} Id !");
          
            var meal = new Meal
            {
    
                Name=dto.Name,
                Description=dto.Description,
                Price=dto.Price,
               IsAvailable=dto.IsAvailable,
                Rating= dto.Rating,
                PreparationTime=dto.PreparationTime,
                Ingredients=dto.Ingredients,
                KitchenId=dto.KitchenId,
                MainCategoryId=dto.MainCategoryId,
                SubCategoryId=dto.SubCategoryId,
                OfferId=dto.OfferId
            };
            _mealService.Add(meal);
            return Ok(meal);
        }
    }
}
