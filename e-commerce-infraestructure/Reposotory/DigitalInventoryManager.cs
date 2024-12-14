using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;

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
            for (int i = 1; i <= 10; i++)
            {
                DigitalProduct product = new DigitalProduct(
                    $"DigitalProduct{i}",
                    $"Description for DigitalProduct{i}",
                    50m + i, // grossValue
                    5m, // discPercentaje
                    10m, // taxPercentaje
                    100, // stock
                    $"Format{i}", // fileFormat
                    1.5f * i // size
                );
                product.Id = Guid.NewGuid();
                _productRepository.Add(product);
            }
        }

        public override void AddProduct(ProductBase product)
        {
            DigitalProduct digitalProduct = CreateProduct(product);
            _productRepository.Add(digitalProduct);
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
            NotifyProductDeleted(idProduct);
        }

        private DigitalProduct CreateProduct(ProductBase product)
        {
            DigitalProduct digitalProduct = new(product.GetName(), product.GetDescription(),
                product.GetGrossValue(), product.GetDisccounPercentaje(), product.GetTaxPercentaje(), product.GetStock(), "", 0);
            digitalProduct.Id = product.Id;
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
