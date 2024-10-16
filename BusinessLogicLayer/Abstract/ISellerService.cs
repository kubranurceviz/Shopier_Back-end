using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer; 

namespace BusinessLogicLayer.Abstract
{
    public interface ISellerService
    {
        void AddSeller(Seller seller);
        void UpdateSeller(Seller seller);
        void DeleteSeller(Seller seller);
        Seller GetSellerById(int id);
        List<Seller> GetAllSellers();
    }
}
