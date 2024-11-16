using e_commerce_domain.entities.Product;

namespace e_commerce_domain.useCases
{
    /// <summary>
    /// Inventario de productos físicos
    /// </summary>
    public class PhysicalInventoryManager : InventoryManager
    {
        private readonly ICollection<PhysicalProduct> _productRepository;

        public PhysicalInventoryManager()
        {
            _productRepository = new List<PhysicalProduct>();
        }

        public override void AddProduct(ProductBase product)
        {
            PhysicalProduct physicalproduct = CreateProduct(product);
            _productRepository.Add(physicalproduct);
            Console.WriteLine($"El producto físico {product.GetName()} ha sido agregado al inventario");
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
    }
}
