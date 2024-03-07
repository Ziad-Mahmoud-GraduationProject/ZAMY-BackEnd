using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAMY.Api.Dtos.Kitchen.incoming;
using ZAMY.Api.Dtos.Kitchen.outcoming;
using ZAMY.Application.Services.Kitchens;
using ZAMY.Domain.Entities;
using ZAMY.Domain.Enums;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenesController(IKitchenService _kitchenService,
        IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var kitchenes= _kitchenService.GetAll();
            if(kitchenes is null)
                return NotFound("Not Found Any Kitchen !");
            var kitchenesDto=_mapper.Map<IEnumerable<KitchenDto>>(kitchenes);
            return Ok(kitchenesDto);
            
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var kitchen = _kitchenService.GetById(id);
            if (kitchen is null)
                return NotFound($"Not Found Any Kitchen has {id} Id !");
            var kitchenDto=_mapper.Map<KitchenDto>(kitchen);
            return Ok(kitchenDto);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var kitchenes = _kitchenService.GetKitchenName(name);
            if (kitchenes is null)
                return NotFound($"Not Found Any Kitchen has {name} Name !");
            var kitchenesDto = _mapper.Map<IEnumerable<KitchenDto>>(kitchenes);
            return Ok(kitchenesDto);
        }
        [HttpPost]
        public IActionResult Add(CreateKitchenDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var kitchen = _mapper.Map<Kitchen>(dto);
            _kitchenService.Add(kitchen);
            return Ok(kitchen);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id,EditKitchenDto dto)
        {
            var kitchen = _kitchenService.GetById(id);
            if (kitchen is null)
                return NotFound($"Not Found Any Kitchen has {id} Id !");

            kitchen.Name = dto.Name;
            kitchen.IsActive = dto.IsActive;
            kitchen.OwnerId = dto.OwnerId;
            kitchen.FirstName = dto.FirstName;
            kitchen.MiddleName = dto.MiddleName;
            kitchen.LastName = dto.LastName;
            kitchen.NationalId = dto.NationalId;
            kitchen.Governorate = dto.Governorate;
            kitchen.City = dto.City;
            kitchen.Region = dto.Region;
            kitchen.StreetNumber = dto.StreetNumber;
            kitchen.StreetName = dto.StreetName;
            kitchen.BirthOfDate = dto.BirthOfDate;
            kitchen.Gender = dto.Gender;
            kitchen.LandLineNumber = dto.LandLineNumber;
            kitchen.UpdateOn=dto.UpdateOn;
            kitchen.UpdatedById = dto.UpdatedById;
            _kitchenService.Update(kitchen);
            return Ok(kitchen);
        }
        [HttpDelete("ToggelStatus")]
        public IActionResult ToggelStatus(int id)
        {
            var kitchen = _kitchenService.GetById(id);
            if (kitchen is null)
                return NotFound($"Not Found Any Kitchen has {id} Id !");
            _kitchenService.ToggelStatus(kitchen);
            return Ok(kitchen);
        }
    }
}
