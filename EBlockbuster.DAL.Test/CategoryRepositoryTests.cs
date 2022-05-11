using EBlockbuster.Core.Entities;
using EBlockbuster.DAL.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EBlockbuster.DAL.Test
{
    public class CategoryRepositoryTests
    {
        CategoryRepository db;
        DBFactory dbf;

        Category categoryThriller = new Category
        {
            CategoryId = 8,
            Name = "Thriller",
        };

        [SetUp]
        public void Setup()
        {
           CategoryRepository setup = new CategoryRepository(FactoryMode.TEST);
           setup.SetKnownGoodState();
           db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.AreEqual(categoryThriller.ToString(), db.Get(8).Data.ToString());
            Assert.AreEqual(categoryThriller.Name, db.Get(8).Data.Name);
            //could do on each property
        }

        [Test]
        public void TestInsert()
        {
            Category expected = new Category
            {
                //CategoryId = 11,
                Name = "Sports"
            };

            db.Insert(expected);
            expected.CategoryId = 11;

            Assert.AreEqual(expected.ToString(), db.Get(11).Data.ToString());
            Assert.AreEqual(expected.Name, db.Get(11).Data.Name);
        }

        [Test]
        public void TestDelete()
        {
            bool actual = db.Delete(1).Success;
            Assert.IsTrue(actual);
            Assert.Null(db.Get(1).Data);
        }

        [Test]
        public void TestUpdate()
        {
            categoryThriller.Name = "Spooky";

            db.Update(categoryThriller);
            Category actual = db.Get(8).Data;
            Assert.AreEqual(categoryThriller.Name, actual.Name);
        }
    }
}
