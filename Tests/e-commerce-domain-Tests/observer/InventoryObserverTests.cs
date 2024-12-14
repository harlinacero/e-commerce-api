using e_commerce_domain.entities.Product;
using e_commerce_domain.observer;

namespace e_commerce_domain_Tests.observer
{
    public class InventoryObserverTests
    {
        [Fact]
        public void OnProductAdded_ShouldWriteCorrectMessageToConsole()
        {
            // Arrange
            var observer = new InventoryObserver();
            var product = new TestProduct("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            var expectedMessage = $"Producto agregado: {product.GetName()}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                observer.OnProductAdded(product);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal(expectedMessage, result);
            }
        }

        [Fact]
        public void OnProductUpdated_ShouldWriteCorrectMessageToConsole()
        {
            // Arrange
            var observer = new InventoryObserver();
            var productId = Guid.NewGuid();
            var newStock = 100;
            var expectedMessage = $"Producto actualizado: ID={productId}, Nuevo stock={newStock}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                observer.OnProductUpdated(productId, newStock);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal(expectedMessage, result);
            }
        }

        [Fact]
        public void OnProductDeleted_ShouldWriteCorrectMessageToConsole()
        {
            // Arrange
            var observer = new InventoryObserver();
            var productId = Guid.NewGuid();
            var expectedMessage = $"Producto eliminado: ID={productId}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                observer.OnProductDeleted(productId);

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal(expectedMessage, result);
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
    }
}


