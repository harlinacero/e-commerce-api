using e_commerce_domain.entities.Order;

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
            Console.WriteLine($"Iniciando pago con PayPal por {_order.Total} de la orden {_order.Id}");
        }

        /// <summary>
        /// Verifica que el pago por Paypal es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            Console.WriteLine("Verificando la transascción con PayPal");
            return true;
        }

        /// <summary>
        /// Confirma que el pago ha sido realizado
        /// </summary>
        public void ConfirmPay()
        {
            Console.WriteLine($"El pago con PayPal por {_order.Total} ha sido confirmado");
        }
    }
}
