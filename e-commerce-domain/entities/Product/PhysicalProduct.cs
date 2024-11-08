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
        public decimal Weight { get; set; }
        /// <summary>
        /// Altura
        /// </summary>
        public decimal Height { get; set; }
        /// <summary>
        /// Ancho
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// Largo
        /// </summary>
        public decimal Lenght { get; set; }
        public decimal BaseShipingCost { get; set; }

        /// <summary>
        /// Sobre escritura del método: Calcula el precio total del producto teniendo en cuenta los costos de envio
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateTotalValue()
        {
            var taxvalue = GrossValue * TaxPercentaje / 100;
            var disccountValue = GrossValue * DiscPercentaje / 100;
            var shippingCost = BaseShipingCost * (Width * Height * Lenght);

            return GrossValue + taxvalue - disccountValue + shippingCost;
        }

        /// <summary>
        /// Sobre escritura del método: Muestra la información del producto basada en los atributos propios
        /// </summary>
        /// <returns></returns>
        public override string ShowInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"El producto {Name} de tipo {nameof(PhysicalProduct)} ");
            stringBuilder.AppendLine($"Tiene un peso total de {Weight} Kg");
            stringBuilder.AppendLine($"Y mide {Height} x {Width} + {Lenght} cm en total ");
            stringBuilder.AppendLine($"Su costo total es de {CalculateTotalValue()}");
            stringBuilder.AppendLine($"Teniendo en cuenta su volumen y costos de envio");

            return stringBuilder.ToString();
        }
    }

}
