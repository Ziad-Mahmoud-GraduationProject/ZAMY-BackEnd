using ZAMY.Api.Dtos.subcategories;
using ZAMY.Application.Common.Helper;
using ZAMY.Application.Services.SubCategories;
namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController(ISubCategoryService _subCategoryService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var maincategories = _subCategoryService.GetAll();

            if (maincategories is null)
                return NotFound("not found any category !");

            return Ok(maincategories);
        }
        [HttpGet("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromQuery]PaginationParameters paginationParameters)
        {

            var maincategories = _subCategoryService.GetAllWithPagination(paginationParameters);

            if (maincategories is null)
                return NotFound("not found any category !");

            return Ok(maincategories);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            var subcategories = _subCategoryService.GetById(id);

            if (subcategories is null)

                return NotFound($"not found any category has {id} Id !");

            return Ok(subcategories);
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {

            var subcategories = _subCategoryService.GetCategoryName(name);

            if (subcategories is null)

                return NotFound($"not found any category has {name} Name !");

            return Ok(subcategories);
        }
        [HttpPost("Add")]
        public IActionResult Add(SubCategoryDto dto)
        {
            var subCategory = new SubCategory
            {
                Name = dto.Name
            };
            _subCategoryService.Add(subCategory);

            return Ok(subCategory);
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, SubCategoryDto dto)
        {
            var subCategory = _subCategoryService.GetById(id);

            if (subCategory is null)

                return NotFound($"not found any category has {id} Id !");

            subCategory.Name = dto.Name;

            _subCategoryService.Update(subCategory);

            return Ok(subCategory);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var subCategory = _subCategoryService.GetById(id);

            if (subCategory is null)

                return NotFound($"not found any category has {id} Id !");

            _subCategoryService.Delete(subCategory);

            return Ok(subCategory);

        }
    }
}
