using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using FieldAgent.DAL;
using Microsoft.EntityFrameworkCore;

namespace EBlockbuster.DAL.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbContextOptions Dbco;

        public CategoryRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
            //DbFac = dbfac;
        }
        public Response Delete(int categoryId)
        {

            throw new NotImplementedException();
        }

        public Response<Category> Get(int categoryId)       //consider try catches
        {
            Response<Category> response = new Response<Category>();

            using (var db = new AppDbContext(Dbco))
            {
                response.Data = db.Categories.Find(categoryId);
                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = $"Could not find Category ID: {categoryId}";
                }
                else
                {
                    response.Success = true;
                    response.Message = $"Category ID: {categoryId}";
                }
            }
            return response;
        }

        public Response<Category> Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public Response Update(Category category)
        {
            throw new NotImplementedException();
        }

        public void SetKnownGoodState()
        {
            using (var db = new AppDbContext(Dbco))
            {
                db.Database.ExecuteSqlRaw("SetKnownGoodState");
            }
        }
    }
}
