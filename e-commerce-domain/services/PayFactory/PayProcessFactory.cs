using e_commerce_domain.entities.Order;
using e_commerce_domain.enums;

namespace e_commerce_domain.services.PayFactory
{
    public static class PayProcessFactory
    {
        /// <summary>
        /// Fábrica para el pago de una orden
        /// </summary>
        /// <param name="method"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IPayProcess Create(MethodPay method, Order order)
        {
            return method switch
            {
                MethodPay.PayPal => new PayPalPay(order),
                MethodPay.CreditCard => new CreditCardPay(order),
                MethodPay.Cash => new CashPay(order),
                MethodPay.Transfer => new TransferPay(order),
                _ => throw new InvalidOperationException("El método de pago introducido es inválido o no ha sido implementado"),
            }; ;
        }
    }
}
