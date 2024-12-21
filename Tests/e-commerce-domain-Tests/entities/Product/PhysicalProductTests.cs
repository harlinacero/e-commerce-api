using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;

namespace e_commerce_domain_Tests.entities.Product
{
    public class PhysicalProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string name = "Libro Físico";
            string description = "Un libro en formato físico";
            decimal grossValue = 100;
            decimal discPercentaje = 10;
            decimal taxPercentaje = 5;
            int stock = 50;
            decimal weight = 1.5m;
            decimal height = 20;
            decimal width = 15;
            decimal lenght = 5;
            decimal baseShipingCost = 10;
            var dto = new GenericProductDTO()
            {
                Name = name,
                Description = description,
                GrossValue = grossValue,
                DiscPercentaje = discPercentaje,
                TaxPercentaje = taxPercentaje,
                Stock = stock,
                Weight = weight,
                Height = height,
                Width = width,
                Length = lenght,
                BaseShippingCost = baseShipingCost
            };

            // Act
            PhysicalProduct product = new(dto);

            // Assert
            Assert.Equal(name, product.GetName());
            Assert.Equal(description, product.GetDescription());
            Assert.Equal(grossValue, product.GetGrossValue());
            Assert.Equal(discPercentaje, product.GetDisccounPercentaje());
            Assert.Equal(taxPercentaje, product.GetTaxPercentaje());
            Assert.Equal(stock, product.GetStock());
            Assert.Equal(weight, product.GetWeight());
            Assert.Equal(height, product.GetHeight());
            Assert.Equal(width, product.GetWidth());
            Assert.Equal(lenght, product.GetLenght());
            Assert.Equal(baseShipingCost, product.GetBaseShipingCost());
        }

        [Fact]
        public void SetWeight_ShouldThrowArgumentOutOfRangeException_WhenWeightIsLessThanOrEqualToZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWeight(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWeight(-1));
        }

        [Fact]
        public void SetWeight_ShouldUpdateWeight_WhenWeightIsGreaterThanZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);
            decimal newWeight = 2.0m;

            // Act
            product.SetWeight(newWeight);

            // Assert
            Assert.Equal(newWeight, product.GetWeight());
        }

        [Fact]
        public void SetHeight_ShouldThrowArgumentOutOfRangeException_WhenHeightIsLessThanOrEqualToZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetHeight(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetHeight(-1));
        }

        [Fact]
        public void SetHeight_ShouldUpdateHeight_WhenHeightIsGreaterThanZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);
            decimal newHeight = 25;

            // Act
            product.SetHeight(newHeight);

            // Assert
            Assert.Equal(newHeight, product.GetHeight());
        }

        [Fact]
        public void SetWidth_ShouldThrowArgumentOutOfRangeException_WhenWidthIsLessThanOrEqualToZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWidth(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWidth(-1));
        }

        [Fact]
        public void SetWidth_ShouldUpdateWidth_WhenWidthIsGreaterThanZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);
            decimal newWidth = 18;

            // Act
            product.SetWidth(newWidth);

            // Assert
            Assert.Equal(newWidth, product.GetWidth());
        }

        [Fact]
        public void SetLenght_ShouldThrowArgumentOutOfRangeException_WhenLenghtIsLessThanOrEqualToZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetLenght(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetLenght(-1));
        }

        [Fact]
        public void SetLenght_ShouldUpdateLenght_WhenLenghtIsGreaterThanZero()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);
            decimal newLenght = 8;

            // Act
            product.SetLenght(newLenght);

            // Assert
            Assert.Equal(newLenght, product.GetLenght());
        }

        [Fact]
        public void CalculateTotalValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act
            decimal totalValue = product.CalculateTotalValue();

            // Assert
            Assert.Equal(95, totalValue);
        }

        [Fact]
        public void ShowInfo_ShouldReturnCorrectInfo()
        {
            // Arrange
            var dto = new GenericProductDTO()
            {
                Name = "Producto de Prueba",
                Description = "Descripción",
                GrossValue = 100,
                DiscPercentaje = 10,
                TaxPercentaje = 5,
                Stock = 50,
                FileFormat = "pdf",
                Size = 2.5f
            };
            PhysicalProduct product = new(dto);

            // Act
            string info = product.ShowInfo();

            // Assert
            Assert.Contains("Producto de Prueba", info);
        }
    }
}
