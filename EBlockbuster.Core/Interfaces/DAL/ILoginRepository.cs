using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface ILoginRepository
    {
        Response<Login> Insert(Login login);

        Response Update(Login login);

        Response Delete(int loginId);

        Response<Login> Get(int loginId);
    }
}

