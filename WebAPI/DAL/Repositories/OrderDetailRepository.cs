using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly MyDbContext _context;

        public OrderDetailRepository(MyDbContext context)
        {
            _context = context;
        }

        // lấy orderDetail bằng orderDetailId
        public async Task<OrderDetail?> GetOrderDetailByIdAsync(Guid orderDetailId)
        {
            try
            {
                var orD = await _context.OrderDetails.FirstOrDefaultAsync(ord => ord.Id == orderDetailId);
                if (orD == null)
                {
                    Console.WriteLine("Kiem tra lai OrderDetailId");
                }
                return orD;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving Order Detail: {ex.Message}");
                throw;
            }
        }

        // lấy danh sách các order detail của 1 order bằng orderId
        public async Task<IEnumerable<OrderDetail>?> GetOrderDetailsByOrderId(Guid orderId)
        {
            try
            {
                var Ord = await _context.OrderDetails.Where(ord => ord.OrderId == orderId).ToListAsync();
                if (Ord == null)
                {
                    Console.WriteLine("order ID không tìm thấy");
                }
                return Ord;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving Order Detail: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrdersDetail()
        {
            try
            {
                return await _context.OrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving order detail: {ex.Message}");
                throw;
            }
        }

        //----------------------------//

        //insert 1 order detail
        public async Task<OrderDetail?> InsertOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                //_order.CreatedBy = Mã người dùng đang đăng nhập
                //
                await _context.OrderDetails.AddAsync(orderDetail);
                await _context.SaveChangesAsync();

                // tìm và trả về orderDetail vừa insert trong DB
                return await GetOrderDetailByIdAsync(orderDetail.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Inser Order Detail" + ex.Message);
                throw;
            }
        }

        //update 1 order detail 
        public async Task<OrderDetail?> UpdateOrderDetail(OrderDetail _orderDetail)
        {
            try
            {
                _context.OrderDetails.Update(_orderDetail);
                await _context.SaveChangesAsync();

                // Kiểm tra xem order detail đó được cập nhật 
                return await GetOrderDetailByIdAsync(_orderDetail.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the order detail: {ex.Message}");
                throw;
            }
        }

        //----------------------------//

        //delete 1 order detail
        public async Task<bool> DeleteOrderDetail(Guid orderDetailId)
        {
            try
            {
                //tìm order detail trong db
                var orderD = _context.OrderDetails.FirstOrDefault(ord => ord.Id == orderDetailId);
                // neu k tồn tại trả về false
                if (orderD == null)
                {
                    Console.WriteLine($"Order with Order detail not found");
                    return false;
                }
                _context.OrderDetails.Remove(orderD);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving order detail: {ex.Message}");
                throw;
            }
        }

        public async Task<decimal?> GetOrderDetailPriceTotal(int Quantity, Guid idProduct)
        {
            decimal priceTotal = -1;

            var product = await _context.Products.FirstOrDefaultAsync(pro => pro.Id == idProduct);

            if (product != null)
            {
                priceTotal = product.Price * Quantity;
            }

            return priceTotal;
        }
    }
}
