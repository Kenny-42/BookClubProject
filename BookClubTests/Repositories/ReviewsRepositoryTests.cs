using BookClub.Data;
using BookClub.Models;
using BookClub.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Repositories.Tests
{
    [TestClass()]
    public class ReviewsRepositoryTests
    {
        private AppDbContext _context;
        private ReviewsRepository _repo;
        private Review _testReview;
        private List<Review> _testReviews;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);
            _repo = new ReviewsRepository(_context);

            _testReviews = new List<Review>()
            {
                new Review()
                {
                    BookId = 1,
                    AccountId = 1,
                    Rating = 5,
                    Comment = "Great book!"
                },
                new Review()
                {
                    BookId = 1,
                    AccountId = 2,
                    Rating = 4,
                    Comment = "Good read."
                },
                new Review()
                {
                    BookId = 2,
                    AccountId = 1,
                    Rating = 3,
                    Comment = "It was okay."
                }
            };

            _testReview = _testReviews.First();
        }

        [TestMethod()]
        public void AddTest_ShouldReturnTrue()
        {
            // Arrange
            var review = _testReview;

            // Act
            _repo.Add(review);

            // Assert
            var result = _context.Reviews.FirstOrDefault(r => r.BookId == review.BookId);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, review.Id);
        }

        [TestMethod()]
        public void GetByKeyTest_AccountId_ShouldReturnReview()
        {
            // Arrange
            var review = _testReview;

            // Act
            _repo.Add(review);

            // Assert
            var result = _context.Reviews.FirstOrDefault(r => r.AccountId == review.AccountId);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, review.Id);
        }

        [TestMethod()]
        public void GetAllTest_ShouldReturnAllReviews()
        {
            // Arrange
            var reviews = _testReviews;

            _context.Reviews.AddRange(reviews);
            _context.SaveChanges();

            // Act
            var all = _repo.GetAll().ToList();

            var expectedIds = reviews.Select(r => r.Id).OrderBy(u => u).ToList();
            var actualIds = all.Select(r => r.Id).OrderBy(u => u).ToList();

            // Assert
            Assert.AreEqual(reviews.Count, all.Count);
            CollectionAssert.AreEqual(expectedIds, actualIds);
        }

        [TestMethod()]
        public void UpdateTest_ShouldModifyReview()
        {
            // Arrange
            var review = _testReview;

            _context.Reviews.Add(review);
            _context.SaveChanges();

            // Act

            ReviewUpdateDTO dto = new ReviewUpdateDTO
            {
                Rating = review.Rating,
                Comment = review.Comment
            };

            _repo.Update(review.Id, dto);

            var updated = _context.Reviews.FirstOrDefault(r => r.Id == review.Id);

            // Assert
            Assert.IsNotNull(updated);
            Assert.AreEqual(review.Rating, updated.Rating);
            Assert.AreEqual(review.Comment, updated.Comment);
        }

        [TestMethod()]
        public void DeleteTest_ShouldReturnTrue()
        {
            // Arrange
            _repo.Add(_testReview);

            // Act
            var success = _repo.Delete(_testReview.Id);

            // Assert
            Assert.IsTrue(success);
            var deleted = _context.Reviews.Find(_testReview.Id);
            Assert.IsNull(deleted);
        }
    }
}