using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class UserContextUnitTest
    {
        private IzpitDBContext dbContext;
        private UserContext userContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new userContext(builder.Options);
            userContext = new userContext(dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int genresBefore = userContext.ReadAll().Count();

            userContext.Create(new User("Ivan", "Ivanov", 18, "ivanivanov", "12345678", null, null));

            int genresAfter = userContext.ReadAll().Count();

            Assert.IsTrue(genresBefore != genresAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            userContext.Create(new User("Ivan", "Ivanov", 18, "ivanivanov", "12345678", null, null));

            User genre = userContext.Read(3);

            Assert.That(genre != null, "There is no record with id 3!");
        }

        [Test]
        public void TestUpdateGenre()
        {
            userContext.Create(new User("Ivan", "Ivanov", 18, "ivanivanov", "12345678", null, null));

            User user = userContext.Read(1);

            user.firstName = "Petur";

            userContext.Update(user);

            User user1 = userContext.Read(1);

            Assert.IsTrue(user1.firstName == "Ivan", "User Update() does not change name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            userContext.Create(new User("Delete", "Delete", 18, "delete", "delete", null, null));

            int genresBeforeDeletion = userContext.ReadAll().Count();

            userContext.Delete(1);

            int genresAfterDeletion = userContext.ReadAll().Count();

            Assert.AreNotEqual(genresBeforeDeletion, genresAfterDeletion);
        }
    }
}
