using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using ZAMY.Api.Dtos.Categories.outcoming;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController(ICategoryService _categoryService, IMapper _mapper) : ControllerBase
    {

        [HttpGet("")]
        public IActionResult Get()
        { 
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(_categoryService.GetAll());

            return Ok(categories);
        }


        [HttpGet("id/{id}")]
        public IActionResult Get(int id)
        {
            var category = _mapper.Map<CategoryDto>(_categoryService.GetById(id));

            return Ok(category);
        }

        [HttpGet("name/{name}")]
        public IActionResult Get(string name)
        {
            var category = _mapper.Map<IEnumerable<CategoryDto>>(_categoryService.GetByName(name));

            return Ok(category);
        }


        [HttpPost("")]
        public IActionResult Add(CategoryDto categoryDto) 
        { 
            var category = _categoryService.Add(_mapper.Map<Category>(categoryDto));

            return Ok(category);
        }


        [HttpPost("{id}")]
        public IActionResult Edit(int id,CategoryDto categoryDto)
        {
            return Ok();
        }
    }
}
