using EBlockbuster.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface IReportsRepository
    {
        //Response<MostProfitableItem> GetMostProfitable();
        //Response<MostProfitableItemByCategory> GetMostProfitableByCategory(int categoryId);
        //Response<LeastProfitableItem> GetLeastProfitable();
        //Response<LeastProfitableItemByCategory> GetLeastProfitableByCategory(int categoryId);
        Response<List<TopThreeRentedProducts>> GetTopThreeRentedProducts();
    }
}
