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
        private Account _testAccount;
        private List<Account> _testAccounts;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repo = new AccountsRepository(_context);

            _testAccounts = new List<Account>()
            {
                new Account()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@mail.com",
                    Username = "johndoe",
                    Password = "123456"
                },
                new Account()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "janedoe@mail.com",
                    Username = "jane",
                    Password = "123456"
                },
                new Account()
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alicesmith@mail.com",
                    Username = "alicesmith",
                    Password = "123456"
                }
            };

            _testAccount = _testAccounts.First();
        }

        [TestMethod()]
        public void AddTest_WithValidAccount_ShouldReturnTrue()
        {
            // Arrange
            var account = _testAccount;

            // Act
            _repo.Add(account);

            // Assert
            var result = _context.accounts.FirstOrDefault(a => a.Username == "johndoe");

            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [TestMethod()]
        public void AddTest_WithNullAccount_ShouldThrowArgumentNullException()
        {
            // Act & Assert
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
                Email = "johndoe@mail.com",
                Username = "johndoe",
                Password = "123456"
            };

            Assert.ThrowsException<ArgumentException>(() => _repo.Add(account));
        }

        [TestMethod()]
        public void GetByKeyTest_Id_ShouldReturnCorrectAccount()
        {
            // Arrange
            var account = _testAccount;
            _repo.Add(account);

            // Act
            var result = _repo.GetByKey(a => a.Username == account.Username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(account.Id, result.Id);
        }

        [TestMethod()]
        public void GetByKeyTest_Username_ShouldReturnCorrectAccount()
        {
            // Arrange
            var account = _testAccount;
            _repo.Add(account);

            // Act
            var result = _repo.GetByKey(a => a.Username == account.Username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("John", result.FirstName);
        }

        [TestMethod()]
        public void GetAllTest_ShouldReturnAllAccounts()
        {
            // Arrange
            var accounts = _testAccounts;

            _context.accounts.AddRange(accounts);
            _context.SaveChanges();

            // Act
            var all = _repo.GetAll().ToList();

            var expectedUsernames = accounts.Select(a => a.Username).OrderBy(u => u).ToList();
            var actualUsernames = all.Select(a => a.Username).OrderBy(u => u).ToList();
            
            // Assert
            Assert.AreEqual(accounts.Count, all.Count);

            CollectionAssert.AreEqual(expectedUsernames, actualUsernames);
        }

        [TestMethod()]
        public void UpdateTest_ShouldModifyAccount()
        {
            // Arrange
            var account = _testAccount;

            _context.accounts.Add(account);
            _context.SaveChanges();

            // Act
            //account.FirstName = "Jane";
            AccountUpdateDTO dto = new AccountUpdateDTO
            {
                FirstName = "Jane"
            };

            _repo.Update(account.Id, dto);

            var updated = _context.accounts.FirstOrDefault(a => a.Username == account.Username);

            // Assert
            Assert.IsNotNull(updated);
            Assert.AreEqual(account.FirstName, updated.FirstName);
        }

        [TestMethod()]
        public void DeleteTest_ShouldReturnTrue()
        {
            // Arrange
            var account = _testAccount;

            _context.accounts.Add(account);
            _context.SaveChanges();

            // Act
            var deleted = _repo.Delete(account.Id);

            // Assert
            Assert.IsTrue(deleted);
        }
    }
}