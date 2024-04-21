using Microsoft.EntityFrameworkCore;
using ZAMY.Api.Dtos.meals;
using ZAMY.Api.Dtos.meals.incomming;
using ZAMY.Application.Services.Kitchens;
using ZAMY.Application.Services.Photo;
using ZAMY.Application.Services.SubCategories;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController(IMealService _mealService,
        IKitchenService _kitchenService,
        IMainCategoryService _mainCategoryService,
        ISubCategoryService _subCategoryService,
        IPhotoService _photoService
        ,IMapper _mapper
        ) : ControllerBase
    {
        private string[] allowedExtention = new string[] { ".jpg", ".png" };
        private long imageLength = 1048576;
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParameters paginationParameters)
        {
            var meal = _mealService.GetAll(paginationParameters);

            if (meal is null) return NotFound($"Not Found Any Meal !");

            return Ok(meal);
        }
        [HttpGet("GetById{Id}")]
        public IActionResult Get(int id)
        {
            var meal = _mealService.GetById(id);

            if (meal is null) return NotFound($"Not Found Any Meal has {id} Id !");

            return Ok(meal);
        }
        [HttpPost("Create")]
        public IActionResult Create([FromForm]CreateMealDTO dto, [FromForm] IList<IFormFile> files)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var kitchenid = _kitchenService.GetById(dto.KitchenId);
            if (kitchenid == null)
                return NotFound($"Not Found Any kitchen has {dto.KitchenId} Id !");
          
            var maincategoryid = _mainCategoryService.GetById(dto.MainCategoryId);
            if (maincategoryid == null)
                return NotFound($"Not Found Any MainCategory has {dto.MainCategoryId} Id !");

            var subcategoryid = _subCategoryService.GetById(dto.SubCategoryId);
            if (subcategoryid == null)
                return NotFound($"Not Found Any SubCategory has {dto.SubCategoryId} Id !");

            if (files is null || !files.Any())
                return NotFound("Not Found any Image");

            foreach (var file in files)
            {
                if (!_photoService.ImageExtension(file, allowedExtention))
                    return BadRequest(error: "Only .jpg,.png image are allowed! ");

                if (!_photoService.ImageLength(file, imageLength))
                    return BadRequest(error: "max allowed size for image 1MB! ");
            }
            var meal = _mapper.Map<Meal>(dto);

            _mealService.Add(meal);

                foreach (var file in files)
                {
                    var photo = new MealPhoto
                    {
                        Image = _photoService.UploadImage(file),
                        MealId = meal.Id
                    };
                    _photoService.AddToMeal(photo);
                }
   
            return Ok(meal);
        }
       
       
}

}
