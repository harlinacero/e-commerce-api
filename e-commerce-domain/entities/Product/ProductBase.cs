namespace e_commerce_domain.entities.Product
{
    /// <summary>
    /// Producto base
    /// </summary>
    public abstract class ProductBase : EntityBase
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descripción detallada del producto
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Precio bruto del producto
        /// </summary>
        public decimal GrossValue { get; set; }
        /// <summary>
        /// Porcentaje de descuento del producto
        /// </summary>
        public decimal DiscPercentaje { get; set; }
        /// <summary>
        /// Porcentaje de impuestos del producto
        /// </summary>
        public decimal TaxPercentaje { get; set; }
        /// <summary>
        /// Cantidad de stock disponible del producto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Calcula el valor total del producto teniendo en cuenta elementos propios de la implementación
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateTotalValue();
        /// <summary>
        /// Muestra el detalle del producto teniendo en cuenta elementos propios de la implementación
        /// </summary>
        public abstract string ShowInfo();
    }

}
