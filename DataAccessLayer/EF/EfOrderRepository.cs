using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class EfOrderRepository : GenericRepository<Order>, IOrderDal
    {
        private readonly Context _context;
        public EfOrderRepository(DbContextOptions<Context> options, IConfiguration configuration) : base(options, configuration)
        {
            _context = new Context(options, configuration);
        }

        public void UpdateProductStock(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.StockAmount >= quantity)
            {
                // Eğer yeterli stok varsa miktarı azalt
                product.StockAmount -= quantity;
                _context.SaveChanges();  // Değişiklikleri veritabanına kaydet
            }
            else
            {
                throw new Exception("Yeterli stok yok.");
            }
        }
    }
    }

