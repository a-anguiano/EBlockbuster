using EBlockbuster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Interfaces
{
    public interface ICreditCardRepository
    {
        Response<CreditCard> Insert(CreditCard creditCard);

        Response Update(CreditCard creditCard);

        Response Delete(int creditCardId);

        Response<CreditCard> Get(int creditCardId);
    }
}
