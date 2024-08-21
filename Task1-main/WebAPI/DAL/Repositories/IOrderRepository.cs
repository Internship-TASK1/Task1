using DAL.Entities;

namespace DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<Order>?> GetAllOrdersAsync(); // Ensure this method is defined
        Task<bool> DeleteOrderAsync(Guid orderId); // Ensure this method is defined
        Task<Order?> UpdateOrderAsync(Order order); // Ensure this method is defined
        Task<Order?> InsertOrderAsync(Order order); // Ensure this method is defined
    }
}
