using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Response<Customer> Insert(Customer customer);

        Response Update(Customer customer);

        Response Delete(int customerId);

        Response<Customer> Get(int customerId);

        Response<List<Customer>> GetAll();

        Response<List<Customer>> GetCustomerByProduct(int productId);

        Response<Customer> GetCustomerByEmail(string email);

        Response<Customer> GetCustomerByLoginId (int loginId);

    }
}
