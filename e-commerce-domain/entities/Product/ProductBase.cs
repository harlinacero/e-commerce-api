using e_commerce_domain.DTO;

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
        protected string name;
        /// <summary>
        /// Descripción detallada del producto
        /// </summary>
        protected string description;
        /// <summary>
        /// Precio bruto del producto
        /// </summary>
        protected decimal grossValue;
        /// <summary>
        /// Porcentaje de descuento del producto
        /// </summary>
        protected decimal discPercentaje;
        /// <summary>
        /// Porcentaje de impuestos del producto
        /// </summary>
        protected decimal taxPercentaje;
        /// <summary>
        /// Cantidad de stock disponible del producto
        /// </summary>
        protected int stock;

        public ProductBase(GenericProductDTO productDTO)
        {
            this.name = productDTO.Name;
            this.description = productDTO.Description;
            this.grossValue = productDTO.GrossValue;
            this.discPercentaje = productDTO.DiscPercentaje;
            this.taxPercentaje = productDTO.TaxPercentaje;
            this.stock = productDTO.Stock;
        }

        public abstract string GetName();

        public abstract void SetName(string name);

        public abstract string GetDescription();

        public abstract void SetDescription(string description);

        public abstract decimal GetGrossValue();

        public abstract void SetGrossValue(decimal grossvalue);

        public abstract decimal GetTaxPercentaje();

        public abstract void SetTaxPercentaje(decimal taxpercentaje);

        public abstract decimal GetDisccounPercentaje();

        public abstract void SetDisccountPercentaje(decimal disccountPercentaje);

        public abstract int GetStock();

        public abstract void SetStock(int stock);

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
