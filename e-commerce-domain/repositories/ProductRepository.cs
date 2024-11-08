using e_commerce_domain.entities.Product;

namespace e_commerce_domain.repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductBase> _products;

        public ProductRepository()
        {
            var digitalProduct = new DigitalProduct()
            {
                Id = Guid.Parse("c2cef007-cbee-4875-8e6b-69900326ffad"),
                Name = "libro.pdf",
                Description = "Libro sobre POO",
                GrossValue = 100,
                TaxPercentaje = 5,
                DiscPercentaje = 20,
                FileFormat = "PDF",
                Size = 300,
                Stock = 10
            };

            var physicalProduct = new PhysicalProduct()
            {
                Id = Guid.Parse("7d31d594-7965-4bb2-a38f-de9716ceebd1"),
                Name = "libro.pdf",
                Description = "Libro sobre POO",
                GrossValue = 100,
                TaxPercentaje = 5,
                DiscPercentaje = 20,
                Height = 25,
                Lenght = 5,
                Width = 14,
                Weight = 200,
                BaseShipingCost = 100,
                Stock = 10
            };

            _products = new List<ProductBase>()
            {
                digitalProduct,
                physicalProduct,
            };
        }
        public void AddProduct(ProductBase product)
        {
            _products.Add(product);
        }

        public IEnumerable<ProductBase> GetAll()
        {
            return _products;
        }

        public ProductBase GetProductById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public ProductBase GetProductByName(string name)
        {
            return _products.FirstOrDefault(p => p.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }

        public void RemoveProduct(Guid idProduct)
        {
            var product = GetProductById(idProduct);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
