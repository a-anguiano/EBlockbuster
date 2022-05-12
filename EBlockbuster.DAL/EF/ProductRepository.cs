using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBlockbuster.Core.Interfaces;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core;
using Microsoft.EntityFrameworkCore;

namespace EBlockbuster.DAL.EF
{
    public class ProductRepository : IProductRepository
    {
        private DbContextOptions Dbco;

        public ProductRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }
        public Response Delete(int productId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Products
                        .Include(c => c.ProductCustomers).ToList();
                                        
                    db.Products.Remove(db.Products.Find(productId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "Product Deleted";
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

        public Response<Product> Get(int productId)
        {
            Response<Product> response = new Response<Product>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var product = db.Products.Find(productId);
                    if (product != null)
                    {
                        response.Data = product;
                        response.Success = true;
                        response.Message = "Product found";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Product not found";
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Product>> GetAll()
        {
            Response<List<Product>> response = new Response<List<Product>>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var products = db.Products.ToList();
                    if (products.Count > 0)
                    {
                        response.Data = products;
                        response.Success = true;
                        response.Message = "Products found";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Products not found";
                    }
                    return response;
                }
            }                
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Product> Insert(Product product)
        {
            Response<Product> response = new Response<Product>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    response.Data = product;
                    response.Success = true;
                    response.Message = "Product Added";
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

        public Response Update(Product product)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Products.Update(product);
                    db.SaveChanges();

                    response.Success = true;
                    response.Message = "Product Updated";
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

        public void SetKnownGoodState()
        {
            using (var db = new AppDbContext(Dbco))
            {
                db.Database.ExecuteSqlRaw("SetKnownGoodState");
            }
        }
    }
}
