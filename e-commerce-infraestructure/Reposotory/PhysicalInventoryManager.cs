using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;
using System.Collections.Generic;
using System;

namespace e_commerce_infraestructure.Reposotory
{
    /// <summary>
    /// Inventario de productos físicos
    /// </summary>
    public class PhysicalInventoryManager : InventoryManager
    {
        private readonly ICollection<PhysicalProduct> _productRepository;
        public PhysicalInventoryManager(List<IInventoryObserver> observers): base(observers)
        {
            _productRepository = new List<PhysicalProduct>();
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            for (int i = 1; i <= 10; i++)
            {
                PhysicalProduct product = new(
                    $"Product{i}",
                    $"Description for Product{i}",
                    100m + i, // grossValue
                    10m, // discPercentaje
                    15m, // taxPercentaje
                    50, // stock
                    1m * i, // weight
                    2m * i, // height
                    3m * i, // width
                    4m * i, // length
                    5m * i // baseShippingCost
                )
                {
                    Id = Guid.NewGuid()
                };
                _productRepository.Add(product);
            }
        }

        public override void AddProduct(ProductBase product)
        {
            PhysicalProduct physicalproduct = CreateProduct(product);
            _productRepository.Add(physicalproduct);
            NotifyProductAdded(product);
        }

        public override void DeleteProduct(Guid idProduct)
        {
            var product = _productRepository.FirstOrDefault(x => x.Id == idProduct);
            if (product == null)
            {
                throw new NullReferenceException($"El producto con id {idProduct} no existe");
            }

            _productRepository.Remove(product);
            Console.WriteLine($"El producto físico {product.GetName()} ha sido eliminado del inventario");
            NotifyProductDeleted(idProduct);
        }

        private PhysicalProduct CreateProduct(ProductBase product)
        {
            PhysicalProduct physicalproduct = new(product.GetName(), product.GetDescription(),
                product.GetGrossValue(), product.GetDisccounPercentaje(), product.GetTaxPercentaje(), product.GetStock(),
                30, 40, 10, 250, 10);
            physicalproduct.Id = product.Id;
            return physicalproduct;
        }


        public override void UpdateStock(Guid idStock, int stock)
        {
            var product = _productRepository.FirstOrDefault(p => p.Id == idStock);
            if (product == null)
            {
                throw new NullReferenceException($"El producto con id {idStock} no existe");
            }
            product.SetStock(stock);
            Console.WriteLine($"El stock del producto físico {product.GetName()} es {product.GetStock()}");
        }

        public override IEnumerable<ProductBase> GetAll()
        {
            return _productRepository;
        }

        public override ProductBase GetProductById(Guid id)
        {
            return _productRepository.FirstOrDefault(p => p.Id == id);
        }

        public override ProductBase GetProductByName(string name)
        {
            return _productRepository.FirstOrDefault(p => p.GetName().ToLowerInvariant() == name.ToLowerInvariant());
        }
    }
}
