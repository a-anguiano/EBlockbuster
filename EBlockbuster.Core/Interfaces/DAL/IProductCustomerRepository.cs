using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface IProductCustomerRepository
    {
        Response<ProductCustomer> Insert(ProductCustomer productCustomer);
        Response Update(ProductCustomer productCustomer);
        Response DeleteByProduct(int productId);
        Response DeleteByCustomer(int customerId);
        /*Response<ProductCustomer> Get(int productId, int customerId);*/
        Response<List<ProductCustomer>> GetByProductId(int productId);
        Response<List<ProductCustomer>> GetByCustomerId(int customerId);
    }
}
