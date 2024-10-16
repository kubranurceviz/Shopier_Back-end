using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public Seller Seller { get; set; }
        public int SellerId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }

}
