using e_commerce_domain.DTO;
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

        public PhysicalProduct(GenericProductDTO productDTO) 
            : base(productDTO)
        {
            this.Id = productDTO.Id;
            this.weight = productDTO.Weight;
            this.height = productDTO.Height;
            this.width = productDTO.Width;
            this.lenght = productDTO.Length;
            this.baseShipingCost = productDTO.BaseShippingCost;
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

        public override string GetName()
        {
            return name;
        }

        public override void SetName(string name)
        {
            if (name.Trim().Length <= 5 || name.Length > 20)
            {
                throw new ArgumentOutOfRangeException($"El nombre del producto {name} no puede ser menor a 5 caracteres ni mayor a 20 caracteres");
            }

            this.name = name;
        }

        public override string GetDescription()
        {
            return description;
        }

        public override void SetDescription(string description)
        {
            this.description = description;
        }

        public override decimal GetGrossValue()
        {
            return grossValue;
        }

        public override void SetGrossValue(decimal grossvalue)
        {
            if (grossvalue <= 0)
            {
                throw new ArgumentOutOfRangeException($"El valor base del producto no puede ser menor o igual a 0");
            }
            grossValue = grossvalue;
        }

        public override decimal GetTaxPercentaje()
        {
            return taxPercentaje;
        }

        public override void SetTaxPercentaje(decimal taxpercentaje)
        {
            if (taxpercentaje < 0 || taxpercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del impuesto no puede ser menor a 0 ni mayor a 100");
            }

            taxPercentaje = taxpercentaje;
        }

        public override decimal GetDisccounPercentaje()
        {
            return discPercentaje;
        }

        public override void SetDisccountPercentaje(decimal disccountPercentaje)
        {
            if (disccountPercentaje < 0 || disccountPercentaje > 100)
            {
                throw new ArgumentOutOfRangeException($"El porcentaje del descuento no puede ser menor a 0 ni mayor a 100");
            }

            discPercentaje = disccountPercentaje;
        }

        public override int GetStock()
        {
            return stock;
        }

        public override void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentOutOfRangeException($"El stock del producto no puede ser menor a 0");
            }
            this.stock = stock;
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
