﻿using e_commerce_domain.entities.Product;

namespace e_commerce_domain_Tests.entities.Product
{
    public class ProductBaseTests
    {
        private class TestProduct : ProductBase
        {
            public TestProduct(string name, string description, decimal grossValue, decimal discPercentaje, decimal taxPercentaje, int stock)
                : base(name, description, grossValue, discPercentaje, taxPercentaje, stock)
            {
            }

            public override decimal CalculateTotalValue()
            {
                return GetGrossValue() + (GetGrossValue() * GetTaxPercentaje() / 100) - (GetGrossValue() * GetDisccounPercentaje() / 100);
            }

            public override string ShowInfo()
            {
                return $"Producto: {GetName()}, Descripción: {GetDescription()}, Precio: {CalculateTotalValue()}";
            }
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string name = "Producto de Prueba";
            string description = "Descripción del producto de prueba";
            decimal grossValue = 100;
            decimal discPercentaje = 10;
            decimal taxPercentaje = 5;
            int stock = 50;

            // Act
            TestProduct product = new(name, description, grossValue, discPercentaje, taxPercentaje, stock);

            // Assert
            Assert.Equal(name, product.GetName());
            Assert.Equal(description, product.GetDescription());
            Assert.Equal(grossValue, product.GetGrossValue());
            Assert.Equal(discPercentaje, product.GetDisccounPercentaje());
            Assert.Equal(taxPercentaje, product.GetTaxPercentaje());
            Assert.Equal(stock, product.GetStock());
        }

        [Fact]
        public void SetName_ShouldThrowArgumentOutOfRangeException_WhenNameIsInvalid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetName("abc"));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetName(new string('a', 21)));
        }

        [Fact]
        public void SetName_ShouldUpdateName_WhenNameIsValid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            string newName = "Nuevo Nombre";

            // Act
            product.SetName(newName);

            // Assert
            Assert.Equal(newName, product.GetName());
        }

        [Fact]
        public void SetGrossValue_ShouldThrowArgumentOutOfRangeException_WhenGrossValueIsLessThanOrEqualToZero()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetGrossValue(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetGrossValue(-1));
        }

        [Fact]
        public void SetGrossValue_ShouldUpdateGrossValue_WhenGrossValueIsGreaterThanZero()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            decimal newGrossValue = 200;

            // Act
            product.SetGrossValue(newGrossValue);

            // Assert
            Assert.Equal(newGrossValue, product.GetGrossValue());
        }

        [Fact]
        public void SetTaxPercentaje_ShouldThrowArgumentOutOfRangeException_WhenTaxPercentajeIsInvalid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetTaxPercentaje(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetTaxPercentaje(101));
        }

        [Fact]
        public void SetTaxPercentaje_ShouldUpdateTaxPercentaje_WhenTaxPercentajeIsValid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            decimal newTaxPercentaje = 15;

            // Act
            product.SetTaxPercentaje(newTaxPercentaje);

            // Assert
            Assert.Equal(newTaxPercentaje, product.GetTaxPercentaje());
        }

        [Fact]
        public void SetDisccountPercentaje_ShouldThrowArgumentOutOfRangeException_WhenDisccountPercentajeIsInvalid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetDisccountPercentaje(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetDisccountPercentaje(101));
        }

        [Fact]
        public void SetDisccountPercentaje_ShouldUpdateDisccountPercentaje_WhenDisccountPercentajeIsValid()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            decimal newDisccountPercentaje = 20;

            // Act
            product.SetDisccountPercentaje(newDisccountPercentaje);

            // Assert
            Assert.Equal(newDisccountPercentaje, product.GetDisccounPercentaje());
        }

        [Fact]
        public void SetStock_ShouldThrowArgumentOutOfRangeException_WhenStockIsLessThanZero()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.SetStock(-1));
        }

        [Fact]
        public void SetStock_ShouldUpdateStock_WhenStockIsGreaterThanOrEqualToZero()
        {
            // Arrange
            TestProduct product = new("Producto de Prueba", "Descripción", 100, 10, 5, 50);
            int newStock = 100;

            // Act
            product.SetStock(newStock);

            // Assert
            Assert.Equal(newStock, product.GetStock());
        }
    }
}