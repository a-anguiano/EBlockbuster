using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface IProductRepository
    {
        //Add
        Response<Product> Insert(Product product);
        //Update
        Response Update(Product product);
        //Delete
        Response Delete(int productId);
        //Get
        Response<Product> Get(int productId);
        //GetAll
        Response<List<Product>> GetAll();
    }
}
