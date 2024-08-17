using DAL.Entities;

namespace DAL.Repositories
{
    internal interface IOrderDetailRepository
    {
        Task<OrderDetail?> GetOrderDetailByIdAsync(Guid orderDetailId);
        Task<IEnumerable<OrderDetail>?> GetOrderDetailsByOrderId(Guid orderId);
    }
}
