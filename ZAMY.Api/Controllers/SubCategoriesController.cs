
using ZAMY.Api.Dtos.subCategories.incomming;
using ZAMY.Api.Dtos.subCategories.outcoming;
using ZAMY.Application.Services.SubCategories;
namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController(ISubCategoryService _subCategoryService,
        IMapper _mapper) : ControllerBase
    {
      
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] ZAMY.Application.Common.Helper.PaginationParameters paginationParameters)
        {

            var subcategories = _subCategoryService.GetAll(paginationParameters);

            if (subcategories is null)

                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<IEnumerable<SubCategoryDto>>(subcategories)));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            var subcategory = _subCategoryService.GetById(id);
            if (subcategory is null)

                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<SubCategoryDto>(subcategory)));
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {

            var subcategories = _subCategoryService.GetCategoryName(name);

            if (subcategories is null)

                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<SubCategoryDto>(subcategories)));
        }
        [HttpPost("Add")]
        public IActionResult Add(CreateSubCategoryDto dto)
        {
            var subcategory = _subCategoryService.Add(_mapper.Map<SubCategory>(dto), dto.Img);
            if (subcategory == null)
            {
                return Ok(ResponseFinal.BadRequest());
            }

            return Ok(ResponseFinal.Ok(Result: subcategory));
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, EditSubCategoryDto dto)
        {
            var subcategory = _subCategoryService.Update(id, _mapper.Map<SubCategory>(dto), dto.Img);
            if (subcategory is null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: subcategory));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _subCategoryService.Delete(id);
            if (!deleted)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok());

        }
    }
}
