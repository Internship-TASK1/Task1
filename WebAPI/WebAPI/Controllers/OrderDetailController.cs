using BLL.Services;
using Common.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService orderDetailService;

        public OrderDetailController(IOrderDetailService _orderDetailService)
        {
            orderDetailService = _orderDetailService;
        }

        // lấy ra 1 order detail = id orderdetail
        [HttpGet("Get OrderDetail by ID OrderDetil")]
        public async Task<OrderDetail?> GetOrderDetailById(Guid orderDetailId)
        {
            return await orderDetailService.GetOrderDetailById(orderDetailId);
        }


        //// lấy ra tất cả order detail
        [HttpGet("Get All OrderDetails")]
        public async Task<IEnumerable<OrderDetail>> GetAllOrdersDetail()
        {
            return await orderDetailService.GetAllOrdersDetail();
        }

        //Lấy ra tất cả order detail của 1 order
        [HttpGet("Get OrderDetails by ID Order")]
        public async Task<IEnumerable<OrderDetail>?> GetAllOrdersDetailbyOrderId(Guid orderId)
        {
            return await orderDetailService.GetAllOrdersDetailbyOrderId(orderId);
        }

        // xóa 1 orderDetail với id
        [HttpDelete]
        public async Task<ActionResult> DeleteOrderDetail(Guid orderDetailId)
        {
            bool result = await orderDetailService.DeleteOrderDetail(orderDetailId);

            if (result)
            {
                return Ok("Delete Success!");
            }
            else
            {
                return BadRequest("Delete Not Success");
            }
        }

        // cập nhật 1 orderDetail với id  
        [HttpPut]
        public async Task<ActionResult<OrderDetail?>> UpdateOrderDetail(_OrderDetail _orderDetail)
        {
            return await orderDetailService.UpdateOrderDetail(_orderDetail);
        }

        //tạo mới 1 orderDetail truyền vào order với thông tin như: OrderID, ProductId, Quantity
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> InserOrderDetail(Guid OrderID, Guid ProductId, int Quantity)
        {
            if(UserTemp.Id == string.Empty || UserTemp.UserName == string.Empty)
            {
                return BadRequest("Please Log In!!");
            }
                

            //tạo order detail
            var ordD = await orderDetailService.InserOrderDetail(OrderID, ProductId, Quantity);

            //kiểm tra order vừa tạo có thành công không?
            if (ordD != null)
            {
                return Ok(ordD);
            }
            return BadRequest("Insert Not Success!!");
        }


        //Việc lọc các OrderDetail chưa hoàn thành có thể nên thực hiên ở phía fontend :
        // + do lọc khá đơn giản. 
    }
}
