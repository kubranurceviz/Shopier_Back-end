using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    using EntityLayer; 

    namespace BusinessLogicLayer.Abstract
    {
        public interface IOrderService
        {
            void AddOrder(Order order);
            void UpdateOrder(Order order);
            void DeleteOrder(Order order);
            Order GetOrderById(int id);
            List<Order> GetAllOrders();
        }
    }


