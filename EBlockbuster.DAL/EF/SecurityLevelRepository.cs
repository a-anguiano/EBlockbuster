
using EBlockbuster.Core;
using EBlockbuster.Core.Entities;
using EBlockbuster.Core.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.DAL.EF
{
    public class SecurityLevelRepository : ISecurityLevelRepository
    {
        private DbContextOptions Dbco;

        public SecurityLevelRepository(FactoryMode mode = FactoryMode.TEST)
        {
            Dbco = DBFactory.GetDbContext(mode);
        }
        public Response<SecurityLevel> Get(int securityLevelId)
        {
            Response<SecurityLevel> response = new Response<SecurityLevel>();
            using (var db = new AppDbContext(Dbco))
            {
                var securityLevel = db.SecurityLevel.Find(securityLevelId);
                if (securityLevel != null)
                {
                    response.Data = securityLevel;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Security Level not found";
                }
                return response;
            }
        }

        public Response<List<SecurityLevel>> GetAll()
        {
            Response<List<SecurityLevel>> response = new Response<List<SecurityLevel>>();

            try
            {
                using (var db = new AppDbContext(Dbco))
                {
                    var securityLevels = db.SecurityLevel.ToList();

                    if (securityLevels.Count > 0)
                    {
                        response.Data = securityLevels;
                        response.Success = true;
                        response.Message = "It's a success";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "It failed";

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