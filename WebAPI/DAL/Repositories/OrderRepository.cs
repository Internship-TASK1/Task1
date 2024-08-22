using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;

        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order?> UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
            {
                return null;
            }

            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order?> InsertOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
