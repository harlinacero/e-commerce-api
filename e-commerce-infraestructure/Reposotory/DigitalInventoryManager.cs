using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;
using e_commerce_domain.observer.contracts;

namespace e_commerce_infraestructure.Reposotory
{
    public class DigitalInventoryManager : InventoryManager
    {
        private readonly ICollection<DigitalProduct> _productRepository;
        public DigitalInventoryManager(List<IInventoryObserver> observers) : base(observers)
        {
            _productRepository = new List<DigitalProduct>();
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            DigitalProduct product1 = new(new GenericProductDTO()
            {
                Name = "Libro",
                Description = "Libro",
                GrossValue = 1000,
                DiscPercentaje = (decimal)(0.1),
                TaxPercentaje = (decimal)(0.19),
                Stock = 10,
                FileFormat = "PDF",
                Size = 10,
                ProductType = ProductType.Digital
            });

            DigitalProduct product2 = new(new GenericProductDTO()
            {
                Name = "Windows",
                Description = "Windows",
                GrossValue = 5000,
                DiscPercentaje = (decimal)(0.1),
                TaxPercentaje = (decimal)(0.19),
                Stock = 7,
                FileFormat = "exe",
                Size = 30,
                ProductType = ProductType.Digital
            });

            DigitalProduct product3 = new(new GenericProductDTO()
            {
                Name = "Office",
                Description = "Office",
                GrossValue = 3000,
                DiscPercentaje = (decimal)(0.1),
                TaxPercentaje = (decimal)(0.19),
                Stock = 5,
                FileFormat = "exe",
                Size = 20,
                ProductType = ProductType.Digital
            });

            product1.Id = new Guid("ba7520ce-c31e-432f-bdf3-4d1aac9251fa");
            product2.Id = new Guid("138981da-0c62-44ac-87ee-e12a827bd294");
            product3.Id = new Guid("54d3f89f-62ff-4a93-9390-d49dae493a26");

            _productRepository.Add(product1);
            _productRepository.Add(product2);
            _productRepository.Add(product3);
        }

        public override void AddProduct(GenericProductDTO product)
        {
            DigitalProduct digitalProduct = CreateProduct(product);
            _productRepository.Add(digitalProduct);

            NotifyProductAdded(digitalProduct);
        }
        public override void DeleteProduct(Guid idProduct)
        {
            var product = _productRepository.FirstOrDefault(x => x.Id == idProduct);
            if (product == null)
            {
                throw new NullReferenceException($"El producto con id {idProduct} no existe");
            }
            _productRepository.Remove(product);
            NotifyProductDeleted(idProduct);
        }

        private DigitalProduct CreateProduct(GenericProductDTO product)
        {
            DigitalProduct digitalProduct = new(product);
            return digitalProduct;
        }


        public override void UpdateStock(Guid idStock, int stock)
        {
            var product = _productRepository.FirstOrDefault(p => p.Id == idStock);
            if (product == null)
            {
                throw new NullReferenceException($"El producto con id {idStock} no existe");
            }

            product.SetStock(stock);
            Console.WriteLine($"El nuevo stock del producto digital {product.GetName()} es de {product.GetStock()}");
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
                    FileFormat = product.GetFileFormat(),
                    Size = product.GetSize(),
                    ProductType = ProductType.Digital
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
                FileFormat = product.GetFileFormat(),
                Size = product.GetSize(),
                ProductType = ProductType.Digital
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
                FileFormat = product.GetFileFormat(),
                Size = product.GetSize(),
                ProductType = ProductType.Digital
            };
        }
    }
}
