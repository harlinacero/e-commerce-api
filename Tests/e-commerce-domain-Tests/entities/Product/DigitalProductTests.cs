using e_commerce_domain.entities.Product;

namespace e_commerce_domain_Tests.entities.Product
{
    public class DigitalProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string name = "Libro Digital";
            string description = "Un libro en formato digital";
            decimal grossValue = 100;
            decimal discPercentaje = 10;
            decimal taxPercentaje = 5;
            int stock = 50;
            string fileFormat = "pdf";
            float size = 2.5f;

            // Act
            DigitalProduct product = new(name, description, grossValue, discPercentaje, taxPercentaje, stock, fileFormat, size);

            // Assert
            Assert.Equal(name, product.GetName());
            Assert.Equal(description, product.GetDescription());
            Assert.Equal(grossValue, product.GetGrossValue());
            Assert.Equal(discPercentaje, product.GetDisccounPercentaje());
            Assert.Equal(taxPercentaje, product.GetTaxPercentaje());
            Assert.Equal(stock, product.GetStock());
            Assert.Equal(fileFormat, product.GetFileFormat());
            Assert.Equal(size, product.GetSize());
        }

        [Fact]
        public void SetFileFormat_ShouldThrowArgumentNullException_WhenFileFormatIsNullOrEmpty()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.SetFileFormtat(null));
            Assert.Throws<ArgumentNullException>(() => product.SetFileFormtat(string.Empty));
        }

        [Fact]
        public void SetFileFormat_ShouldThrowInvalidDataException_WhenFileFormatIsInvalid()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => product.SetFileFormtat("invalidFormat"));
        }

        [Fact]
        public void SetFileFormat_ShouldUpdateFileFormat_WhenFileFormatIsValid()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);
            string newFileFormat = "epub";

            // Act
            product.SetFileFormtat(newFileFormat);

            // Assert
            Assert.Equal(newFileFormat, product.GetFileFormat());
        }

        [Fact]
        public void SetSize_ShouldThrowArgumentOutOfRangeException_WhenSizeIsLessThanOrEqualToZero()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetSize(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetSize(-1));
        }

        [Fact]
        public void SetSize_ShouldUpdateSize_WhenSizeIsGreaterThanZero()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);
            float newSize = 5.0f;

            // Act
            product.SetSize(newSize);

            // Assert
            Assert.Equal(newSize, product.GetSize());
        }

        [Fact]
        public void CalculateTotalValue_ShouldReturnCorrectValue()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);

            // Act
            decimal totalValue = product.CalculateTotalValue();

            // Assert
            Assert.Equal(95, totalValue);
        }

        [Fact]
        public void ShowInfo_ShouldReturnCorrectInfo()
        {
            // Arrange
            DigitalProduct product = new("Libro Digital", "Un libro en formato digital", 100, 10, 5, 50, "pdf", 2.5f);

            // Act
            string info = product.ShowInfo();

            // Assert
            Assert.Contains("Libro Digital", info);
            Assert.Contains("2,5MB", info);
            Assert.Contains("pdf", info);
            Assert.Contains("95", info);
        }
    }
}
