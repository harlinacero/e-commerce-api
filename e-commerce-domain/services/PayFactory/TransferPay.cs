using e_commerce_domain.entities.Order;

namespace e_commerce_domain.services.PayFactory
{
    public class TransferPay : IPayProcess
    {
        private Order _order;
        public TransferPay(Order order)
        {
            _order = order;
        }

        /// <summary>
        /// Inicia el pago por transferencia
        /// </summary>
        public void BeginPayProcess()
        {
            Console.WriteLine($"Iniciando pago por transferencia por {_order.Total} de la orden {_order.Id}");
        }

        /// <summary>
        /// Lógica para verificar que el pago por transferencia es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            Console.WriteLine("Verificando la transascción por transferencia");
            return true;
        }

        /// <summary>
        /// Lógica para confirmar el pago por transferencia
        /// </summary>
        public void ConfirmPay()
        {
            _order.State = "En preparación";
            Console.WriteLine($"El Pago por transferencia por {_order.Total} ha sido confirmado");
            Console.WriteLine($"La orden {_order.Id} está en {_order.State} ");
        }
    }
}
