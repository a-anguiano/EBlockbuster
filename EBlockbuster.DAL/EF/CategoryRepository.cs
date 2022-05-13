using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EBlockbuster.DAL.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbContextOptions Dbco;

        public CategoryRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }
        public Response Delete(int categoryId)
        {

            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Categories
                        .Include(c => c.Products)
                        .ThenInclude(c => c.ProductCustomers)
                        .ToList();
                    foreach (var item in db.Categories.Where(c => c.CategoryId == categoryId).ToList())
                    {
                        db.Categories.Remove(item);

                    }
                    db.SaveChanges();
                    Category category = db.Categories.Find(categoryId);
                    db.Categories.Remove(category);

                    response.Success = true;
                    response.Message = $"Deleting Category ID: {categoryId}";

                }
                return response;

            }

            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
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
            try
            {
                Response<Category> response = new Response<Category>();
                using (var db = new AppDbContext(Dbco))
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Category added successfully";
                }
                return response;
            }
            catch (Exception ex)
            {
                Response<Category> response = new Response<Category>();
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public Response Update(Category category)
        {
            try
            {
                Response<Category> response = new Response<Category>();
                using (var db = new AppDbContext(Dbco))
                {
                    db.Categories.Update(category);
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Category updated successfully";
                }
                return response;
            }
            catch (Exception ex)
            {
                Response<Category> response = new Response<Category>();
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
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
