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
        Response<SecurityLevel> Insert(SecurityLevel securityLevel);

        Response Update(SecurityLevel securityLevel);

        Response Delete(int securityLevelId);

        Response<SecurityLevel> Get(int securityLevelId);
    }
}
