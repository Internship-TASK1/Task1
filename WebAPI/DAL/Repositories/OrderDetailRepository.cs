using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MyDbContext _context;

        public OrderDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        // lấy danh sách các order của 1 order bằng orderDetailId
        public async Task<OrderDetail?> GetOrderDetailByIdAsync(Guid orderDetailId)
        {
            try
            {
                return await _context.OrderDetails.FirstOrDefaultAsync( ord => ord.Id == orderDetailId );
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving categories: {ex.Message}");
                throw;
            }
        }

        // lấy danh sách các order detail của 1 order bằng orderId
        public async Task<IEnumerable<OrderDetail>?> GetOrderDetailsByOrderId(Guid orderId)
        {
            try
            {
                return await _context.OrderDetails.Where(ord => ord.OrderId == orderId).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving categories: {ex.Message}");
                throw;
            }
        } 
    }
}
