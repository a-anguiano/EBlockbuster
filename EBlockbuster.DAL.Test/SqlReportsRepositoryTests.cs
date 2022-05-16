using EBlockbuster.DAL.ADO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.DAL.Test
{
    public class SqlReportsRepositoryTests
    {
        SqlReportsRepository db;

        [SetUp]
        public void Setup()
        {
            ConfigProvider cp = new ConfigProvider();
            db = new SqlReportsRepository(cp.Config);
        }

        [Test]
        public void TestGetTopThreeRentedProducts()
        {
            var result = db.GetTopThreeRentedProducts();
            Assert.AreEqual("Sel8nne", result.Data[0].ProductTitle);
            Assert.AreEqual("Riding the Bullet", result.Data[1].ProductTitle);
            Assert.AreEqual("Deadly Mantis, The", result.Data[2].ProductTitle);
            //could test other columns
            //or count

        }

        //[Test]
        //public void TestGetPensionList() // @agencyId - 10, 7
        //{
        //    var result = db.GetPensionList(10);
        //    Assert.AreEqual("Maxine", result.Data[0].AgencyName);
        //    Assert.AreEqual("Mor Edyth", result.Data[0].NameLastFirst);
        //    Assert.AreEqual(dateOfBirth, result.Data[0].DateOfBirth);
        //    Assert.AreEqual(DeactivationDate, result.Data[0].DeactivationDate);
        //}

        //[Test]
        //public void TestAuditClearance() // sc = 2   // ag id = 7 
        //{
        //    var result = db.AuditClearance(2, 7);
        //    Assert.AreEqual("Gribble Kirby", result.Data[0].NameLastFirst);
        //    Assert.AreEqual(dateOfBirth2, result.Data[0].DateOfBirth);
        //    Assert.AreEqual(ActivationDate, result.Data[0].ActivationDate);
        //    Assert.AreEqual(DeactivationDate2, result.Data[0].DeactivationDate);
        //}
    }
}
