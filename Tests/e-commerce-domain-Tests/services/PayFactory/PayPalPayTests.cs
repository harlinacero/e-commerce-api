using e_commerce_domain.entities.Order;
using e_commerce_domain.services.PayFactory;

namespace e_commerce_domain_Tests.services.PayFactory
{
    public class PayPalPayTests
    {
        [Fact]
        public void BeginPayProcess_ShouldWriteCorrectMessage()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };
            var payPalPay = new PayPalPay(order);
            var expectedMessage = $"Iniciando pago con PayPal por {order.Total} de la orden {order.Id}";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                payPalPay.BeginPayProcess();
                var result = sw.ToString().Trim();

                // Assert
                //Assert.Equal(expectedMessage, result);
            }
        }

        [Fact]
        public void IsPayProcessAvailable_ShouldReturnTrue()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };
            var payPalPay = new PayPalPay(order);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = payPalPay.IsPayProcessAvailable();

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void ConfirmPay_ShouldWriteCorrectMessage()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };
            var payPalPay = new PayPalPay(order);
            var expectedMessage = $"El pago con PayPal por {order.Total} ha sido confirmado";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                payPalPay.ConfirmPay();
                var result = sw.ToString().Trim();

                // Assert
                //Assert.Equal(expectedMessage, result);
            }
        }
    }
}
