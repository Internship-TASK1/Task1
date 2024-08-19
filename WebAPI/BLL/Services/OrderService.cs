using BLL.Services;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            return await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<Order?> UpdateOrder(Order order)
        {
            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task<Order?> InsertOrder(Guid idUser)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                CreatedByUserId = idUser.ToString(),
                OrderDate = DateTimeOffset.UtcNow,
                CreatedTime = DateTimeOffset.UtcNow,
                LastUpdatedTime = DateTimeOffset.UtcNow
                // Set other properties as needed
            };

            return await _orderRepository.InsertOrderAsync(newOrder);
        }
    }
}
