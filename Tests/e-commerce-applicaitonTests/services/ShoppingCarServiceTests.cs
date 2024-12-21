using e_commerce_application.services;
using e_commerce_domain.customExceptions;
using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;
using e_commerce_domain.repositories;
using e_commerce_domain_Tests.entities.Product;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace e_commerce_applicaitonTests.services
{
    public class ShoppingCarServiceTests
    {
        private readonly Mock<IInventoryManager> _mockProductRepository;
        private readonly Customer _customer;
        private readonly ShoppingCarService _shoppingCarService;

        public ShoppingCarServiceTests()
        {
            _mockProductRepository = new Mock<IInventoryManager>();
            _customer = new Customer("username", "email@example.com", "password", "firstname", "lastname", "address");
            _shoppingCarService = new ShoppingCarService(_mockProductRepository.Object);
        }

        [Fact]
        public void AddProduct_ShouldAddProductToShoppingCar_WhenProductExists()
        {
            // Arrange
            var dto = new GenericProductDTO() {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };
            var product = new TestProduct(dto);

            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(dto);
            var expectedInfo = "";
            // Act
            _shoppingCarService.AddProduct(product);

            // Assert
            var info = _shoppingCarService.ShowInfoProducts();
            Assert.Contains(expectedInfo, _shoppingCarService.ShowInfoProducts());
        }

        [Fact]
        public void AddProduct_ShouldThrowProductNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };
            var product = new TestProduct(dto);
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns((GenericProductDTO)null);

            // Act & Assert
            Assert.Throws<InsufficientInventoryException>(() => _shoppingCarService.AddProduct(product));
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveProductFromShoppingCar_WhenProductExists()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };
            var product = new TestProduct(dto);

            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(dto);
            _shoppingCarService.AddProduct(product);
            var expectedInfo = "";
            // Act
            _shoppingCarService.RemoveProduct(product.Id);

            var info = _shoppingCarService.ShowInfoProducts();
            // Assert
            Assert.Contains(expectedInfo, _shoppingCarService.ShowInfoProducts());
        }

        [Fact]
        public void RemoveProduct_ShouldThrowProductNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act & Assert
            _ = Assert.Throws<ArgumentNullException>(() => _shoppingCarService.RemoveProduct(productId));
        }

        [Fact]
        public void CalculateTotalValue_ShouldReturnCorrectTotalValue()
        {
            // Arrange
            var dto1 = new GenericProductDTO()
            {
                Name = "Producto de Prueba 1",
                Description = "Descripción 1",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };

            var dto2 = new GenericProductDTO()
            {
                Name = "Producto de Prueba 2",
                Description = "Descripción 2",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };

            TestProduct product1 = new(dto1);
            TestProduct product2 = new(dto2);

            _mockProductRepository.Setup(repo => repo.GetProductById(product1.Id)).Returns(dto1);
            _mockProductRepository.Setup(repo => repo.GetProductById(product2.Id)).Returns(dto2);

            _shoppingCarService.AddProduct(product1);
            _shoppingCarService.AddProduct(product2);

            var product1TotalValue = product1.CalculateTotalValue();
            var product2TotalValue = product2.CalculateTotalValue();
            var expectedTotalValue = product1TotalValue + product2TotalValue;
            // Act
            var totalValue = _shoppingCarService.CalculateTotalValue();

            // Assert
            Assert.Equal(expectedTotalValue, totalValue);
        }

        [Fact]
        public void ShowInfoProducts_ShouldReturnCorrectProductInfo()
        {
            // Arrange
            var product = new TestProduct(new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            });

            var dto = new GenericProductDTO()
            {
                Name = product.GetName(),
                Description = product.GetDescription(),
                GrossValue = product.GetGrossValue(),
                DiscPercentaje = product.GetDisccounPercentaje(),
                TaxPercentaje = product.GetTaxPercentaje(),
                Stock = product.GetStock()
            };
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(dto);
            _shoppingCarService.AddProduct(product);
            var expectedInfo = product.ShowInfo();

            // Act
            var productInfo = _shoppingCarService.ShowInfoProducts();

            // Assert
            Assert.Contains(expectedInfo, productInfo);
        }

    }
}
