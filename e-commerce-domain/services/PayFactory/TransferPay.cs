using e_commerce_domain.customExceptions;
using e_commerce_domain.entities.Order;
using e_commerce_domain.services.Contracts;

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
            try
            {
                Console.WriteLine($"Iniciando pago por transferencia por {_order.Total} de la orden {_order.Id}");
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }

        /// <summary>
        /// Lógica para verificar que el pago por transferencia es válido
        /// </summary>
        /// <returns></returns>
        public bool IsPayProcessAvailable()
        {
            try
            {
                Console.WriteLine("Verificando la transascción por transferencia");
                return true;
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }

        /// <summary>
        /// Lógica para confirmar el pago por transferencia
        /// </summary>
        public void ConfirmPay()
        {
            try
            {
                _order.State = "En preparación";
                Console.WriteLine($"El Pago por transferencia por {_order.Total} ha sido confirmado");
                Console.WriteLine($"La orden {_order.Id} está en {_order.State} ");
            }
            catch (Exception ex)
            {
                throw new FailedPaymentException("Hubo un error al procesar el pago", ex.InnerException);
            }
        }
    }
}
