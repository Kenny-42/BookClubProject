using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Repositories.Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {
        private AppDbContext _context;
        private BookRepository _repo;

        [TestInitialize]
        public void BookRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repo = new BookRepository(_context);
        }

        [TestMethod()]
        public void AddTest_ShouldReturnTrue()
        {
            // Arrange
            Book book = new Book()
            {
                Title = "New Book",
                Author = "Author X",
                Description = "This is a new book.",
                ISBN = "987-6543210987"
            };

            // Act
            var result = _repo.Add(book);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetByKeyTest_Title_ShouldReturnBook()
        {
            // Arrange
            Book book = new Book()
            {
                Title = "Original Title",
                Author = "Author A",
                Description = "A fascinating fiction book.",
                ISBN = "123-4567890123"
            };

            _context.books.Add(book);
            _context.SaveChanges();

            // Act
            var retrievedBook = _repo.GetByKey(b => b.Title == book.Title);

            // Assert
            Assert.IsNotNull(retrievedBook);
            Assert.AreEqual(book.Title, retrievedBook.Title);
        }

        [TestMethod()]
        public void GetByKeyTest_NonExistentTitle_ShouldReturnNull()
        {
            // Act
            var retrievedBook = _repo.GetByKey(b => b.Title == "NonExistentTitle");

            // Assert
            Assert.IsNull(retrievedBook);
        }

        [TestMethod()]
        public void GetAllTest_ShouldReturnAll()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Book One",
                    Author = "Author A",
                    Description = "First book description.",
                    ISBN = "111-1111111111"
                },
                new Book()
                {
                    Title = "Book Two",
                    Author = "Author B",
                    Description = "Second book description.",
                    ISBN = "222-2222222222"
                },
                new Book()
                {
                    Title = "Book Three",
                    Author = "Author C",
                    Description = "Third book description.",
                    ISBN = "333-3333333333"
                }
            };

            // Act
            var list = _repo.GetAll();

            // Assert
            Assert.IsNotNull(list);
            CollectionAssert.AllItemsAreNotNull(list.ToList());
        }

        [TestMethod()]
        public void UpdateTest_ShouldChangeTitle()
        {
            // Arrange
            var book = new Book()
            {
                Title = "Original Title",
                Author = "Author A",
                Description = "A fascinating fiction book.",
                ISBN = "123-4567890123"
            };

            _context.books.Add(book);

            // Act
            var updateDto = new BookUpdateDTO()
            {
                Title = "Updated Title",    
            };

            _repo.Update(book.Id, updateDto);

            var updatedBook = _context.books.FirstOrDefault(b => b.Id == book.Id);

            // Assert
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(updateDto.Title, updatedBook.Title);
            Assert.AreEqual(book.Author, updatedBook.Author); // Unchanged
            Assert.AreEqual(book.Description, updatedBook.Description); // Unchanged
            Assert.AreEqual(book.ISBN, updatedBook.ISBN); // Unchanged
        }

        [TestMethod()]
        public void DeleteTest_ShouldReturnTrue()
        {
            // Arrange
            var book = new Book()
            {
                Title = "To Be Deleted",
                Author = "Author X",
                Description = "This book will be deleted.",
                ISBN = "999-9999999999"
            };

            _context.books.Add(book);
            _context.SaveChanges();

            // Act
            var result = _repo.Delete(book.Id);

            // Assert
            Assert.IsTrue(result);
        }
    }
}