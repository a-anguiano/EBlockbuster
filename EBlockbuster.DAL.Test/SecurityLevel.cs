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
    public class SecurityLevelTests
    {
        SecurityLevelRepository db;
        DBFactory dbf;
        SecurityLevel securityLevel = new SecurityLevel
        {
            SecurityLevelId = 1,
            Level = "Administrator"
        };

        [SetUp]
        public void Setup()
        {
            SecurityLevelRepository setup = new SecurityLevelRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;

        }

        [Test]
        public void TestGetAll()
        {

            Assert.AreEqual(2, db.GetAll().Data.Count);
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(db.Get(1).Data.Level, securityLevel.Level);
        }
    }
}
