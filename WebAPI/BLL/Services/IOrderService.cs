using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IOrderService
    {
        // Get an order by its ID
        Task<Order?> GetOrderByIdAsync(Guid orderId);

        // Get all orders
        Task<IEnumerable<Order>> GetAllOrders();

        // Delete an order by its ID
        Task<bool> DeleteOrder(Guid orderId);

        // Update an order
        Task<Order?> UpdateOrder(Order order);

        // Insert a new order
        Task<Order?> InsertOrder();
    }
}
