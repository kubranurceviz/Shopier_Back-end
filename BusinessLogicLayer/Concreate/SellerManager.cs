using BusinessLogicLayer.Abstract;
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
    public class SellerManager : ISellerService
    {
        private readonly EfSellerRepository efSellerRepository;


        public SellerManager(EfSellerRepository sellerRepository)
        {
            efSellerRepository = sellerRepository;
        }


        public void AddSeller(Seller seller)
        {
            efSellerRepository.Add(seller);
        }

        public void DeleteSeller(Seller seller)
        {
            if (seller.Id != 0)
                efSellerRepository.Delete(seller);
        }

        public List<Seller> GetAllSellers()
        {
            return efSellerRepository.GetAll();
        }

        public Seller GetSellerById(int id)
        {
            return efSellerRepository.GetById(id);
        }

        public void UpdateSeller(Seller seller)
        {
            if (seller.Id != 0)
                efSellerRepository.Update(seller);
        }
    }
}
