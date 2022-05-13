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
    public class ProductCustomerRepositoryTests
    {
        ProductCustomerRepository db;

        ProductCustomer productCustomer = new ProductCustomer
        {
            ProductId = 1,
            CustomerId = 10
        };

        [SetUp]
        public void Setup()
        {
            ProductCustomerRepository setup = new ProductCustomerRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }
        [Test]
        public void TestGetByCustomer()
        {
            var getbyCustomerId = db.GetByCustomerId(10);
            Assert.IsTrue(getbyCustomerId.Success);

            foreach (var item in getbyCustomerId.Data)
            {
                Assert.AreEqual(item.ProductId, 1);
            }
        }
        [Test]
        public void TestGetByProduct()
        {
            var getbyProductId = db.GetByProductId(1);
            Assert.IsTrue(getbyProductId.Success);

            foreach (var item in getbyProductId.Data)
            {
                Assert.AreEqual(item.CustomerId, 10);
            }
        }
        [Test]
        public void TestInsert()
        {
            ProductCustomer productCustomer = new ProductCustomer
            {
                ProductId = 7,
                CustomerId = 1
            };

            var add = db.Insert(productCustomer);
            Assert.IsTrue(add.Success);
            Assert.AreEqual(add.Data.ProductId, 7);
            Assert.AreEqual(add.Data.CustomerId, 1);
        }
        [Test]
        public void TestUpdate()
        {
            ProductCustomer productCustomer = new ProductCustomer
            {
                ProductId = 1,
                CustomerId = 5
            };
            var update = db.Update(productCustomer);
            Assert.IsTrue(update.Success);
        }

        [Test]
        public void TestDeleteByCustomer()
        {
            var delete = db.DeleteByCustomer(1);
            Assert.IsFalse(db.GetByCustomerId(1).Success);
            Assert.IsFalse(db.GetByProductId(10).Success);
        }
    }
}
