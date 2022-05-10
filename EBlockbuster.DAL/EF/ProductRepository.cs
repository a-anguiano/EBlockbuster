using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core;

namespace EBlockbuster.DAL.EF
{
    public class ProductRepository : IProductRepository
    {
        public Response Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public Response<Product> Get(int productId)
        {
            throw new NotImplementedException();
        }

        public Response<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Response<Product> Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public Response Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
