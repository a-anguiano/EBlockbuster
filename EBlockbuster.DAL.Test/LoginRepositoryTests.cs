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

        Login login3 = new Login() 
        { Username = "austinarogerot", 
          Password = "VBzr8jIu7u",
          SecurityLevelId = 1 
        };
        
        [SetUp]
        public void Setup()
        {
            LoginRepository setup = new LoginRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.IsTrue(db.Get(3).Success);
            //Assert.AreEqual("Login ID: 3", db.Get(3).Message);
            Assert.AreEqual(login3.Username, db.Get(3).Data.Username);
            Assert.AreEqual(login3.Password, db.Get(3).Data.Password);
            Assert.AreEqual(login3.SecurityLevelId, db.Get(3).Data.SecurityLevelId);
        }

        [Test]
        public void TestInsert()
        {
            Login expected = new Login
            {
                Username = "abc123",
                Password = "passyWordy",
                SecurityLevelId = 2
            };

            db.Insert(expected);
            expected.LoginId = 16;

            Assert.AreEqual(expected.ToString(), db.Get(16).Data.ToString());
            Assert.AreEqual(expected.Username, db.Get(16).Data.Username);
            Assert.AreEqual(expected.Password, db.Get(16).Data.Password);
            Assert.AreEqual(expected.SecurityLevelId, db.Get(16).Data.SecurityLevelId);
        }


    }
}
