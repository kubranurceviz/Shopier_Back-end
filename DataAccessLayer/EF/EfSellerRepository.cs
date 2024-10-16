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
    public class EfSellerRepository : GenericRepository<Seller>, ISellerDal
    {
        public EfSellerRepository(DbContextOptions<Context> options, IConfiguration configuration) : base(options, configuration)
        {
        }
    }
}
