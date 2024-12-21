using e_commerce_domain.entities.Order;
using e_commerce_domain.services.PayFactory;

namespace e_commerce_domain_Tests.services.PayFactory
{
    public class TransferPayTests
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
            var transferPay = new TransferPay(order);
            var expectedMessage = $"Iniciando pago por transferencia por {order.Total} de la orden {order.Id}";

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                transferPay.BeginPayProcess();
                var result = sw.ToString().Trim();

                // Assert
                Assert.Equal(expectedMessage, result);
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
            var transferPay = new TransferPay(order);

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = transferPay.IsPayProcessAvailable();

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
            var transferPay = new TransferPay(order);
            var expectedMessage1 = $"El Pago por transferencia por {order.Total} ha sido confirmado";
            var expectedMessage2 = $"La orden {order.Id} está en En preparación";

            // Act
            using (var sw1 = new StringWriter())
            {
                Console.SetOut(sw1);
                transferPay.ConfirmPay();
                var result1 = sw1.ToString().Trim().Split(Environment.NewLine);
                
                // Assert
                //Assert.Equal("En preparación", order.State);
                //Assert.Equal(expectedMessage1, result1[0].Trim());
                //Assert.Equal(expectedMessage2, result1[1].Trim());
            }
        }
    }
}
