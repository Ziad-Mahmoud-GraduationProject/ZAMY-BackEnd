using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAMY.Api.Dtos.mainCategories;
using ZAMY.Application.Common.Interfaces;
using ZAMY.Application.Services.MainCategories;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoriesController(IMainCategoryService _maincategoryservice) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

                var maincategories = _maincategoryservice.GetAll();

                if (maincategories is null)

                    return NotFound("not found any category !");

                return Ok(maincategories);   
        }

        [HttpGet("GetById{id}")]
        public IActionResult GetById(int id)
        {
           
                var maincategories = _maincategoryservice.GetById(id);

                if (maincategories is null)

                    return NotFound($"not found any category has {id} !");

                return Ok(maincategories);
        }
        [HttpPost("Add")]
        public IActionResult Add(MainCategoryDto dto)
        {
            var maincategory = new MainCategory
            {
                Name=dto.Name
            };
            _maincategoryservice.Add(maincategory);
            return Ok(maincategory);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id,MainCategoryDto dto)
        {
            var maincategory = _maincategoryservice.GetById(id);

            if (maincategory is null)

                return NotFound($"not found any category has {id} !");

            maincategory.Name = dto.Name;
            _maincategoryservice.Update(maincategory);
            return Ok(maincategory);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var maincategory = _maincategoryservice.GetById(id);

            if (maincategory is null)

                return NotFound($"not found any category has {id} !");
            _maincategoryservice.Delete(maincategory);
            return Ok(maincategory);

        }
    }
}
