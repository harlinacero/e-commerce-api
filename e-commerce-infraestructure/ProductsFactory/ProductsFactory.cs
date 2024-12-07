﻿using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;

namespace e_commerce_infraestructure.ProductsFactory
{
    public static class ProductsFactory
    {
        /// <summary>
        /// Crea un producto en base al tipo de producto y sus propiedades
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static ProductBase CreateProduct(ProductType productType, GenericProductDTO product)
        {
            return productType switch
            {
                ProductType.Digital => new DigitalProduct(
                                        product.Name,
                                        product.Description,
                                        product.GrossValue,
                                        product.DiscPercentaje,
                                        product.TaxPercentaje,
                                        product.Stock,
                                        product.FileFormat,
                                        product.Size),
                ProductType.Physical => new PhysicalProduct(
                                        product.Name,
                                        product.Description,
                                        product.GrossValue,
                                        product.DiscPercentaje,
                                        product.TaxPercentaje,
                                        product.Stock,
                                        product.Weight,
                                        product.Height,
                                        product.Width,
                                        product.Length,
                                        product.BaseShippingCost),
                _ => throw new NotSupportedException($"El tipo de producto {productType} no es soportado."),
            };
        }
    }
}