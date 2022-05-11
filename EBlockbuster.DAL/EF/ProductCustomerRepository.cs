using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;

namespace EBlockbuster.DAL.EF
{
    public class ProductCustomerRepository : IProductCustomerRepository
    {
        public Response Delete(int productId, int customerId)
        {
            throw new NotImplementedException();
        }

        public Response<ProductCustomer> Get(int productId, int customerId)
        {
            throw new NotImplementedException();
        }

        public Response<List<ProductCustomer>> GetByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Response<List<ProductCustomer>> GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Response<ProductCustomer> Insert(ProductCustomer productCustomer)
        {
            throw new NotImplementedException();
        }

        public Response Update(ProductCustomer productCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
