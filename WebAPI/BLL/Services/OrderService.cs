using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        // khởi tại OrderService để gán orderRepository cho _orderRepository
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // xóa 1 order với id
        public Task<bool> DeleteOrder(Guid orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        // lấy ra tất cả order
        public Task<IEnumerable<Order>> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        // lấy ra 1 order = id order
        public Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return _orderRepository.GetOrderByIdAsync(orderId);
        }

        //tạo mới 1 order
        public Task<Order?> InserOrder(Guid idUser)
        {
            // tạo tự động order
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = idUser,
                OrderDate = DateTimeOffset.Now,
                CreatedBy = null,
                LastUpdatedBy = null,
                DeletedBy = null,
                CreatedTime = DateTimeOffset.Now,
                LastUpdatedTime = DateTimeOffset.Now,
                DeletedTime = null,
                CreatedByUser = null, // lấy từ JWT khi đăng nhập thì lưu lại
                ProcessedByUser = null,
            };
            return _orderRepository.InserOrder(order);
        }

        // cập nhật 1 order với id
        public Task<Order?> UpdateOrder(Order _order)
        {
            return _orderRepository.UpdateOrder(_order);
        }
    }
}
