using e_commerce_domain.entities.Product;
using e_commerce_domain.repositories;

namespace e_commerce_infraestructure.Reposotory
{
    public class DigitalInventoryManager : InventoryManager
    {
        private readonly ICollection<DigitalProduct> _productRepository;
        public static DigitalInventoryManager _instance;
        private DigitalInventoryManager()
        {
            _productRepository = new List<DigitalProduct>();
        }

        public static DigitalInventoryManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DigitalInventoryManager();
            }
            return _instance;
        }

        public override void AddProduct(ProductBase product)
        {
            DigitalProduct digitalProduct = CreateProduct(product);
            _productRepository.Add(digitalProduct);
            NotifyProductAdded(product);
        }

        private DigitalProduct CreateProduct(ProductBase product)
        {
            DigitalProduct digitalProduct = new(product.GetName(), product.GetDescription(),
                product.GetGrossValue(), product.GetDisccounPercentaje(), product.GetTaxPercentaje(), product.GetStock(), "", 0);
            digitalProduct.Id = product.Id;
            return digitalProduct;
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
