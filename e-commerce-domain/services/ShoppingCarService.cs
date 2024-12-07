﻿using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.ShoppingCar;
using e_commerce_domain.entities.User;
using e_commerce_domain.repositories;
using e_commerce_domain.services.Contracts;
using System.Text;

namespace e_commerce_domain.useCases
{
    /// <summary>
    /// Administra el carrito de compras de un usuario
    /// </summary>
    public class ShoppingCarService : IShoppingCarService
    {
        private readonly ShoppingCar _shoppingCar;
        private readonly InventoryManager _productRepository;

        public ShoppingCarService(InventoryManager productRepository, Customer customer)
        {
            _productRepository = productRepository;

            _shoppingCar = new ShoppingCar()
            {
                Customer = customer,
                Products = new List<ProductBase>()
            };

        }

        /// <summary>
        /// Agrega un producto del inventario al carrito de compras
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddProduct(ProductBase product)
        {
            var oproduct = _productRepository.GetProductById(product.Id);
            if (oproduct == null)
            {
                throw new ArgumentNullException($"El producto {product.GetName} no existe en el inventario");
            }
            _shoppingCar.Products.Add(oproduct);
        }

        /// <summary>
        /// Agrega un producto del Inventario al carrito de compras a partir de su id
        /// </summary>
        /// <param name="idProduct"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddProduct(Guid idProduct)
        {
            var oproduct = _productRepository.GetProductById(idProduct);
            if (oproduct == null)
            {
                throw new ArgumentNullException($"El producto con id {idProduct} no existe en el inventario");
            }
            _shoppingCar.Products.Add(oproduct);

        }

        /// <summary>
        /// Agrega un producto del Inventario al carrito de compras a partir de su nombre en el inventario
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddProduct(string name)
        {
            var oproduct = _productRepository.GetProductByName(name);
            if (oproduct == null)
            {
                throw new ArgumentNullException($"El producto {name} no existe en el inventario");
            }
            _shoppingCar.Products.Add(oproduct);

        }

        /// <summary>
        /// Elimina un producto del carrito de compras a partir de su id en el inventario
        /// </summary>
        /// <param name="idProduct"></param>
        public void RemoveProduct(Guid idProduct)
        {
            var oproduct = _shoppingCar.Products.FirstOrDefault(p => p.Id == idProduct);
            if (oproduct == null)
            {
                throw new ArgumentNullException($"El producto con id {idProduct} no existe en el inventario");
            }
            _shoppingCar.Products.Remove(oproduct);
        }

        /// <summary>
        /// Elimina un producto del carrito de compras a partir de su nombre en el inventario
        /// </summary>
        /// <param name="name"></param>
        public void RemoveProduct(string name)
        {
            var oproduct = _shoppingCar.Products.FirstOrDefault(p => p.GetName().ToLowerInvariant() == name.ToLowerInvariant());
            if (oproduct == null)
            {
                throw new ArgumentNullException($"El producto {name} no existe en el inventario");
            }
            _shoppingCar.Products.Remove(oproduct);


        }


        public decimal CalculateTotalValue()
        {
            decimal total = 0;

            foreach (var product in _shoppingCar.Products)
            {
                total += product.CalculateTotalValue();
            }

            return total;
        }

        public string ShowInfoProducts()
        {
            StringBuilder stringBuilder = new();

            foreach (var product in _shoppingCar.Products)
            {
                stringBuilder.AppendLine(product.ShowInfo());
            }

            return stringBuilder.ToString();
        }
    }
}
