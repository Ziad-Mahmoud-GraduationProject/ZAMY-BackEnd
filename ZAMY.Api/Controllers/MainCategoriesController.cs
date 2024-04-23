using Microsoft.AspNetCore.Authorization;
using ZAMY.Api.Dtos.subCategories.outcoming;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MainCategoriesController
        (IMainCategoryService _maincategoryservice,IMapper _mapper) 
        : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] ZAMY.Application.Common.Helper.PaginationParameters paginationParameters)
        {
                
                var maincategories = _maincategoryservice.GetAll(paginationParameters);

            if (maincategories is null)

                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<IEnumerable<MainCategoryDto>>(maincategories)));
        }
  
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {

            var maincategory = _maincategoryservice.GetById(id);
                if (maincategory is null)

                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<MainCategoryDto> (maincategory)));
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name, [FromQuery] ZAMY.Application.Common.Helper.PaginationParameters paginationParameters)
        {
            var maincategories = _maincategoryservice.GetCategoryName(name, paginationParameters);

            if (maincategories is null)
                return Ok(ResponseFinal.NotFound());

            return Ok(ResponseFinal.Ok(Result: _mapper.Map<MainCategoryDto>(maincategories)));
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateMainCategoryDto dto)
        {
            var maincategory= _maincategoryservice.Add1( _mapper.Map<MainCategory>(dto),dto.Img);
            if (maincategory == null)
            {
                return Ok(ResponseFinal.BadRequest());
            }

            return Ok(ResponseFinal.Ok(Result: maincategory));

        }
       

        [HttpPut("Update")]
        public IActionResult Update(int id,EditMainCategory dto)
        {
            var maincategory = _maincategoryservice.Update1(id, _mapper.Map<MainCategory>(dto), dto.Img);
            if (maincategory is null)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok(Result: maincategory));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _maincategoryservice.Delete(id);
            if (!deleted)
            {
                return Ok(ResponseFinal.NotFound());
            }

            return Ok(ResponseFinal.Ok());
        }
    }
}
