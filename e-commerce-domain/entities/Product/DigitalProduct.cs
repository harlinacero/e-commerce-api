using e_commerce_domain.DTO;
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
        private string fileFormat;
        /// <summary>
        /// Tamaño del archivo mb
        /// </summary>
        private float size;

        public DigitalProduct(GenericProductDTO productDTO)
            : base(productDTO)
        {
            this.Id = productDTO.Id;
            this.fileFormat = productDTO.FileFormat;
            this.size = productDTO.Size;
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


