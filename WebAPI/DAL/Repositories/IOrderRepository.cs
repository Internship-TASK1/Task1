using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task<OrderDetail> GetOrderDetailByIdAsync(Guid orderDetailId);
    }
}
