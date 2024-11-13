using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

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
        private string fileFormat;
        /// <summary>
        /// Tamaño del archivo mb
        /// </summary>
        private float size;

        public DigitalProduct(string name, string description, decimal grossValue, decimal discPercentaje, decimal taxPercentaje, int stock,
            string fileFormat, float size)
            : base(name, description, grossValue, discPercentaje, taxPercentaje, stock)
        {
            this.fileFormat = fileFormat;
            this.size = size;
        }

        public string GetFileFormat()
        {
            return fileFormat;
        }

        /// <summary>
        /// Modifica el formato del producto digital
        /// </summary>
        /// <param name="fileformat"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidDataException"></exception>
        public void SetFileFormtat(string fileformat)
        {
            // Valida que el formatod el archivo no sea nul o vacio
            if (string.IsNullOrEmpty(fileformat))
            {
                throw new ArgumentNullException($"El formato del archivo no puede ser nulo o vacio {nameof(fileformat)}");
            }

            // Verifica que el formato del archivo esté dentro de las opciones válidas
            string[] validFormats = { "pdf", "xlsx", "csv", "epub", "rtf", "mobi", "swf" };
            if(!validFormats.Contains(fileformat.ToLower()))
            {
                throw new InvalidDataException($"El formato del archivo debe ser pdf, epup o rtf");
            }

            this.fileFormat = fileformat;
        }

        public float GetSize()
        {
            return size;
        }

        /// <summary>
        /// Modifica el tamaño del archivo
        /// </summary>
        /// <param name="size"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetSize(float size)
        {
            // Valida que el tamaño del archivo sea mayor a 0
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException($"El tamaño del archivo no puede menor o igual a 0");
            }
            this.size = size;
        }

        /// <summary>
        /// Sobre escritura del método: Calcula el costo total del producto teniendo sin tener en cuenta costos de envio
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateTotalValue()
        {
            var taxvalue = GetGrossValue() * GetTaxPercentaje() / 100;
            var disccountValue = GetGrossValue() * GetDisccounPercentaje() / 100;

            return GetGrossValue() + taxvalue - disccountValue;
        }

        /// <summary>
        /// Sobre escritura del método: Muestra la información del producto basada en los atributos propios
        /// </summary>
        /// <returns></returns>
        public override string ShowInfo()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"El producto {name} de tipo {nameof(DigitalProduct)} ");
            stringBuilder.AppendLine($"Es un archivo de {size}MB y será entregado en formato {GetFileFormat()}");
            stringBuilder.AppendLine($"Su costo total es de {CalculateTotalValue()}");

            return stringBuilder.ToString();
        }
    }
}


