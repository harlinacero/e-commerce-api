using System.Text;

namespace e_commerce_domain.entities.Product
{
    /// <summary>
    /// Producto digital
    /// </summary>
    public class DigitalProduct : ProductBase
    {
        /// <summary>
        /// Formato del archivo PDF, XLSX, PPT, etc.
        /// </summary>
        public string FileFormat { get; set; }
        /// <summary>
        /// Tamaño del archivo mb
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// Sobre escritura del método: Calcula el costo total del producto teniendo sin tener en cuenta costos de envio
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateTotalValue()
        {
            var taxvalue = GrossValue * TaxPercentaje / 100;
            var disccountValue = GrossValue * DiscPercentaje / 100;

            return GrossValue + taxvalue - disccountValue;
        }

        /// <summary>
        /// Sobre escritura del método: Muestra la información del producto basada en los atributos propios
        /// </summary>
        /// <returns></returns>
        public override string ShowInfo()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"El producto {Name} de tipo {nameof(DigitalProduct)} ");
            stringBuilder.AppendLine($"Es un archivo de {Size}MB y será entregado en formato {FileFormat}");
            stringBuilder.AppendLine($"Su costo total es de {CalculateTotalValue()}");

            return stringBuilder.ToString();
        }
    }
}


