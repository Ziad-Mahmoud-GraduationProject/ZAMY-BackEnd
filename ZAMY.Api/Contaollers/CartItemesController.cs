using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ZAMY.Api.Dtos.CartItem.incommig;
using ZAMY.Api.Dtos.CartItem.outcomming;
using ZAMY.Application.Services.CartItems;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemesController(ICartItemService _cartItemService,
        IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var cartItems = _cartItemService.GetAll();
            if (cartItems is null)
                return NotFound("NotFound Any CartItems");
            var dto = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);
                return Ok(dto);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var cartItem = _cartItemService.GetById(id);
            if (cartItem is null)
                return NotFound($"NotFound Any CartItem has {id} Id");
            var dto = _mapper.Map<CartItemDto>(cartItem);
            return Ok(dto);
        }
        [HttpPost("Add")]
        public IActionResult Add(CreateCartItem item)
        {
            var cartItem=_mapper.Map<CartItem>(item);
            /*var cartItem = new CartItem
            {
                Quantity= item.Quantity,
                MealId= item.MealId,
                CartId= item.CartId,
                orderId=item.orderId
            };*/
            _cartItemService.Add(cartItem);
            return Ok(cartItem);
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, EditCartItem item)
        {
            var cartItem = _cartItemService.GetById(id);
            if (cartItem is null)
                return NotFound($"NotFound Any CartItem has {id} Id");

            cartItem.Quantity = item.Quantity;
            cartItem.MealId = item.MealId;
            cartItem.CartId = item.CartId;
            cartItem.orderId = item.orderId;
    
            _cartItemService.Update(cartItem);
            return Ok(cartItem);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var cartItem = _cartItemService.GetById(id);
            if (cartItem is null)
                return NotFound($"NotFound Any CartItem has {id} Id");
            _cartItemService.Delete(cartItem);
            return Ok(cartItem);    
        }
    }
}
