using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;

namespace e_commerce_domain_Tests.repositories
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
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act
            inventoryManager.AddProduct(product);

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
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            inventoryManager.AddProduct(product);

            // Act
            inventoryManager.UpdateStock(product.Id, 100);

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
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            inventoryManager.AddProduct(product);

            // Act
            inventoryManager.DeleteProduct(product.Id);

            // Assert
            Assert.True(observer.ProductDeletedNotified);
        }

        private class TestInventoryManager : InventoryManager
        {
            private readonly List<ProductBase> _products = new();

            public TestInventoryManager(List<IInventoryObserver> observers) : base(observers)
            {

            }

            public override void AddProduct(ProductBase product)
            {
                _products.Add(product);
                NotifyProductAdded(product);
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

            public override ProductBase GetProductById(Guid id)
            {
                return _products.Find(p => p.Id == id);
            }

            public override ProductBase GetProductByName(string name)
            {
                return _products.Find(p => p.GetName() == name);
            }

            public override IEnumerable<ProductBase> GetAll()
            {
                return _products;
            }

            public void AddObserver(IInventoryObserver observer)
            {
                _observers.Add(observer);
            }

            public void RemoveObserver(IInventoryObserver observer)
            {
                _observers.Remove(observer);
            }

            public List<IInventoryObserver> GetObservers()
            {
                return _observers;
            }
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