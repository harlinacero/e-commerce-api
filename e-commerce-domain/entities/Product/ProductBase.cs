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

        public ProductBase(string name, string description, decimal grossValue, decimal discPercentaje, decimal taxPercentaje, int stock)
        {
            this.name = name;
            this.description = description;
            this.grossValue = grossValue;
            this.discPercentaje = discPercentaje;
            this.taxPercentaje = taxPercentaje;
            this.stock = stock;
        }


        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            if (name.Trim().Length <= 5 || name.Length > 20)
            {
                throw new ArgumentOutOfRangeException($"El nombre del producto {name} no puede ser menor a 5 caracteres ni mayor a 20 caracteres");
            }

            this.name = name;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public decimal GetGrossValue()
        {
            return grossValue;
        }

        public void SetGrossValue(decimal grossvalue)
        {
            if (grossValue <= 0)
            {
                throw new ArgumentOutOfRangeException($"El valor base del producto no puede ser menor o igual a 0");
            }
            grossValue = grossvalue;
        }

        public decimal GetTaxPercentaje()
        {
            return taxPercentaje;
        }

        public void SetTaxPercentaje(decimal taxpercentaje)
        {
            if (taxpercentaje < 0 || taxPercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del impuesto no puede ser menor a 0 ni mayor a 100");
            }

            taxPercentaje = taxpercentaje;
        }

        public decimal GetDisccounPercentaje()
        {
            return discPercentaje;
        }

        public void SetDisccountPercentaje(decimal disccountPercentaje)
        {
            if (disccountPercentaje < 0 || disccountPercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del descuento no puede ser menor a 0 ni mayor a 100");
            }

            discPercentaje = disccountPercentaje;
        }

        public int GetStock()
        {
            return stock;
        }

        public void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentOutOfRangeException($"El stock del producto no puede ser menor a 0");
            }
            this.stock = stock;
        }



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
