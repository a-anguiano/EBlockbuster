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
    public class ProductRepositoryTests
    {
        ProductRepository db;

        Product product = new Product
        {
            ProductId = 10,
            Name = "Howls Moving Castle",
            Photo = "PlaceHolderLinkToPicture",
            Description = "Kid finds a castle that moves"
        };

        [SetUp]
        public void Setup()
        {
            ProductRepository setup = new ProductRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(product.Name, db.Get(10).Data.Name);
            Assert.AreEqual(product.Description, db.Get(10).Data.Description);
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(10, db.GetAll().Data.Count);
        }

        [Test]
        public void TestInsert()
        {
            Product newProduct = new Product
            {
                Name = "New Product",
                Photo = "PlaceHolderLinkToPicture",
                Description = "New Product",
                CategoryId = 1,
                PriceId = 1
            };

            var add = db.Insert(newProduct);
            Assert.IsTrue(add.Success);
            Assert.AreEqual(11, add.Data.ProductId);
            Assert.AreEqual(newProduct.Name, add.Data.Name);
        }

        [Test]
        public void TestUpdate()
        {
            Product newProduct = new Product
            {
                ProductId = 10,
                Name = "Updated Product",
                Photo = "Updated PlaceHolderLinkToPicture",
                Description = "Updated Product",
                CategoryId = 6,
                PriceId = 1
            };

            var update = db.Update(newProduct);
            Assert.IsTrue(update.Success);
            Assert.AreEqual(newProduct.Name, db.Get(10).Data.Name);
            Assert.AreEqual(newProduct.CategoryId, db.Get(10).Data.CategoryId);
        }
        [Test]
        public void TestDelete()
        {
            var delete = db.Delete(10);
            Assert.IsFalse(db.Get(10).Success);
        }
        [Test]
        public void TestGetProductByCustomer()
        {
            var getCustomer = db.GetProductByCustomer(5);
            Assert.IsTrue(getCustomer.Success);

            foreach (var item in getCustomer.Data)
            {
                Assert.AreEqual(6, item.ProductId);
            }
        }
    }
}
