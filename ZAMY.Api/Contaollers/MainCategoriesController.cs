using ZAMY.Api.Dtos.mainCategories.outcoming;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoriesController
        (IMainCategoryService _maincategoryservice,IMapper _mapper) 
        : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

                var maincategories = _mapper.Map<IEnumerable<MainCategoryDto>>(_maincategoryservice.GetAll());

                if (maincategories is null)

                    return NotFound("not found any category !");

                return Ok(maincategories);   
        }


        [HttpGet("Get With Meals")]
        public IActionResult Get(int id)
        {
            var maincategories = _mapper.Map<IEnumerable<MainCategoryDto>>(_maincategoryservice.GetAll());

            if (maincategories is null)

                return NotFound("not found any category !");

            return Ok(maincategories);
        }

        [HttpGet("GetById{id}")]
        public IActionResult GetById(int id)
        {
           
                var maincategory = _mapper.Map<MainCategoryDto>(_maincategoryservice.GetById(id));

                if (maincategory is null)

                    return NotFound($"not found any category has {id} !");

                return Ok(maincategory);
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


        [HttpPost("Toggel Status")]
        public IActionResult ToggelStatus(int id)
        {
            var maincategory = _maincategoryservice.GetById(id);

            if (maincategory is null)

                return NotFound($"not found any category has {id} !");

            return Ok(_mapper.Map<CreateMainCategoryDto>(_maincategoryservice.ToggelStatus(maincategory)));

        }
    }
}
