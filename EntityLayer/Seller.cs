using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Seller
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string StoreLink { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
    }

}
