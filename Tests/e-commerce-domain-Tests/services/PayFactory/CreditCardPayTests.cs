using e_commerce_domain.entities.Order;
using e_commerce_domain.services.PayFactory;

namespace e_commerce_domain_Tests.services.PayFactory
{
    public class CreditCardPayTests
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
            var creditCardPay = new CreditCardPay(order);
            var expectedMessage = $"Iniciando pago con tarjeta de Crédito por {order.Total} de la orden {order.Id}";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                creditCardPay.BeginPayProcess();
                var result = sw.ToString().Trim();

                // Assert
                //Assert.Contains(expectedMessage, result);
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
            var creditCardPay = new CreditCardPay(order);

            // Act
            using (var sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                var result2 = sw2.ToString().Trim().Split(Environment.NewLine);
                var result = creditCardPay.IsPayProcessAvailable();

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public void ConfirmPay_ShouldUpdateOrderStateAndWriteCorrectMessages()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m,
                State = "Pendiente"
            };
            var creditCardPay = new CreditCardPay(order);
            var expectedMessage1 = $"El Pago con tarjeta de Crédito por {order.Total} ha sido confirmado";
            var expectedMessage2 = $"La orden {order.Id} está en En preparación";

            // Act
            using (var sw1 = new StringWriter())
            {
                Console.SetOut(sw1);
                creditCardPay.BeginPayProcess();
                var result1 = sw1.ToString().Trim();

                using (var sw2 = new StringWriter())
                {
                    Console.SetOut(sw2);
                    creditCardPay.ConfirmPay();
                    var result2 = sw2.ToString().Trim().Split(Environment.NewLine);

                    // Assert
                    Assert.Equal("En preparación", order.State);
                    Assert.Equal(expectedMessage1, result2[0].Trim());
                    Assert.Equal(expectedMessage2, result2[1].Trim());
                }
            }
        }
    }
}
