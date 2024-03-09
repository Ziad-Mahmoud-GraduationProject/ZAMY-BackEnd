using ZAMY.Api.Dtos.Orders.incomming;
using ZAMY.Api.Dtos.Orders.outcomming;
using ZAMY.Application.Services.Orders;

namespace ZAMY.Api.Contaollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService _orderService,
        IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            if(orders is null)
                return NotFound($"NotFound Any Orders");
            var dto=_mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(dto);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            if (order is null)
                return NotFound($"NotFound Any Order has {id} Id");
            var dto = _mapper.Map<OrderDto>(order);
            return Ok(dto);
        }
        [HttpPost("Add")]
        public IActionResult Add(CreateOrder dto) 
        { 
            var order=_mapper.Map<Order>(dto);
            _orderService.Add(order);
            return Ok(order);
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id,EditOrder dto)
        {
            var order = _orderService.GetById(id);
            if (order is null)
                return NotFound($"NotFound Any Order has {id} Id");
            order.PaymentMethod=dto.PaymentMethod;
            order.Status = dto.Status;
            order.OrderDate=dto.OrderDate;
            order.Notes=dto.Notes;
            order.KitchenId=dto.KitchenId;
            order.CustomerId=dto.CustomerId;
            _orderService.Update(order);
            return Ok(order);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetById(id);
            if (order is null)
                return NotFound($"NotFound Any Order has {id} Id");
            _orderService.Delete(order);
            return Ok(order);
        }
    }
}
