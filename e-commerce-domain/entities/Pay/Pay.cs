using e_commerce_domain.entities.Order;

namespace e_commerce_domain.entities.Pay
{
    /// <summary>
    /// Pago de la orden
    /// </summary>
    public class Pay : EntityBase
    {
        /// <summary>
        /// Método de pago: tarjeta, efectivo, transferencia, etc.
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Valor del pago
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Orden que requiere el pago
        /// </summary>
        public Order.Order Order { get; set; }

    }
}
