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
    
    public class LoginRepository : ILoginRepository
    {
        private DbContextOptions Dbco;

        public LoginRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }
        public Response Delete(int loginId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Logins
                        .Include(l => l.SecurityLevelId).ToList();

                    db.Logins.Remove(db.Logins.Find(loginId));
                    db.SaveChanges();
                    response.Success = true;
                    response.Message = "LoginId Deleted";
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

        public Response<Login> Get(int loginId)
        {
            Response<Login> response = new Response<Login>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var login = db.Logins.Find(loginId);
                    if (login != null)
                    {
                        response.Data = login;
                        response.Success = true;
                        response.Message = "Login found";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Login not found";
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

        public Response<Login> Insert(Login login)
        {
            Response<Login> response = new Response<Login>();            
            try
            {
                
                using (var db = new AppDbContext(Dbco))
                {
                    db.Logins.Add(login);
                    try
                    {
                        db.SaveChanges();
                        response.Data = login;
                        response.Success = true;
                        response.Message = "Login added successfully";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = "Login not added, Login already exsits.";
                    }
                    
                }
                return response;
            }
            catch (Exception ex)
            {
               
                response.Success = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public Response Update(Login login)
        {
            Response<Login> response = new Response<Login>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Logins.Update(login);
                    try
                    {
                        db.SaveChanges();
                        response.Data = login;
                        response.Success = true;
                        response.Message = "Login updated successfully";
                    }
                    catch 
                    {
                        response.Success = false;
                        response.Message = "Login update failed";
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
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
