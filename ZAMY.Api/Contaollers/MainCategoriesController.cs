using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var maincategories = _maincategoryservice.GetAll();

                if (maincategories is null)

                    return NotFound("not found any category !");

                return Ok(maincategories);
            }
            catch (Exception ex)
            {
                return BadRequest($" exist error bcz {ex.Message}");
            }
        }

        [HttpGet("GetById{Id}")]
        public IActionResult GetById(int id)
        {
           
                var maincategories = _maincategoryservice.GetById(id);

                if (maincategories is null)

                    return NotFound("not found any category !");

                return Ok(maincategories);
            
           
        }
    }
}
