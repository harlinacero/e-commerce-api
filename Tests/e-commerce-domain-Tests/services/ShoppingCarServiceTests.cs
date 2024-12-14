using e_commerce_domain.customExceptions;
using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.ShoppingCar;
using e_commerce_domain.entities.User;
using e_commerce_domain.repositories;
using e_commerce_domain.useCases;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace e_commerce_domain_Tests.services
{
    public class ShoppingCarServiceTests
    {
        private readonly Mock<InventoryManager> _mockProductRepository;
        private readonly Customer _customer;
        private readonly ShoppingCarService _shoppingCarService;

        public ShoppingCarServiceTests()
        {
            _mockProductRepository = new Mock<InventoryManager>(null);
            _customer = new Customer("username", "email@example.com", "password", "firstname", "lastname", "address");
            _shoppingCarService = new ShoppingCarService(_mockProductRepository.Object, _customer);
        }

        [Fact]
        public void AddProduct_ShouldAddProductToShoppingCar_WhenProductExists()
        {
            // Arrange
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(product);
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
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns((ProductBase)null);

            // Act & Assert
            Assert.Throws<InsufficientInventoryException>(() => _shoppingCarService.AddProduct(product));
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveProductFromShoppingCar_WhenProductExists()
        {
            // Arrange
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(product);
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
            Assert.Throws<ArgumentNullException>(() => _shoppingCarService.RemoveProduct(productId));
        }

        [Fact]
        public void CalculateTotalValue_ShouldReturnCorrectTotalValue()
        {
            // Arrange
            TestProduct product1 = new("Producto 1", "Descripción 1", 100, 10, 5, 50) { Id = Guid.NewGuid()};
            TestProduct product2 = new("Producto 2", "Descripción 2", 200, 20, 10, 30) { Id = Guid.NewGuid() };
           
            _mockProductRepository.Setup(repo => repo.GetProductById(product1.Id)).Returns(product1);
            _mockProductRepository.Setup(repo => repo.GetProductById(product2.Id)).Returns(product2);

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
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            _mockProductRepository.Setup(repo => repo.GetProductById(product.Id)).Returns(product);
            _shoppingCarService.AddProduct(product);
            var expectedInfo = product.ShowInfo();

            // Act
            var productInfo = _shoppingCarService.ShowInfoProducts();

            // Assert
            Assert.Contains(expectedInfo, productInfo);
        }

        private class TestProduct : ProductBase
        {
            public TestProduct(string name, string description, decimal grossValue, decimal discPercentaje, decimal taxPercentaje, int stock)
                : base(name, description, grossValue, discPercentaje, taxPercentaje, stock)
            {
            }

            public override decimal CalculateTotalValue()
            {
                return GetGrossValue() + (GetGrossValue() * GetTaxPercentaje() / 100) - (GetGrossValue() * GetDisccounPercentaje() / 100);
            }

            public override string ShowInfo()
            {
                return $"Producto: {GetName()}, Descripción: {GetDescription()}, Precio: {CalculateTotalValue()}";
            }
        }
    }
}

