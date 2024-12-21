using e_commerce_api.Controllers;
using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.ProductsFactory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace e_commerce_api_Tests.Conttollers
{
    public class ProductControllerTests
    {
        private readonly Mock<IInventoryManager> _mockPhysicalInventoryManager;
        private readonly Mock<IInventoryManager> _mockDigitalInventoryManager;
        private readonly Mock<InventoryManagerFactory> _mockPhysicalInventoryManagerFactory;
        private readonly Mock<InventoryManagerFactory> _mockDigitalInventoryManagerFactory;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockPhysicalInventoryManager = new Mock<IInventoryManager>();
            _mockDigitalInventoryManager = new Mock<IInventoryManager>();
            _mockPhysicalInventoryManagerFactory = new Mock<InventoryManagerFactory>(ProductType.Physical);
            _mockDigitalInventoryManagerFactory = new Mock<InventoryManagerFactory>(ProductType.Digital);

            _mockPhysicalInventoryManagerFactory.Setup(f => f.CreateInventoryManagerFactory()).Returns(_mockPhysicalInventoryManager.Object);
            _mockDigitalInventoryManagerFactory.Setup(f => f.CreateInventoryManagerFactory()).Returns(_mockDigitalInventoryManager.Object);

            _controller = new ProductController();
        }

        //[Fact]
        //public void GetAllProducts_ReturnsAllProducts()
        //{
        //    // Arrange
        //    var dto = new GenericProductDTO()
        //    {
        //        ProductType = ProductType.Physical,
        //        Name = "Product1",
        //        Description = "Description1",
        //        GrossValue = 100,
        //        DiscPercentaje = 10,
        //        TaxPercentaje = 5,
        //        Stock = 50
        //    };
        //    var product = new PhysicalProduct(dto);
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetAll()).Returns(new List<GenericProductDTO> { dto });
        //    // Act
        //    var result = _controller.GetAllProducts();

        //    // Assert
        //    Assert.NotEmpty(result);
        //}

        //[Fact]
        //public void GetAllProducts_ReturnsEmpty_WhenNoProducts()
        //{
        //    // Arrange
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetAll()).Returns(new List<GenericProductDTO>());
        //    _mockDigitalInventoryManager.Setup(repo => repo.GetAll()).Returns(new List<GenericProductDTO>());
        //    // Act
        //    var result = _controller.GetAllProducts();

        //    // Assert
        //    Assert.Empty(result);
        //}

        //[Fact]
        //public void GetProductById_ReturnsProduct_WhenProductExists()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    var product = new PhysicalProduct("Product1", "Description1", 100, 10, 5, 50, 10, 10, 5, 10, 10) { Id = productId};
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns(product);

        //    // Act
        //    var result = _controller.GetProductById(productId, ProductType.Physical);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var returnedProduct = Assert.IsType<PhysicalProduct>(okResult.Value);
        //    Assert.Equal(productId, returnedProduct.Id);
        //}

        //[Fact]
        //public void GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns((ProductBase)null);

        //    // Act
        //    var result = _controller.GetProductById(productId, ProductType.Physical);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        [Fact]
        public void CreateProduct_ReturnsCreatedAtActionResult_WhenProductIsCreated()
        {
            // Arrange
            var productDto = new GenericProductDTO
            {
                ProductType = ProductType.Physical,
                Name = "Product1",
                Description = "Description1",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            };

            // Act
            var result = _controller.CreateProduct(productDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetProductById), createdAtActionResult.ActionName);
        }

        //[Fact]
        //public void CreateProduct_ReturnsBadRequest_WhenExceptionThrown()
        //{
        //    // Arrange
        //    var productDto = new GenericProductDTO
        //    {
        //        ProductType = ProductType.Physical,
        //        Name = "Product1",
        //        Description = "Description1",
        //        GrossValue = 100,
        //        DiscPercentaje = 10,
        //        TaxPercentaje = 5,
        //        Stock = 50
        //    };
        //    _mockPhysicalInventoryManager.Setup(repo => repo.AddProduct(It.IsAny<ProductBase>())).Throws(new Exception("Error"));

        //    // Act
        //    var result = _controller.CreateProduct(productDto);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        //    Assert.Equal("Error", badRequestResult.Value);
        //}

        //[Fact]
        //public void UpdateProduct_ReturnsOkResult_WhenProductIsUpdated()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    var productDto = new GenericProductDTO
        //    {
        //        ProductType = ProductType.Physical,
        //        Name = "UpdatedProduct",
        //        Description = "UpdatedDescription",
        //        GrossValue = 150,
        //        DiscPercentaje = 15,
        //        TaxPercentaje = 10,
        //        Stock = 30
        //    };

        //    var existingProduct = new PhysicalProduct("Product1", "Description1", 100, 10, 5, 50, 10, 10, 5, 10, 10);
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns(existingProduct);

        //    // Act
        //    var result = _controller.UpdateProduct(productId, productDto, ProductType.Physical);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public void UpdateProduct_ReturnsNotFound_WhenProductDoesNotExist()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    var productDto = new GenericProductDTO
        //    {
        //        ProductType = ProductType.Physical,
        //        Name = "UpdatedProduct",
        //        Description = "UpdatedDescription",
        //        GrossValue = 150,
        //        DiscPercentaje = 15,
        //        TaxPercentaje = 10,
        //        Stock = 30
        //    };
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns((ProductBase)null);

        //    // Act
        //    var result = _controller.UpdateProduct(productId, productDto, ProductType.Physical);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public void DeleteProduct_ReturnsNoContentResult_WhenProductIsDeleted()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    var existingProduct = new PhysicalProduct("Product1", "Description1", 100, 10, 5, 50, 10, 10, 5, 10, 10);
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns(existingProduct);

        //    // Act
        //    var result = _controller.DeleteProduct(productId, ProductType.Physical);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        //[Fact]
        //public void DeleteProduct_ReturnsNotFound_WhenProductDoesNotExist()
        //{
        //    // Arrange
        //    var productId = Guid.NewGuid();
        //    _mockPhysicalInventoryManager.Setup(repo => repo.GetProductById(productId)).Returns((ProductBase)null);

        //    // Act
        //    var result = _controller.DeleteProduct(productId, ProductType.Physical);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}
    }
}
