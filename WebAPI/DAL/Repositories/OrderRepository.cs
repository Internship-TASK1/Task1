using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDbContext _context;

        public OrderRepository(MyDbContext context)
        {
            _context = context;
        }

        // xóa 1 order với id
        public async Task<bool> DeleteOrder(Guid orderId)
        {
            try
            {
                //tìm order trong db
                var order = _context.Orders.FirstOrDefault(or => or.Id == orderId);
                // neu k tồn tại trả về false
                if (order == null)
                {
                    Console.WriteLine($"Order with Order code not found");
                    return false;
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving order: {ex.Message}");
                throw;
            }
        }

        // lấy ra tất cả order
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return await _context.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving order: {ex.Message}");
                throw;
            }
        }

        // lấy ra 1 order = id order
        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            try
            {
                return await _context.Orders.FirstOrDefaultAsync(or => or.Id == orderId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving order: {ex.Message}");
                throw;
            }
        }

        // cập nhật 1 order với id
        public async Task<Order?> UpdateOrder(Order _order)
        {
            // kiem _order co gia tri khong?
            if (_order == null)
            {
                Console.WriteLine($"Order cannot be null for update");
                return null;
            }

            // cập nhật lại LastUpdatedTime = DateTimeOffset.Now
            _order.LastUpdatedTime = DateTimeOffset.Now;
            // cập nhật lại LastUpdatedBy = User hiện tại
            //_order.LastUpdatedBy = ...


            // tiền hành cập nhật
            try
            {
                _context.Orders.Update(_order);
                await _context.SaveChangesAsync();

                // Kiểm tra xem order đó được cập nhật chưa
                return await GetOrderByIdAsync(_order.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the order: {ex.Message}");
                throw;
            }
        }

        // tạo mới 1 order
        public async Task<Order?> InserOrder(Order _order)
        {
            try
            {
                //_order.CreatedBy = Mã người dùng đang đăng nhập
                //
                await _context.Orders.AddAsync( _order);
                await _context.SaveChangesAsync();

                // tìm order vừa insert trong DB
                return await GetOrderByIdAsync(_order.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Inser Order" + ex.Message );
                throw;
            }
        }
    }
}
