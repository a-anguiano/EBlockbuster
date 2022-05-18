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
    public class AdministratorRepository : IAdministratorRepository
    {
        private DbContextOptions Dbco;

        public AdministratorRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }

        public Response Delete(int adminId)
        {
            Response response = new Response();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Administrators.ToList();

                    Administrator administrator = db.Administrators.Find(adminId);
                    db.Administrators.Remove(administrator);
                    db.SaveChanges();
                    response.Message = $"Deleting Administrator ID: {adminId}";
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

        public Response<Administrator> Get(int adminId)
        {
            Response<Administrator> response = new Response<Administrator>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    response.Data = db.Administrators.Find(adminId);
                    if (response.Data == null)
                    {
                        response.Success = false;
                        response.Message = $"Could not find Administrator ID: {adminId}";
                    }
                    else
                    {
                        response.Success = true;
                        response.Message = $"Administrator ID: {adminId}";
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

        public Response<List<Administrator>> GetAll()
        {
            Response<List<Administrator>> response = new Response<List<Administrator>>();
            List<Administrator> listAdministrators = new List<Administrator>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    listAdministrators = db.Administrators.ToList();
                }
                response.Data = listAdministrators;

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

        public Response<Administrator> GetAdminByLoginId(int loginId)
        {
            Response<Administrator> response = new Response<Administrator>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var admin = response.Data = db.Administrators.FirstOrDefault(c => c.LoginId == loginId);
                    if (admin == null)
                    {
                        response.Success = false;
                        response.Message = $"Could not find Administrator Login ID: {loginId}";
                    }
                    else
                    {
                        response.Data = admin;
                        response.Success = true;
                        response.Message = $"Administrator Login ID: {loginId}";
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

        public Response<Administrator> Insert(Administrator administrator)
        {
            Response<Administrator> response = new Response<Administrator>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Administrators.Add(administrator);
                    try
                    {
                        db.SaveChanges();
                        response.Data = administrator;
                        response.Success = true;
                        response.Message = $"Inserted Administrator ID: {administrator.AdminId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not insert Administrator ID: {administrator.AdminId}";
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

        public Response Update(Administrator administrator)
        {
            Response<Administrator> response = new Response<Administrator>();
            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    db.Administrators.Update(administrator);
                    try
                    {
                        db.SaveChanges();
                        response.Data = administrator;
                        response.Success = true;
                        response.Message = $"Updating Administrator ID: {administrator.AdminId}";
                    }
                    catch
                    {
                        response.Success = false;
                        response.Message = $"Could not update Administrator";
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
