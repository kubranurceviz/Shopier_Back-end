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


namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly EfProductRepository efProductRepository;


        public ProductManager(EfProductRepository productRepository)
        {
            efProductRepository = productRepository;
        }



        public void AddProduct(Product product)
        {
            efProductRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product.Id != 0)
                efProductRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product.Id != 0)
                efProductRepository.Delete(product);
        }

        public Product GetProductById(int id)
        {
            return efProductRepository.GetById(id);
        }

        public List<Product> GetAllProducts()
        {
            return efProductRepository.GetAll();
        }
    }
}
    
