using DAL.Entities;

namespace BLL.Services
{
    public interface IOrderService
    {
        // lấy ra 1 order = id order
        Task<Order?> GetOrderByIdAsync(Guid orderId);

        // lấy ra tất cả order
        Task<IEnumerable<Order>> GetAllOrders();

        // xóa 1 order với id
        Task<bool> DeleteOrder(Guid orderId);

        // cập nhật 1 order với id  
        Task<Order?> UpdateOrder(Order _order);

        //tạo mới 1 order truyền vào order với thông tin như: UserID
        Task<Order?> InserOrder(Guid idUser);
    }
}
