using System.Drawing;
using System.Text;

namespace e_commerce_domain.entities.Product
{
    /// <summary>
    /// Producto Físico
    /// </summary>
    public class PhysicalProduct : ProductBase
    {
        /// <summary>
        /// Peso
        /// </summary>
        private decimal weight;
        /// <summary>
        /// Altura
        /// </summary>
        private decimal height;
        /// <summary>
        /// Ancho
        /// </summary>
        private decimal width;
        /// <summary>
        /// Largo
        /// </summary>
        private decimal lenght;
        /// <summary>
        /// Costo básico del envio
        /// </summary>
        private decimal baseShipingCost;

        public PhysicalProduct(string name, string description, decimal grossValue, decimal discPercentaje, decimal taxPercentaje, int stock,
            decimal weight, decimal height, decimal width, decimal lenght, decimal baseShipingCost) 
            : base(name, description, grossValue, discPercentaje, taxPercentaje, stock)
        {
            this.Id = Guid.NewGuid();
            this.weight = weight;
            this.height = height;
            this.width = width;
            this.lenght = lenght;
            this.baseShipingCost = baseShipingCost;
        }

        public decimal GetWeight()
        {
            return weight;
        }
        public void SetWeight(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("El peso del producto no puede ser menor o igual a 0");
            }

            weight = value;
        }

        public decimal GetHeight()
        {
            return height;
        }
        public void SetHeight(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("La altura del producto no puede ser menor o igual a 0");
            }

            height = value;
        }


        public decimal GetWidth()
        {
            return width;
        }

        public void SetWidth(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("El ancho del producto no puede ser menor o igual a 0");
            }

            width = value;
        }


        public decimal GetLenght()
        {
            return lenght;
        }

        public void SetLenght(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("El largo del producto no puede ser menor o igual a 0");
            }

            lenght = value;
        }


        public decimal GetBaseShipingCost()
        {
            return baseShipingCost;
        }

        /// <summary>
        /// Costo básico del envio
        /// </summary>
        public void SetBaseShipingCost(decimal value)
        {
            baseShipingCost = value;
        }

        /// <summary>
        /// Sobre escritura del método: Calcula el precio total del producto teniendo en cuenta los costos de envio
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateTotalValue()
        {
            var taxvalue = GetGrossValue() * GetTaxPercentaje() / 100;
            var disccountValue = GetGrossValue() * GetDisccounPercentaje() / 100;
            var shippingCost = GetBaseShipingCost() * (GetWidth() * GetHeight() * GetLenght());

            return GetGrossValue() + taxvalue - disccountValue + shippingCost;
        }

        /// <summary>
        /// Sobre escritura del método: Muestra la información del producto basada en los atributos propios
        /// </summary>
        /// <returns></returns>
        public override string ShowInfo()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"El producto {name} de tipo {nameof(PhysicalProduct)} ");
            stringBuilder.AppendLine($"Tiene un peso total de {weight} Kg");
            stringBuilder.AppendLine($"Y mide {height} x {width} + {lenght} cm en total ");
            stringBuilder.AppendLine($"Su costo total es de {CalculateTotalValue()}");
            stringBuilder.AppendLine($"Teniendo en cuenta su volumen y costos de envio");

            return stringBuilder.ToString();
        }
    }

}
