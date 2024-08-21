using BLL.Services;
using Common.DTOs;
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
            Order _order = order;
            _order.LastUpdatedBy = UserTemp.UserName;
            _order.LastUpdatedTime = DateTimeOffset.Now;
            
            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task<Order?> InsertOrder()
        {
            string id = UserTemp.Id;
            string usName = UserTemp.UserName;

            var newOrder = new Order
            {
                Id = Guid.NewGuid(),

                CreatedByUserId = id,
                ProcessedByUserId = id,
                LastUpdatedBy = usName,
                CreatedBy = usName,

                OrderDate = DateTimeOffset.UtcNow,
                CreatedTime = DateTimeOffset.UtcNow,
                LastUpdatedTime = DateTimeOffset.UtcNow
            };

            return await _orderRepository.InsertOrderAsync(newOrder);
        }
    }
}
