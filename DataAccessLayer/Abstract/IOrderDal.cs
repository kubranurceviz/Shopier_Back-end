using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        // Sipariş spesifik metodlar eklenebilir
        void UpdateProductStock(int productId, int quantity);
    }


}
