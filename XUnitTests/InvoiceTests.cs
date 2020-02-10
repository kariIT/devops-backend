using devopsapi.Controllers;
using devopsapi.Models;
using devopsapi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTests
{
    public class InvoiceTests
    {
        InvoiceController _controller;
        IInvoiceService _service;

        public InvoiceTests()
        {
            _service = new FakeInvoiceService();
            _controller = new InvoiceController(_service);
        }

        // GET

        [Fact]
        public void Get_WhenCalled_ReturnsJsonResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<JsonResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as JsonResult;

            // Assert
            var items = Assert.IsType<List<Invoice>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        // GET BY ID

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(666);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsJsonResult()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.Get(1);

            // Assert
            Assert.IsType<JsonResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 2;

            // Act
            var okResult = _controller.Get(2).Result as JsonResult;

            // Assert
            Assert.IsType<Invoice>(okResult.Value);
            Assert.Equal(2, (okResult.Value as Invoice).id);
        }

        // CREATE

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Invoice()
            {
                InvoiceSender = "Mikko",
                Total = 12.00M
            };
            _controller.ModelState.AddModelError("RecipientName", "Required");

            // Act
            var badResponse = _controller.Create(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Invoice testInvoice = new Invoice()
            {
                id = 4,
                InvoiceSender = "Mikko",
                RecipientName = "Juuso",
                RecipientIBAN = "FI219222234651",
                Reference = "5521334",
                InvoiceNumber = "INV-105603",
                BIC = "NDEAFIHH",
                Total = 43.00M,
                DueDay = new DateTime(2019, 12, 24),
                Date = DateTime.Today
            };

            // Act
            var createdResponse = _controller.Create(testInvoice);

            // Assert
            Assert.IsType<JsonResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testInvoice = new Invoice()
            {
                id = 4,
                InvoiceSender = "Mikko",
                RecipientName = "Juuso",
                RecipientIBAN = "FI219222234651",
                Reference = "5521334",
                InvoiceNumber = "INV-105603",
                BIC = "NDEAFIHH",
                Total = 43.00M,
                DueDay = new DateTime(2019, 12, 24),
                Date = DateTime.Today
            };

            // Act
            var createdResponse = _controller.Create(testInvoice) as JsonResult;
            var item = createdResponse.Value as Invoice;

            // Assert
            Assert.IsType<Invoice>(item);
            Assert.Equal("5521334", item.Reference);
        }

        // DELETE

        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 999;

            // Act
            var badResponse = _controller.Delete(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var existingId = 2;

            // Act
            var okResponse = _controller.Delete(existingId);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_RemovesOneItem()
        {
            // Arrange
            var existingId = 3;

            // Act
            var okResponse = _controller.Delete(existingId);

            // Assert
            Assert.Equal(2, _service.Read().Count());
        }

        // UPDATE

        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItemId = 1;
            var nameMissingItem = new Invoice()
            {
                id = 1,
                InvoiceSender = "Matti",
                Reference = "1234567",
                InvoiceNumber = "INV-100001",
                BIC = "OKOYFIHH",
                Total = 10.20M,
                DueDay = new DateTime(2019, 12, 24),
                Date = DateTime.Today
            };
            _controller.ModelState.AddModelError("RecipientName", "Required");

            // Act
            var badResponse = _controller.Update(nameMissingItemId, nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testInvoiceId = 3;
            Invoice testInvoice = new Invoice()
            {
                id = 3,
                InvoiceSender = "Vesa",
                RecipientName = "Elastinen",
                RecipientIBAN = "FI219255234651",
                Reference = "5522334",
                InvoiceNumber = "INV-103003",
                BIC = "NDEAFIHH",
                Total = 20.00M,
                DueDay = new DateTime(2020, 2, 28),
                Date = DateTime.Today
            };

            // Act
            var updatedResponse = _controller.Update(testInvoiceId, testInvoice);

            // Assert
            Assert.IsType<JsonResult>(updatedResponse);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnedResponseHasUpdatedItem()
        {
            // Arrange
            var testInvoiceId = 3;
            var testInvoice = new Invoice()
            {
                id = 3,
                InvoiceSender = "Vesa",
                RecipientName = "Elastinen",
                RecipientIBAN = "FI219255234651",
                Reference = "5521334",
                InvoiceNumber = "INV-103003",
                BIC = "NDEAFIHH",
                Total = 500.00M,
                DueDay = new DateTime(2020, 2, 28),
                Date = DateTime.Today
            };

            // Act
            var updatedResponse = _controller.Update(testInvoiceId, testInvoice) as JsonResult;
            var item = updatedResponse.Value as Invoice;

            // Assert
            Assert.IsType<Invoice>(item);
            Assert.Equal("Elastinen", item.RecipientName);
            Assert.Equal("5521334", item.Reference);
            Assert.Equal(new DateTime(2020, 2, 28), item.DueDay);
        }

    }
}
