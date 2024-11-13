using e_commerce_domain.entities.Product;

namespace e_commerce_domain.repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductBase> _products;

        public ProductRepository(List<ProductBase> products)
        {
            _products = products;
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
            return _products.FirstOrDefault(p => p.GetName().ToLowerInvariant() == name.ToLowerInvariant());
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
