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
    public class ProductCustomerRepository : IProductCustomerRepository
    {
        private DbContextOptions Dbco;

        public ProductCustomerRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }
        public Response DeleteByProduct(int productId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var product = db.ProductCustomers.Find(productId);
                    if (product != null)
                    {
                        db.ProductCustomers.Remove(product);
                        db.SaveChanges();

                        response.Success = true;
                        response.Message = "Purchase Deleted by product";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Purchase not found by product";
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

        public Response DeleteByCustomer(int customerId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var customer = db.ProductCustomers.Where(c => c.CustomerId == customerId).ToList();
                    if (customer != null)
                    {
                        foreach (var item in customer)
                        {
                            db.ProductCustomers.Remove(item);
                        }
                        db.SaveChanges();

                        response.Success = true;
                        response.Message = "Purchase Deleted by customer";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Purchase not found by customer";
                    }
                    return response;
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
        
        public Response DeleteByProductCustomer(int productId, int customerId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var product = GetByProductCustomer(productId, customerId);
                    if (product.Data.Count > 0)
                    {
                        foreach (var item in product.Data)
                        {
                            db.ProductCustomers.Remove(item);
                        }
                        db.SaveChanges();

                        response.Success = true;
                        response.Message = "Purchase Deleted by product and customer";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Purchase not found by product and customer";
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

        public Response<List<ProductCustomer>> GetByProductCustomer (int productId, int customerId)
        {
            Response<List<ProductCustomer>> response = new Response<List<ProductCustomer>>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var product = db.ProductCustomers
                        .Where(p => p.ProductId == productId && p.CustomerId == customerId)
                        .ToList();
                    
                    if (product != null)
                    {
                        response.Success = true;
                        response.Message = "Purchase found by product and customer";
                        response.Data = product;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Purchase not found by product and customer";
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
        public Response<List<ProductCustomer>> GetByCustomerId(int customerId)
        {
            Response<List<ProductCustomer>> response = new Response<List<ProductCustomer>>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var productCustomers = db.ProductCustomers
                        .Include(c => c.Customer)
                        .Where(c => c.CustomerId == customerId)
                        .ToList();

                    if (productCustomers.Count > 0)
                    {
                        response.Data = productCustomers;
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "No product found from this customer";
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

        public Response<List<ProductCustomer>> GetByProductId(int productId)
        {
            Response<List<ProductCustomer>> response = new Response<List<ProductCustomer>>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var productCustomers = db.ProductCustomers
                        .Include(c => c.Product)
                        .Where(c => c.ProductId == productId)
                        .ToList();

                    if (productCustomers.Count > 0)
                    {
                        response.Data = productCustomers;
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "No product found";
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

        public Response<ProductCustomer> Insert(ProductCustomer productCustomer)
        {
            Response<ProductCustomer> response = new Response<ProductCustomer>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.ProductCustomers.Add(productCustomer);
                    db.SaveChanges();

                    response.Data = productCustomer;
                    response.Success = true;
                    response.Message = "Product and Customer Added";
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

        public Response Update(ProductCustomer productCustomer)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.ProductCustomers.Update(productCustomer);
                    db.SaveChanges();

                    response.Success = true;
                    response.Message = "Product and Customer Updated";
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
