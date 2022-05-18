using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface IAdministratorRepository
    {
        Response<Administrator> Insert(Administrator administrator);

        Response Update(Administrator administrator);

        Response Delete(int adminId);

        Response<Administrator> Get(int adminId);

        Response<List<Administrator>> GetAll();
        Response<Administrator> GetAdminByLoginId(int loginId);
    }
}
