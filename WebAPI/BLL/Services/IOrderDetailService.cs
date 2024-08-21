using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IOrderDetailService
    {
        // lấy ra 1 order detail = id orderdetail
        Task<OrderDetail?> GetOrderDetailById(Guid orderDetailId);

        // lấy ra tất cả order detail
        Task<IEnumerable<OrderDetail>> GetAllOrdersDetail();

        //Lấy ra tất cả order detail của 1 order
        Task<IEnumerable<OrderDetail>?> GetAllOrdersDetailbyOrderId(Guid orderId);

        // xóa 1 orderDetail với id
        Task<bool> DeleteOrderDetail(Guid orderDetailId);

        //// cập nhật 1 orderDetail với id  
        Task<OrderDetail?> UpdateOrderDetail(_OrderDetail _orderDetail);

        //tạo mới 1 orderDetail truyền vào order với thông tin như: OrderID, ProductId, Quantity
        Task<OrderDetail?> InserOrderDetail(Guid OrderID, Guid ProductId, int Quantity);
    }
}
