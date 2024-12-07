using e_commerce_domain.entities.Product;
using e_commerce_domain.repositories;

namespace e_commerce_infraestructure.Reposotory
{
    /// <summary>
    /// Inventario de productos físicos
    /// </summary>
    public class PhysicalInventoryManager : InventoryManager
    {
        private readonly ICollection<PhysicalProduct> _productRepository;
        public static PhysicalInventoryManager _instance;
        private PhysicalInventoryManager()
        {
            _productRepository = new List<PhysicalProduct>();
        }

        public static PhysicalInventoryManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PhysicalInventoryManager();
            }
            return _instance;
        }


        public override void AddProduct(ProductBase product)
        {
            PhysicalProduct physicalproduct = CreateProduct(product);
            _productRepository.Add(physicalproduct);
            NotifyProductAdded(product);
        }

        private PhysicalProduct CreateProduct(ProductBase product)
        {
            PhysicalProduct physicalproduct = new(product.GetName(), product.GetDescription(),
                product.GetGrossValue(), product.GetDisccounPercentaje(), product.GetTaxPercentaje(), product.GetStock(),
                30, 40, 10, 250, 10);
            physicalproduct.Id = product.Id;
            return physicalproduct;
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
