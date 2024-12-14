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

            // Act
            PhysicalProduct product = new(name, description, grossValue, discPercentaje, taxPercentaje, stock, weight, height, width, lenght, baseShipingCost);

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
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWeight(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWeight(-1));
        }

        [Fact]
        public void SetWeight_ShouldUpdateWeight_WhenWeightIsGreaterThanZero()
        {
            // Arrange
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);
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
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetHeight(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetHeight(-1));
        }

        [Fact]
        public void SetHeight_ShouldUpdateHeight_WhenHeightIsGreaterThanZero()
        {
            // Arrange
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);
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
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWidth(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetWidth(-1));
        }

        [Fact]
        public void SetWidth_ShouldUpdateWidth_WhenWidthIsGreaterThanZero()
        {
            // Arrange
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);
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
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetLenght(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetLenght(-1));
        }

        [Fact]
        public void SetLenght_ShouldUpdateLenght_WhenLenghtIsGreaterThanZero()
        {
            // Arrange
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);
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
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act
            decimal totalValue = product.CalculateTotalValue();

            // Assert
            Assert.Equal(100 + 5 - 10 + 10 * (20 * 15 * 5), totalValue);
        }

        [Fact]
        public void ShowInfo_ShouldReturnCorrectInfo()
        {
            // Arrange
            PhysicalProduct product = new("Libro Físico", "Un libro en formato físico", 100, 10, 5, 50, 1.5m, 20, 15, 5, 10);

            // Act
            string info = product.ShowInfo();

            // Assert
            Assert.Contains("Libro Físico", info);
            Assert.Contains("1,5 Kg", info);
            Assert.Contains("20 x 15 + 5 cm", info);
            Assert.Contains((100 + 5 - 10 + 10 * (20 * 15 * 5)).ToString(), info);
        }
    }
}
