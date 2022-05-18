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
    public class AdministratorRepositoryTests
    {
        AdministratorRepository db;
        DBFactory dbf;

        Administrator admin3 = new Administrator
        {
            AdminId = 3,
            FirstName = "Austina",
            LastName = "Rogerot",
            LoginId = 3
        };

        [SetUp]
        public void Setup()
        {
            AdministratorRepository setup = new AdministratorRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(5, db.GetAll().Data.Count);
        }

        [Test]
        public void TestGet()
        {
            Assert.IsTrue(db.Get(5).Success);
            Assert.AreEqual("Administrator ID: 3", db.Get(3).Message);
            Assert.AreEqual(admin3.FirstName, db.Get(3).Data.FirstName);
            Assert.AreEqual(admin3.LastName, db.Get(3).Data.LastName);
            Assert.AreEqual(admin3.LoginId, db.Get(3).Data.LoginId);
        }

        [Test]
        public void TestInsert()
        {
            Administrator expected = new Administrator
            {
                FirstName = "Barbara",
                LastName = "Streisand",
                LoginId = 10
            };

            db.Insert(expected);
            expected.AdminId = 6;

            Assert.AreEqual(expected.ToString(), db.Get(6).Data.ToString());
            Assert.AreEqual(expected.FirstName, db.Get(6).Data.FirstName);
            Assert.AreEqual(expected.LastName, db.Get(6).Data.LastName);
            Assert.AreEqual(expected.LoginId, db.Get(6).Data.LoginId);
        }

        [Test]
        public void TestDelete()
        {
            Assert.IsTrue(db.Delete(1).Success);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestUpdate()
        {
            admin3.FirstName = "Baby";
            admin3.LastName = "Sherwood";
            //more changes?

            db.Update(admin3);
            Administrator actual = db.Get(3).Data;
            Assert.AreEqual(admin3.FirstName, actual.FirstName);
            Assert.AreEqual(admin3.LastName, actual.LastName);
            Assert.AreEqual(admin3.LoginId, actual.LoginId);

        }

        [Test]
        public void TestGetAdminByLoginId()
        {
            var result = db.GetAdminByLoginId(3);
            Assert.AreEqual(result.Data.FirstName, "Austina");
            Assert.AreEqual(result.Data.LastName, "Rogerot");
            Assert.AreEqual(result.Data.AdminId, 3);
        }
        //Create sad tests?
    }
}
