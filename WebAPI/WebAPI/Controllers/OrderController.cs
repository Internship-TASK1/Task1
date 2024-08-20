using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // lấy ra tất cả order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var order = await _orderService.GetAllOrders();
            return Ok(order);
        }

        // lấy ra 1 order = id order
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        //tạo mới 1 order
        [HttpPost]
        public async Task<ActionResult> AddOrder()
        {
            Order? order = await _orderService.InsertOrder();

            if (order == null)
            {
                return BadRequest();
            }

            return Ok(order);
        }


        //Xóa 1 order
        [HttpDelete("{id}")]
        public async Task<ActionResult> DelOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);
            return NoContent();
        }

        // cập nhật 1 order với id
        [HttpPut]
        public async Task<ActionResult<Order>> UpdateOrder(Order order)
        {
            if(order == null)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrder(order);
            return NoContent();
        }
    }
}
