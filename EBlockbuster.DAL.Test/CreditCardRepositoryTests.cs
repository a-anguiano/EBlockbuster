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
    public class CreditCardRepositoryTests
    {
        CreditCardRepository db;
        DBFactory dbf;

        CreditCard cc3 = new CreditCard
        {
            CreditCardId = 3,
            Number = "5108756093665799",
            ExpDate = DateTime.Parse("9/1/2024"),
            SVC = "288",
            BillingAddress = "287 Meadow Valley Park",
            City = "Atlanta",
            State = "GA",
            Zipcode = 31196
        };

        [SetUp]
        public void Setup()
        {
            CreditCardRepository setup = new CreditCardRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGet()
        {
            Assert.IsTrue(db.Get(3).Success);
            Assert.AreEqual("Credit Card ID: 3", db.Get(3).Message);
            Assert.AreEqual(cc3.Number, db.Get(3).Data.Number);
            //Assert.AreEqual(cc3.ExpDate, db.Get(3).Data.ExpDate);
            Assert.AreEqual(cc3.SVC, db.Get(3).Data.SVC);
            Assert.AreEqual(cc3.BillingAddress, db.Get(3).Data.BillingAddress);
            Assert.AreEqual(cc3.City, db.Get(3).Data.City);
            Assert.AreEqual(cc3.State, db.Get(3).Data.State);
            Assert.AreEqual(cc3.Zipcode, db.Get(3).Data.Zipcode);
        }

        [Test]
        public void TestInsert()
        {
            CreditCard expected = new CreditCard
            {
                Number = "3141592654311111",
                ExpDate = DateTime.Parse("8/1/2024"),
                SVC = "234",
                BillingAddress = "123 Death Valley Park",
                City = "Atlanta",
                State = "GA",
                Zipcode = 31196
            };

            db.Insert(expected);
            expected.CreditCardId = 11;

            Assert.AreEqual(expected.ToString(), db.Get(11).Data.ToString());
            Assert.AreEqual(expected.Number, db.Get(11).Data.Number);
            Assert.AreEqual(expected.ExpDate, db.Get(11).Data.ExpDate);
            Assert.AreEqual(expected.SVC, db.Get(11).Data.SVC);
            Assert.AreEqual(expected.BillingAddress, db.Get(11).Data.BillingAddress);
            Assert.AreEqual(expected.City, db.Get(11).Data.City);
            Assert.AreEqual(expected.State, db.Get(11).Data.State);
            Assert.AreEqual(expected.Zipcode, db.Get(11).Data.Zipcode);
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
            cc3.City = "Dallas";
            cc3.State = "TX";
            //more changes?

            db.Update(cc3);
            CreditCard actual = db.Get(3).Data;
            Assert.AreEqual(cc3.Number, actual.Number);
            Assert.AreEqual(cc3.ExpDate, actual.ExpDate);
            Assert.AreEqual(cc3.SVC, actual.SVC);
            Assert.AreEqual(cc3.City, actual.City);
            Assert.AreEqual(cc3.State, actual.State);
            Assert.AreEqual(cc3.Zipcode, actual.Zipcode);
        }

        //Create sad tests?
    }
}
