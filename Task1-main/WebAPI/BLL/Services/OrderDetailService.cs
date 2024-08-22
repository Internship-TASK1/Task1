using Common.DTOs;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailService)
        {
            _orderDetailRepository = orderDetailService;
        }



        // lấy ra tất cả order detail
        public async Task<IEnumerable<OrderDetail>> GetAllOrdersDetail()
        {
            return await _orderDetailRepository.GetAllOrdersDetail();
        }

        //Lấy ra tất cả order detail của 1 order
        public async Task<IEnumerable<OrderDetail>?> GetAllOrdersDetailbyOrderId(Guid orderId)
        {
            return await _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
        }

        // lấy ra 1 order detail = id orderdetail
        public async Task<OrderDetail?> GetOrderDetailById(Guid orderDetailId)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsync(orderDetailId);
            return orderDetail;
        }

        //----------------------------//

        // tạo mới 1 orderDetail truyền vào order với thông tin như: OrderID, ProductId, Quantity
        public async Task<OrderDetail?> InserOrderDetail(Guid OrderID, Guid ProductId, int Quantity)
        {
            //lấy price từ product
            decimal price = await _orderDetailRepository.GetOrderDetailPriceTotal(Quantity, ProductId) ?? -1;
            //nếu price = -1 => product k tồn tại.
            if (price == -1)
            {
                return null;
            }

            //tạo orderDetail
            OrderDetail orderDetail = new OrderDetail()
            {
                Id = new Guid(),
                OrderId = OrderID,
                ProductId = ProductId,
                Quantity = Quantity,
                UnitPrice = price, // Call the method that sums all product prices
                CreatedBy = UserTemp.UserName,
                LastUpdatedBy = String.Empty,
                DeletedBy = String.Empty,
                CreatedTime = DateTime.Now,
                LastUpdatedTime = DateTime.Now
            };

            await _orderDetailRepository.UpdateOrderDetail(orderDetail);

            return await GetOrderDetailById(orderDetail.Id);
        }

        //cập nhật 1 orderDetail với id
        public async Task<OrderDetail?> UpdateOrderDetail(_OrderDetail _orderDetail)
        {

            decimal _unitPrice = await _orderDetailRepository.GetOrderDetailPriceTotal(_orderDetail.Quantity, _orderDetail.ProductId) ?? -1;

            OrderDetail orderDetail = new OrderDetail()
            {
                Id = _orderDetail.Id,//
                OrderId = _orderDetail.OrderId,//
                ProductId = _orderDetail.ProductId,//
                Quantity = _orderDetail.Quantity,//
                UnitPrice = _unitPrice,

                CreatedBy = _orderDetail.CreatedBy, //
                LastUpdatedBy = UserTemp.UserName,

                CreatedTime = _orderDetail.CreatedTime, //

                DeletedBy = _orderDetail.DeletedBy,
                DeletedTime = _orderDetail.DeletedTime,

                LastUpdatedTime = DateTimeOffset.Now,
            };
            
            return await _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        //----------------------------//

        // xóa 1 orderDetail với id
        public async Task<bool> DeleteOrderDetail(Guid orderDetailId)
        {
            var OrdD = await _orderDetailRepository.DeleteOrderDetail(orderDetailId);
            if (!OrdD)
            {
                Console.WriteLine("Delete Order Detail Not Success");
            }
            return OrdD;
        }
    }
}
