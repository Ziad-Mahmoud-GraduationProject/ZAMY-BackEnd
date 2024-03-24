using System.Collections.Generic;
using ZAMY.Api.Dtos.Categories.outcoming;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService, IMapper _mapper) : ControllerBase
    {

        [HttpGet("")]
        public ActionResult<ApiResponse> Get()
        { 
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(_categoryService.GetAll());

            return new ApiResponse();
        }


        [HttpGet("id/{id}")]
        public ActionResult<ApiResponse> Get(int id)
        {
            var category = _mapper.Map<CategoryDto>(_categoryService.GetById(id));

            return new ApiResponse();
        }

        [HttpGet("name/{name}")]
        public ActionResult<ApiResponse> Get(string name)
        {
            var category = _mapper.Map<IEnumerable<CategoryDto>>(_categoryService.GetByName(name));


            return new ApiResponse();
        }


        [HttpPost("")]
        public ActionResult<ApiResponse> Add(CategoryDto categoryDto) 
        { 
            var category = _categoryService.Add(_mapper.Map<Category>(categoryDto));

            return new ApiResponse();
        }


        [HttpPost("{id}")]
        public ActionResult<ApiResponse> Edit(int id,CategoryDto categoryDto)
        {
           
            return new ApiResponse();
        }
    }
}
