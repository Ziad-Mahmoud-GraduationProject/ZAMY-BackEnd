﻿using ZAMY.Api.Dtos.mainCategories.outcoming;

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

                    return NotFound($"not found any category has {id} Id !");

                return Ok(maincategory);
        }
<<<<<<< HEAD


=======
        [HttpGet("GetByName{name}")]
        public IActionResult GetByName(string name)
        {

            var subcategories = _maincategoryservice.GetCategoryName(name);

            if (subcategories is null)

                return NotFound($"not found any category has {name} Name !");

            return Ok(subcategories);
        }
>>>>>>> 936ad19888e0b403a108110f24e49f9d68bee6da
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

<<<<<<< HEAD
                return NotFound($"not found any category has {dto.Id} !");
=======
                return NotFound($"not found any category has {id} Id !");
>>>>>>> 936ad19888e0b403a108110f24e49f9d68bee6da

            maincategory.Name = dto.Name; 

            return Ok(_mapper.Map<MainCategoryDto>(_maincategoryservice.Update(maincategory)));
        }


        [HttpPost("Toggel Status")]
        public IActionResult ToggelStatus(int id)
        {
            var maincategory = _maincategoryservice.GetById(id);

            if (maincategory is null)

<<<<<<< HEAD
                return NotFound($"not found any category has {id} !");

            return Ok(_mapper.Map<CreateMainCategoryDto>(_maincategoryservice.ToggelStatus(maincategory)));
=======
                return NotFound($"not found any category has {id} Id !");
            _maincategoryservice.Delete(maincategory);
            return Ok(maincategory);
>>>>>>> 936ad19888e0b403a108110f24e49f9d68bee6da

        }
    }
}
