using e_commerce_domain.entities.Order;

namespace e_commerce_domain.services.PayFactory
{
    /// <summary>
    /// Pago mediante tarjeta de crédito
    /// </summary>
    public class CreditCardPay : IPayProcess
    {
        private Order _order;
        public CreditCardPay(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Implementación concreta del pago con tarjeta de crédito
        /// </summary>
        public void BeginPayProcess()
        {
            Console.WriteLine($"Iniciando pago con tarjeta de Crédito por {_order.Total} de la orden {_order.Id}");
        }

        /// <summary>
        /// Lógica propia para verificar si el método de pago es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            Console.WriteLine("Verificando la transascción con tarjeta de Crédito");
            return true;
        }

        /// <summary>
        /// Confirma que el pago ha sido ejecutado
        /// </summary>
        public void ConfirmPay()
        {
            _order.State = "En preparación";
            Console.WriteLine($"El Pago con tarjeta de Crédito por {_order.Total} ha sido confirmado");
            Console.WriteLine($"La orden {_order.Id} está en {_order.State} ");
        }
    }
}
