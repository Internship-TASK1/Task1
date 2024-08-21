using DAL.Entities;

namespace DAL.Repositories
{
    public interface IOrderDetailRepository
    {
        // get all Order detail
        Task<IEnumerable<OrderDetail>> GetAllOrdersDetail();

        // get Order detail by id order
        Task<OrderDetail?> GetOrderDetailByIdAsync(Guid orderDetailId);

        // get List order detail with orderId
        Task<IEnumerable<OrderDetail>?> GetOrderDetailsByOrderId(Guid orderId);

        //insert 1 order detail
        Task<OrderDetail?> InsertOrderDetail(OrderDetail orderDetail);

        //delete 1 order detail
        Task<bool> DeleteOrderDetail(Guid orderId);

        //update 1 order detail 
        Task<OrderDetail?> UpdateOrderDetail(OrderDetail _orderDetail);

        //tinh tien cua 1 order
        Task<decimal?> GetOrderDetailPriceTotal(int Quantity, Guid idProduct);
    }
}
