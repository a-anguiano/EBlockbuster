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
    public class CreditCardRepository : ICreditCardRepository
    {
        private DbContextOptions Dbco;

        public CreditCardRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }

        public Response Delete(int creditCardId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.CreditCards.Include(c => c.Customers)
                    .ThenInclude(c => c.ProductCustomers).ToList();

                    CreditCard creditCard = db.CreditCards.Find(creditCardId);
                    db.CreditCards.Remove(creditCard);
                    db.SaveChanges();
                    response.Message = $"Deleting Credit Card ID: {creditCardId}";
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

        public Response<CreditCard> Get(int creditCardId)
        {
            Response<CreditCard> response = new Response<CreditCard>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    response.Data = db.CreditCards.Find(creditCardId);
                    if (response.Data == null)
                    {
                        response.Success = false;
                        response.Message = $"Could not find Credit Card ID: {creditCardId}";
                    }
                    else
                    {
                        response.Success = true;
                        response.Message = $"Credit Card ID: {creditCardId}";
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

        public Response<CreditCard> Insert(CreditCard creditCard)
        {
            Response<CreditCard> response = new Response<CreditCard>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.CreditCards.Add(creditCard);
                    try
                    {
                        db.SaveChanges();
                        response.Data = creditCard;
                        response.Success = true;
                        response.Message = $"Inserted Credit Card ID: {creditCard.CreditCardId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not insert Credit Card ID: {creditCard.CreditCardId}";
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

        public Response Update(CreditCard creditCard)
        {
            Response<CreditCard> response = new Response<CreditCard>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.CreditCards.Update(creditCard);
                    try
                    {
                        db.SaveChanges();
                        response.Data = creditCard;
                        response.Success = true;
                        response.Message = $"Updating Credit Card ID: {creditCard.CreditCardId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not update Credit Card";
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
