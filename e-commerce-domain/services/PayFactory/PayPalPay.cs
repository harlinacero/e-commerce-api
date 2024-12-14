using e_commerce_domain.customExceptions;
using e_commerce_domain.entities.Order;
using e_commerce_domain.services.Contracts;

namespace e_commerce_domain.services.PayFactory
{
    /// <summary>
    /// Pago por PayPal
    /// </summary>
    public class PayPalPay : IPayProcess
    {
        private Order _order;
        public PayPalPay(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Inicia proceso lógico para pago por paypal
        /// </summary>
        public void BeginPayProcess()
        {
            try
            {
                Console.WriteLine($"Iniciando pago con PayPal por {_order.Total} de la orden {_order.Id}");
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }

        /// <summary>
        /// Verifica que el pago por Paypal es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            try
            {
                Console.WriteLine("Verificando la transascción con PayPal");
                return true;
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }

        /// <summary>
        /// Confirma que el pago ha sido realizado
        /// </summary>
        public void ConfirmPay()
        {
            try
            {
                Console.WriteLine($"El pago con PayPal por {_order.Total} ha sido confirmado");
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }
    }
}
