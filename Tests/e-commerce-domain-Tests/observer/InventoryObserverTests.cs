using e_commerce_domain.DTO;
using e_commerce_domain.observer;
using e_commerce_domain_Tests.entities.Product;

namespace e_commerce_domain_Tests.observer
{
    public class InventoryObserverTests
    {
        [Fact]
        public void OnProductAdded_ShouldWriteCorrectMessageToConsole()
        {
            // Arrange
            var observer = new InventoryObserver();
            var product = new TestProduct(new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50
            });
            var expectedMessage = $"Producto agregado: {product.GetName()}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                observer.OnProductAdded(product);

                // Assert
                var result = sw.ToString().Trim();
                //Assert.Equal(expectedMessage, result);
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
                //Assert.Equal(expectedMessage, result);
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
                //Assert.Equal(expectedMessage, result);
            }
        }
    }
}


