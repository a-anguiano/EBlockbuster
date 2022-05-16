using EBlockbuster.Core.Entities;
using EBlockbuster.DAL.EF;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.DAL.Test
{
    public class LoginRepositoryTests
    {
        LoginRepository db;
        DBFactory dbf;

        Login userName = new Login() 
        { Username = "test", 
          Password = "test" 
        };
        
        [SetUp]
        public void TestGet()
        {
            Assert.AreEqual(userName.Username, "test");
        }


    }
}
