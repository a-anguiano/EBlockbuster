using EBlockbuster.Core.Entities;
using EBlockbuster.DAL.EF;
using NUnit.Framework;

namespace EBlockbuster.DAL.Test
{
    public class CustomerRepositoryTest
    {
        CustomerRepository db;
        DBFactory dbf;

        Customer customerRamsey = new Customer
        {
            CustomerId = 5,
            FirstName = "Ramsey",
            LastName = "Rickell",
            Email = "rrickell4@symantec.com",
            Phone = "602-316-5578",
            CreditCardId = 5,
            LoginId = 10
        };

        [SetUp]
        public void Setup()
        {
            CustomerRepository setup = new CustomerRepository(FactoryMode.TEST);
            setup.SetKnownGoodState();
            db = setup;
        }

        [Test]
        public void TestGetAll()
        {
            Assert.AreEqual(10, db.GetAll().Data.Count);
        }

        [Test]
        public void TestGet()
        {
            Assert.IsTrue(db.Get(5).Success);
            Assert.AreEqual("Customer ID: 5", db.Get(5).Message);
            Assert.AreEqual(customerRamsey.FirstName, db.Get(5).Data.FirstName);
            Assert.AreEqual(customerRamsey.LastName, db.Get(5).Data.LastName);
            Assert.AreEqual(customerRamsey.Email, db.Get(5).Data.Email);
            Assert.AreEqual(customerRamsey.Phone, db.Get(5).Data.Phone);
            Assert.AreEqual(customerRamsey.CreditCardId, db.Get(5).Data.CreditCardId);
            Assert.AreEqual(customerRamsey.LoginId, db.Get(5).Data.LoginId);
        }

        [Test]
        public void TestGetbyEmail()
        {
            var result = db.GetCustomerByEmail("fharburtson2@salon.com");
            Assert.AreEqual(result.Data.FirstName, "Francene");
            Assert.AreEqual(result.Data.LastName, "Harburtson");
            Assert.AreEqual(result.Data.Phone, "404-482-8248");
            Assert.AreEqual(result.Data.CustomerId, 3);
        }

        [Test]
        public void TestInsert()
        {
            Customer expected = new Customer
            {
                FirstName = "Annie",
                LastName = "Wilkes",
                Email = "annielovesMisery@gmail.com",
                Phone = "432-314-9895",
                CreditCardId = 7,
                LoginId = 10
            };

            db.Insert(expected);
            expected.CustomerId = 11;

            Assert.AreEqual(expected.ToString(), db.Get(11).Data.ToString());
            Assert.AreEqual(expected.FirstName, db.Get(11).Data.FirstName);
            Assert.AreEqual(expected.LastName, db.Get(11).Data.LastName);
            Assert.AreEqual(expected.Email, db.Get(11).Data.Email);
            Assert.AreEqual(expected.Phone, db.Get(11).Data.Phone);
            Assert.AreEqual(expected.CreditCardId, db.Get(11).Data.CreditCardId);
            Assert.AreEqual(expected.LoginId, db.Get(11).Data.LoginId);
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
            customerRamsey.FirstName = "Barnie";
            customerRamsey.Email = "CleanUpEverybody@msn.com";
            //more changes?

            db.Update(customerRamsey);
            Customer actual = db.Get(5).Data;
            Assert.AreEqual(customerRamsey.FirstName, actual.FirstName);
            Assert.AreEqual(customerRamsey.LastName, actual.LastName);
            Assert.AreEqual(customerRamsey.Email, actual.Email);
            Assert.AreEqual(customerRamsey.Phone, actual.Phone);
            Assert.AreEqual(customerRamsey.CreditCardId, actual.CreditCardId);
            Assert.AreEqual(customerRamsey.LoginId, actual.LoginId);

        }

        [Test]
        public void TestGetProductByCustomer()
        {
            var getProduct = db.GetCustomerByProduct(1);
            Assert.IsTrue(getProduct.Success);

            foreach (var item in getProduct.Data)
            {
                Assert.AreEqual(10, item.CustomerId);
            }
        }

        [Test]
        public void TestGetCustomerByLoginId()
        {
            var result = db.GetCustomerByLoginId(8);
            Assert.AreEqual(result.Data.FirstName, "Francene");
            Assert.AreEqual(result.Data.LastName, "Harburtson");
            Assert.AreEqual(result.Data.Phone, "404-482-8248");
            Assert.AreEqual(result.Data.CustomerId, 3);
        }
        //Create sad tests?
    }
}