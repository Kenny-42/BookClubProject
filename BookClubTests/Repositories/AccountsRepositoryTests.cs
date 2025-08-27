using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookClub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using BookClub.Data;

namespace BookClub.Repositories.Tests
{
    [TestClass()]
    public class AccountsRepositoryTests
    {
        private AppDbContext _context;
        private AccountsRepository _repo;
        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repo = new AccountsRepository(_context);
        }

        [TestMethod()]
        public void AddTest_WithValidAccount_ShouldReturnTrue()
        {
            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };
            _repo.Add(account);

            var result = _context.accounts.FirstOrDefault(a => a.Username == "johndoe");
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [TestMethod()]
        public void AddTest_WithNullAccount_ShouldThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _repo.Add(null));
        }

        [TestMethod()]
        public void AddTest_WithNonZeroAccountId_ShouldThrowArgumentException()
        {
            var account = new Account()
            {
                Id = 1, // Should not be set for new entities
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };

            Assert.ThrowsException<ArgumentException>(() => _repo.Add(account));
        }

        [TestMethod()]
        public void GetByKeyTest_Id_ShouldReturnCorrectAccount()
        {
            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };
            _repo.Add(account);

            var result = _repo.GetByKey(a => a.Username == account.Username);
            Assert.IsNotNull(result);
            Assert.AreEqual(account.Id, result.Id);
        }

        [TestMethod()]
        public void GetByKeyTest_Username_ShouldReturnCorrectAccount()
        {
            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };
            _repo.Add(account);

            var result = _repo.GetByKey(a => a.Username == account.Username);
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [TestMethod()]
        public void GetAllTest_ShouldReturnAllAccounts()
        {
            var accounts = new List<Account>()
            {
                new Account()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "johndoe",
                    Password = "123456"
                },
                new Account()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Username = "jane",
                    Password = "123456"
                },
                new Account()
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    Username = "alicesmith",
                    Password = "123456"
                }
            };

            _context.accounts.AddRange(accounts);
            _context.SaveChanges();

            var all = _repo.GetAll().ToList();

            Assert.AreEqual(accounts.Count, all.Count);
            
            var expectedUsernames = accounts.Select(a => a.Username).OrderBy(u => u).ToList();
            var actualUsernames = all.Select(a => a.Username).OrderBy(u => u).ToList();

            CollectionAssert.AreEqual(expectedUsernames, actualUsernames);
        }

        [TestMethod()]
        public void UpdateTest_ShouldModifyAccount()
        {
            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };

            _context.accounts.Add(account);
            _context.SaveChanges();

            account.FirstName = "Jane";

            _repo.Update(account);

            var updated = _context.accounts.FirstOrDefault(a => a.Username == account.Username);

            Assert.IsNotNull(updated);
            Assert.AreEqual(account.FirstName, updated.FirstName);
        }

        [TestMethod()]
        public void DeleteTest_ShouldRemoveAccount()
        {
            var account = new Account()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Password = "123456"
            };

            _context.accounts.Add(account);
            _context.SaveChanges();

            _repo.Delete(account.Id);

            var deleted = _context.accounts.FirstOrDefault(a => a.Id == account.Id);
            Assert.IsNull(deleted);
        }
    }
}