using DeltasBookStoreAppWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DeltasBookStoreAppWebAPI.Interface;
using DeltasBookStoreAppWebAPI.Controllers;
using DeltasBookStoreAppWebAPITest.MockData;
using Xunit;

namespace DeltasBookStoreAppWebAPITest.Controllers
{
    public class BookDetailsControllerTest
    {
        [Fact]
        public async Task GetAllBooks_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails()).ReturnsAsync(BookDetailsMock.GetBooks());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.GetBookDetails();

            ///Assert
            result.Result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetBooks_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<int>())).ReturnsAsync(BookDetailsMock.GetBooks().FirstOrDefault());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.GetBookDetails(1);

            ///Assert
            result.Result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public async Task GetBooks_ReturnNotFoundStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<int>())).ReturnsAsync(BookDetailsMock.GetBooks().Where(x => x.Id == 0).FirstOrDefault());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.GetBookDetails(0);

            ///Assert0
            result.Result.GetType().Should().Be(typeof(NotFoundResult));
        }

        [Fact]
        public async Task GetDeletedBookDetails_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetDeletedBookDetails()).ReturnsAsync(BookDetailsMock.GetDeletedBooks());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.GetDeletedBookDetails();

            ///Assert
            result.Result.GetType().Should().Be(typeof(OkObjectResult));
        }

        [Fact]
        public async Task PostBookDetails_ReturnActionResult()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PostBookDetails(It.IsAny<BookDetails>())).ReturnsAsync(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.PostBookDetails(bookDetails);

            ///Assert
            result.Result.GetType().Should().Be(typeof(CreatedAtActionResult));
        }

        [Fact]
        public async Task PostBookDetails_ReturnProblem()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PostBookDetails(It.IsAny<BookDetails>())).ReturnsAsync(99);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.PostBookDetails(bookDetails);

            ///Assert
            result.Result.GetType().Should().Be(typeof(ObjectResult));
        }

        [Fact]
        public async Task PutBookDetails_ReturnOk()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).ReturnsAsync(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.PutBookDetails(4, bookDetails);

            ///Assert
            result.GetType().Should().Be(typeof(OkResult));
        }

        [Fact]
        public async Task PutBookDetails_ReturnBadRequest()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).ReturnsAsync(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.PutBookDetails(1, bookDetails);

            ///Assert
            result.GetType().Should().Be(typeof(BadRequestResult));
        }

        [Fact]
        public async Task PutBookDetails_ReturnNotFound()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).ReturnsAsync(99);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.PutBookDetails(4, bookDetails);

            ///Assert
            result.GetType().Should().Be(typeof(ObjectResult));
        }

        [Fact]
        public async Task DeleteBookDetails_ReturnOk()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).ReturnsAsync(1);
            mockRepository.Setup(x => x.BookDetailsExists(It.IsAny<int>())).ReturnsAsync(true);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.DeleteBookDetails(4);

            ///Assert
            result.GetType().Should().Be(typeof(OkResult));
        }


        [Fact]
        public async Task DeleteBookDetails_ReturnProblem()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).ReturnsAsync(99);
            mockRepository.Setup(x => x.BookDetailsExists(It.IsAny<int>())).ReturnsAsync(true);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.DeleteBookDetails(4);

            ///Assert
            result.GetType().Should().Be(typeof(ObjectResult));
        }

        [Fact]
        public async Task DeleteBookDetails_ReturnNotExist()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).ReturnsAsync(1);
            mockRepository.Setup(x => x.BookDetailsExists(It.IsAny<int>())).ReturnsAsync(false);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = await sut.DeleteBookDetails(4);

            ///Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
        }
    }
}
