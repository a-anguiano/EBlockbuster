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
    public class CustomerRepository : ICustomerRepository
    {
        private DbContextOptions Dbco;

        public CustomerRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }

        public Response Delete(int customerId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Customers.Include(c => c.ProductCustomers).ToList();

                    Customer customer = db.Customers.Find(customerId);
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    response.Message = $"Deleting Customer ID: {customerId}";
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> Get(int customerId)
        {
            Response<Customer> response = new Response<Customer>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    response.Data = db.Customers.Find(customerId);
                    if (response.Data == null)
                    {
                        response.Success = false;
                        response.Message = $"Could not find Customer ID: {customerId}";
                    }
                    else
                    {
                        response.Success = true;
                        response.Message = $"Customer ID: {customerId}";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> GetCustomerByEmail(string email)
        {
            Response<Customer> response = new Response<Customer>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var customer = response.Data = db.Customers.FirstOrDefault(c => c.Email == email);
                    if (customer == null)
                    {
                        response.Success = false;
                        response.Message = $"Could not find Customer Email: {email}";
                    }
                    else
                    {
                        response.Data = customer;
                        response.Success = true;
                        response.Message = $"Customer Email: {email}";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Customer> Insert(Customer customer)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Customers.Add(customer);
                    try
                    {
                        db.SaveChanges();
                        response.Data = customer;
                        response.Success = true;
                        response.Message = $"Inserted Customer ID: {customer.CustomerId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not insert Customer ID: {customer.CustomerId}";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response Update(Customer customer)
        {
            Response<Customer> response = new Response<Customer>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Customers.Update(customer);
                    try
                    {
                        db.SaveChanges();
                        response.Data = customer;
                        response.Success = true;
                        response.Message = $"Updating Customer ID: {customer.CustomerId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not update Customer";
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
        public Response<List<Customer>> GetAll()
        {
            Response<List<Customer>> response = new Response<List<Customer>>();
            List<Customer> listCustomers = new List<Customer>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    listCustomers = db.Customers.ToList();
                }
                response.Data = listCustomers;

                if (response.Data == null)
                {
                    response.Success = false;
                    response.Message = "It failed";
                }
                else
                {
                    response.Success = true;
                    response.Message = "It's a success";
                }
            }
            catch (Exception ex)    
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<List<Customer>> GetCustomerByProduct(int productId)
        {
            Response<List<Customer>> response = new Response<List<Customer>>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var customer = db.Customers
                        .Include(c => c.ProductCustomers)
                        .ToList();

                    if (customer != null)
                    {
                        response.Data = customer
                            .Where(pc => pc.ProductCustomers
                            .Any(c => c.ProductId == productId))
                            .ToList();
                        response.Success = true;
                        response.Message = "Customer found";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Customer not found";
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


        public void SetKnownGoodState()
        {
            using (var db = new AppDbContext(Dbco))
            {
                db.Database.ExecuteSqlRaw("SetKnownGoodState");
            }
        }
    }
}
