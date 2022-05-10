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
    public class CategoryRepository : ICategoryRepository
    {
        public Response Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Response<Product> Get(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Response<Category> Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public Response Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
