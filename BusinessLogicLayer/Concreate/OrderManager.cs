using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EF;
using DataAccessLayer.Repository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concreate
{
    public class OrderManager : IOrderService
    {

        private readonly EfOrderRepository efOrderRepository;

       
        public OrderManager(EfOrderRepository orderRepository)
        {
            efOrderRepository = orderRepository;
        }





        public void AddOrder(Order order)
        {
            // Sipariş içindeki ürünleri dolaşarak her bir ürünün stoklarını güncelle
            foreach (var orderProduct in order.OrderProducts)
            {
                // Her ürün için UpdateProductStock metodunu çağırarak stokları azalt
                efOrderRepository.UpdateProductStock(orderProduct.ProductId, orderProduct.Quantity);
            }

            
            efOrderRepository.Add(order);
        }

        public void DeleteOrder(Order order)
        {

            if (order.Id != 0)
                efOrderRepository.Delete(order);
        }

        public List<Order> GetAllOrders()
        {
            return efOrderRepository.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return efOrderRepository.GetById(id);
        }

        public void UpdateOrder(Order order)
        {
            if (order.Id != 0)
                efOrderRepository.Update(order);
        }
    }
}
