using e_commerce_domain.entities.Order;
using e_commerce_domain.enums;
using e_commerce_domain.services.PayFactory;

namespace e_commerce_domain_Tests.services.PayFactory
{
    public class PayProcessFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnPayPalPay_WhenMethodIsPayPal()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };

            // Act
            var result = PayProcessFactory.Create(MethodPay.PayPal, order);

            // Assert
            Assert.IsType<PayPalPay>(result);
        }

        [Fact]
        public void Create_ShouldReturnCreditCardPay_WhenMethodIsCreditCard()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };

            // Act
            var result = PayProcessFactory.Create(MethodPay.CreditCard, order);

            // Assert
            Assert.IsType<CreditCardPay>(result);
        }

        [Fact]
        public void Create_ShouldReturnCashPay_WhenMethodIsCash()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };

            // Act
            var result = PayProcessFactory.Create(MethodPay.Cash, order);

            // Assert
            Assert.IsType<CashPay>(result);
        }

        [Fact]
        public void Create_ShouldReturnTransferPay_WhenMethodIsTransfer()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };

            // Act
            var result = PayProcessFactory.Create(MethodPay.Transfer, order);

            // Assert
            Assert.IsType<TransferPay>(result);
        }

        [Fact]
        public void Create_ShouldThrowInvalidOperationException_WhenMethodIsInvalid()
        {
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Total = 100.0m
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => PayProcessFactory.Create((MethodPay)999, order));
        }
    }
}
