using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;

namespace e_commerce_domain.entities.Order
{
    /// <summary>
    /// Establece un pedido
    /// </summary>
    public class Order : EntityBase
    {
        /// <summary>
        /// Cliente que genera la orden
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Lista de productos asociados a la orden
        /// </summary>
        public ICollection<ProductBase> Products { get; set; }
        /// <summary>
        /// Fecha de la orden
        /// </summary>
        public DateTime Date {  get; set; }
        /// <summary>
        /// Estado de la orden Pendiente, En camino, Entregado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Valor total de la orden
        /// </summary>
        public decimal Total { get; set; }
    }
}
