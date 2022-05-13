
using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces.DAL
{
    public interface ISecurityLevelRepository
    {
        Response<SecurityLevel> Get(int securityLevelId);
        Response<List<SecurityLevel>> GetAll();


    }
}
