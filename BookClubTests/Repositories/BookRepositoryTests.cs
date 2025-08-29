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
        private Book _testBook;
        private List<Book> _testBooks;

        [TestInitialize]
        public void BookRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repo = new BookRepository(_context);

            _testBooks = new List<Book>()
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

            _testBook = _testBooks.First();
        }

        [TestMethod()]
        public void AddTest_ShouldReturnTrue()
        {
            // Arrange
            Book book = _testBook;

            // Act
            var result = _repo.Add(book);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetByKeyTest_Title_ShouldReturnBook()
        {
            // Arrange
            Book book = _testBook;

            _context.Books.Add(book);
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
            var books = _testBooks;

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
            var book = _testBook;

            _context.Books.Add(book);

            // Act
            var updateDto = new BookUpdateDTO()
            {
                Title = "Updated Title",    
            };

            _repo.Update(book.Id, updateDto);

            var updatedBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);

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
            var book = _testBook;

            _context.Books.Add(book);
            _context.SaveChanges();

            // Act
            var result = _repo.Delete(book.Id);

            // Assert
            Assert.IsTrue(result);
        }
    }
}