using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core;
using EBlockbuster.Core.DTOs;
using EBlockbuster.Core.Interfaces;

namespace EBlockbuster.DAL.ADO
{
    public class SqlReportsRepository : IReportsRepository
    {
        public Response<LeastProfitableItem> GetLeastProfitable()
        {
            throw new NotImplementedException();
        }

        public Response<LeastProfitableItemByCategory> GetLeastProfitableByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Response<List<MostProfitableItem>> GetMostProfitable()
        {
            throw new NotImplementedException();
        }

        public Response<MostProfitableItemByCategory> GetMostProfitableByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        Response<MostProfitableItem> IReportsRepository.GetMostProfitable()
        {
            throw new NotImplementedException();
        }
    }
}
