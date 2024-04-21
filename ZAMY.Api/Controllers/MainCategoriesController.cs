using Microsoft.AspNetCore.Authorization;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MainCategoriesController
        (IMainCategoryService _maincategoryservice,IMapper _mapper) 
        : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] ZAMY.Application.Common.Helper.PaginationParameters paginationParameters)
        {
                
                var maincategories = _mapper.Map<IEnumerable<MainCategoryDto>>(_maincategoryservice.GetAll(paginationParameters));

                if (maincategories is null)

                    return NotFound("not found any category !");

                return Ok(maincategories);   
        }
        // EXplain or maintain or test

       /* [HttpGet("GetWithMeals/{id}")]
        public IActionResult Get(int id)
        {
            var maincategories = _mapper.Map<IEnumerable<MainCategoryDto>>(_maincategoryservice.GetAll());

            if (maincategories is null)

                return NotFound("not found any category !");

            return Ok(maincategories);
        }*/

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
           
                var maincategory = _mapper.Map<MainCategoryDto>(_maincategoryservice.GetById(id));

                if (maincategory is null)

                    return NotFound($"not found any category has {id} Id !");

                return Ok(maincategory);
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name, [FromQuery] ZAMY.Application.Common.Helper.PaginationParameters paginationParameters)
        {
            var maincategories = _mapper.Map<MainCategoryDto>(_maincategoryservice.GetCategoryName(name, paginationParameters));
           
            if (maincategories is null)

                return NotFound($"not found any category has {name} Name !");

            return Ok(maincategories);
        }

        [HttpPost("Add")]
        public IActionResult Add(CreateMainCategoryDto dto)
        {
            var maincategory = _mapper.Map<MainCategory>(dto);

            return Ok(_mapper.Map<MainCategoryDto>(_maincategoryservice.Add(maincategory)));

        }
        [HttpPut("Update")]
        public IActionResult Update(EditMainCategory dto)
        {
            var maincategory = _maincategoryservice.GetById(dto.Id);

            if (maincategory is null)


                return NotFound($"not found any category has {dto.Id} !");


            maincategory.Name = dto.Name; 

            return Ok(_mapper.Map<MainCategoryDto>(_maincategoryservice.Update(maincategory)));
        }


        [HttpPost("ToggelStatus")]
        public IActionResult ToggelStatus(int id)
        {
            var maincategory = _maincategoryservice.GetById(id);

            if (maincategory is null)

                return NotFound($"not found any category has {id} Id !");
            return Ok(_mapper.Map<MainCategoryDto>(_maincategoryservice.ToggelStatus(maincategory)));
        }
    }
}
