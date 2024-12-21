using e_commerce_domain.customExceptions;
using e_commerce_domain.entities.Order;
using e_commerce_domain.services.Contracts;

namespace e_commerce_application.services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }
        public string CreateOrder(Order order)
        {
            IPayProcess payProcess = e_commerce_domain.services.PayFactory.PayProcessFactory.Create(order.MethodPay, order);
            payProcess.BeginPayProcess();
            if (payProcess.IsPayProcessAvailable())
            {
                payProcess.ConfirmPay();
                return $"La orden {order.Id} fue creada exitosamente";
            }

            throw new CreateOrderException("La orden no pudo ser creada");
        }

        public string FollowOrder(Guid order)
        {
            // Buscar la orden en el repositorio
            if (true)
            {
                return "La orden se encuentra en camino";
            }
            // Si no existe, lanzar excepción
            throw new ArgumentNullException("El id de la orden no puede ser nulo");
        }
    }
}
