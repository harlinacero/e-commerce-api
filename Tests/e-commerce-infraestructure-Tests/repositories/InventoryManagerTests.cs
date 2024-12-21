using e_commerce_domain.customExceptions;
using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;
using e_commerce_domain_Tests.entities.Product;
using e_commerce_infraestructure.Reposotory;

namespace e_commerce_infraestructure_Tests.repositories
{
    public class InventoryManagerTests
    {
        [Fact]
        public void AddObserver_ShouldAddObserverToList()
        {
            // Arrange
            var inventoryManager = new TestInventoryManager(new List<IInventoryObserver>());
            var observer = new MockInventoryObserver();

            // Act
            inventoryManager.AddObserver(observer);

            // Assert
            Assert.Contains(observer, inventoryManager.GetObservers());
        }

        [Fact]
        public void RemoveObserver_ShouldRemoveObserverFromList()
        {
            // Arrange
            var inventoryManager = new TestInventoryManager(new List<IInventoryObserver>());
            var observer = new MockInventoryObserver();
            inventoryManager.AddObserver(observer);

            // Act
            inventoryManager.RemoveObserver(observer);

            // Assert
            Assert.DoesNotContain(observer, inventoryManager.GetObservers());
        }

        [Fact]
        public void NotifyProductAdded_ShouldNotifyObservers()
        {
            // Arrange
            var inventoryManager = new TestInventoryManager(new List<IInventoryObserver>());
            var observer = new MockInventoryObserver();
            inventoryManager.AddObserver(observer);
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            //var product = new TestProduct(dto);

            // Act
            inventoryManager.AddProduct(dto);

            // Assert
            Assert.True(observer.ProductAddedNotified);
        }

        [Fact]
        public void NotifyProductUpdated_ShouldNotifyObservers()
        {
            // Arrange
            var inventoryManager = new TestInventoryManager(new List<IInventoryObserver>());
            var observer = new MockInventoryObserver();
            inventoryManager.AddObserver(observer);
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            //var product = new TestProduct(dto);
            inventoryManager.AddProduct(dto);

            // Act
            inventoryManager.UpdateStock(dto.Id, 100);

            // Assert
            Assert.True(observer.ProductUpdatedNotified);
        }

        [Fact]
        public void NotifyProductDeleted_ShouldNotifyObservers()
        {
            // Arrange
            var inventoryManager = new TestInventoryManager(new List<IInventoryObserver>());
            var observer = new MockInventoryObserver();
            inventoryManager.AddObserver(observer);
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            //var product = new TestProduct(dto);
            inventoryManager.AddProduct(dto);

            // Act
            inventoryManager.DeleteProduct(dto.Id);

            // Assert
            Assert.True(observer.ProductDeletedNotified);
        }

        private class TestInventoryManager : InventoryManager
        {
            private readonly List<ProductBase> _products = new();

            public TestInventoryManager(List<IInventoryObserver> observers) : base(observers)
            {

            }

            public override void DeleteProduct(Guid idProduct)
            {
                var product = _products.Find(p => p.Id == idProduct);
                if (product != null)
                {
                    _products.Remove(product);
                    NotifyProductDeleted(idProduct);
                }
            }

            public override void UpdateStock(Guid idStock, int stock)
            {
                var product = _products.Find(p => p.Id == idStock);
                if (product != null)
                {
                    product.SetStock(stock);
                    NotifyProductUpdated(idStock, stock);
                }
            }

            public override GenericProductDTO GetProductById(Guid id)
            {
                if (_products == null)
                {
                    throw new InsufficientInventoryException("No hay productos en el inventario");
                }

                var product = _products.Find(p => p.Id == id);
                return product == null
                    ? throw new InsufficientInventoryException("Producto no encontrado")
                    : new GenericProductDTO()
                {
                    Id = product.Id,
                    Name = product.GetName(),
                    Description = product.GetDescription(),
                    GrossValue = product.GetGrossValue(),
                    DiscPercentaje = product.GetDisccounPercentaje(),
                    TaxPercentaje = product.GetTaxPercentaje(),
                    Stock = product.GetStock()
                };
            }

            public override GenericProductDTO GetProductByName(string name)
            {
                var product = _products.Find(p => p.GetName() == name);
                return product == null
                    ? throw new InsufficientInventoryException("Producto no encontrado")
                    : new GenericProductDTO()
                    {
                        Id = product.Id,
                        Name = product.GetName(),
                        Description = product.GetDescription(),
                        GrossValue = product.GetGrossValue(),
                        DiscPercentaje = product.GetDisccounPercentaje(),
                        TaxPercentaje = product.GetTaxPercentaje(),
                        Stock = product.GetStock()
                    };
            }

            public override IEnumerable<GenericProductDTO> GetAll()
            {
                List<GenericProductDTO> products = new();
                foreach (var product in _products)
                {
                    products.Add(new GenericProductDTO()
                    {
                        Id = product.Id,
                        Name = product.GetName(),
                        Description = product.GetDescription(),
                        GrossValue = product.GetGrossValue(),
                        DiscPercentaje = product.GetDisccounPercentaje(),
                        TaxPercentaje = product.GetTaxPercentaje(),
                        Stock = product.GetStock()
                    });
                }
                return products;
            }

            public new void AddObserver(IInventoryObserver observer)
            {
                _observers.Add(observer);
            }

            public new void RemoveObserver(IInventoryObserver observer)
            {
                _observers.Remove(observer);
            }

            public List<IInventoryObserver> GetObservers()
            {
                return _observers;
            }

            public override void AddProduct(GenericProductDTO dto)
            {
                var product = new TestProduct(dto);
                _products.Add(product);
                NotifyProductAdded(product);
            }
        }


        private class MockInventoryObserver : IInventoryObserver
        {
            public bool ProductAddedNotified { get; private set; }
            public bool ProductUpdatedNotified { get; private set; }
            public bool ProductDeletedNotified { get; private set; }

            public void OnProductAdded(ProductBase product)
            {
                ProductAddedNotified = true;
            }

            public void OnProductUpdated(Guid productId, int newStock)
            {
                ProductUpdatedNotified = true;
            }

            public void OnProductDeleted(Guid productId)
            {
                ProductDeletedNotified = true;
            }
        }
    }
}