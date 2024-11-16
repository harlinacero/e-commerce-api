using e_commerce_domain.entities.Order;

namespace e_commerce_domain.services.PayFactory
{
    /// <summary>
    /// Pago en efectivo
    /// </summary>
    public class CashPay : IPayProcess
    {
        private Order _order;
        public CashPay(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Inicia el pago en efectivo
        /// </summary>
        public void BeginPayProcess()
        {
            Console.WriteLine($"Iniciando pago en efectivo por {_order.Total} de la orden {_order.Id}");
        }

        /// <summary>
        /// Lógica para verificar que el dinero en efectivo es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            Console.WriteLine("Verificando la transascción en efectivo");
            return true;
        }

        /// <summary>
        /// Lógica para confirmar el pago en efectivo
        /// </summary>
        public void ConfirmPay()
        {
            _order.State = "En preparación";
            Console.WriteLine($"El Pago en efectivo por {_order.Total} ha sido confirmado");
            Console.WriteLine($"La orden {_order.Id} está en {_order.State} ");
        }
    }
}
