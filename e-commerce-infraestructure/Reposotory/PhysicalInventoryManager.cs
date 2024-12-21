using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;
using System.Collections.Generic;
using System;
using e_commerce_domain.DTO;
using e_commerce_domain.enums;

namespace e_commerce_infraestructure.Reposotory
{
    /// <summary>
    /// Inventario de productos físicos
    /// </summary>
    public class PhysicalInventoryManager : InventoryManager
    {
        private readonly ICollection<PhysicalProduct> _productRepository = new List<PhysicalProduct>();
        public PhysicalInventoryManager(List<IInventoryObserver> observers) : base(observers)
        {
            _productRepository = InitializeProducts();
            InitializeProducts();
        }

        private List<PhysicalProduct> InitializeProducts()
        {

            PhysicalProduct product1 = new(new GenericProductDTO()
            {
                Name = $"Carro de Jugete",
                Description = $"Descripción carro",
                GrossValue = 1000,
                DiscPercentaje = (decimal)(0.1),
                TaxPercentaje = (decimal)(0.19),
                Stock = 10,
                Height = 30,
                Width = 40,
                Weight = 250,
                ProductType = ProductType.Physical
            });

            PhysicalProduct product2 = new(new GenericProductDTO()
            {
                Name = $"Camara fotográfica",
                Description = $"Descripción cámara fotografica",
                GrossValue = 1300,
                DiscPercentaje = (decimal)(0.1),
                TaxPercentaje = (decimal)(0.19),
                Stock = 10,
                Height = 20,
                Width = 140,
                Weight = 250,
                ProductType = ProductType.Physical
            });
            product1.Id = new Guid("36b70aab-ab6b-4327-a4b4-9e2803d416e7");
            product2.Id = new Guid("2d010636-9c42-495e-8597-993f3f5d0efe");

            _productRepository.Add(product1);
            _productRepository.Add(product2);

            return _productRepository.ToList();
        }

        public override void AddProduct(GenericProductDTO product)
        {
            PhysicalProduct physicalproduct = CreateProduct(product);

            _productRepository.Add(physicalproduct);
            NotifyProductAdded(physicalproduct);
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

        private PhysicalProduct CreateProduct(GenericProductDTO product)
        {
            PhysicalProduct physicalproduct = new(product);
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

        public override IEnumerable<GenericProductDTO> GetAll()
        {
            List<GenericProductDTO> products = new();
            foreach (var product in _productRepository)
            {
                products.Add(new GenericProductDTO()
                {
                    Id = product.Id,
                    Name = product.GetName(),
                    Description = product.GetDescription(),
                    GrossValue = product.GetGrossValue(),
                    DiscPercentaje = product.GetDisccounPercentaje(),
                    TaxPercentaje = product.GetTaxPercentaje(),
                    Stock = product.GetStock(),
                    Height = product.GetHeight(),
                    Width = product.GetWidth(),
                    Weight = product.GetWeight(),
                    Length = product.GetLenght(),
                    ProductType = ProductType.Physical
                });
            }

            return products;
        }

        public override GenericProductDTO GetProductById(Guid id)
        {
            var product = _productRepository.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NullReferenceException($"El producto con id {id} no existe");
            }

            return new GenericProductDTO()
            {
                Id = product.Id,
                Name = product.GetName(),
                Description = product.GetDescription(),
                GrossValue = product.GetGrossValue(),
                DiscPercentaje = product.GetDisccounPercentaje(),
                TaxPercentaje = product.GetTaxPercentaje(),
                Stock = product.GetStock(),
                Height = product.GetHeight(),
                Width = product.GetWidth(),
                Weight = product.GetWeight(),
                Length = product.GetLenght(),
                ProductType = ProductType.Physical
            };
        }

        public override GenericProductDTO GetProductByName(string name)
        {
            var product = _productRepository.FirstOrDefault(p => p.GetName().ToLowerInvariant() == name.ToLowerInvariant());
            if (product == null)
            {
                throw new NullReferenceException($"El producto con nombre {name} no existe");
            }

            return new GenericProductDTO()
            {
                Id = product.Id,
                Name = product.GetName(),
                Description = product.GetDescription(),
                GrossValue = product.GetGrossValue(),
                DiscPercentaje = product.GetDisccounPercentaje(),
                TaxPercentaje = product.GetTaxPercentaje(),
                Stock = product.GetStock(),
                Height = product.GetHeight(),
                Width = product.GetWidth(),
                Weight = product.GetWeight(),
                Length = product.GetLenght(),
                ProductType = ProductType.Physical
            };
        }
    }
}
