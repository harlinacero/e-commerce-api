using e_commerce_domain.entities.Product;

namespace e_commerce_domain.useCases
{
    public class DigitalInventoryManager : InventoryManager
    {
        private readonly ICollection<DigitalProduct> _productRepository;

        public DigitalInventoryManager()
        {
            _productRepository = new List<DigitalProduct>();
        }

        public override void AddProduct(ProductBase product)
        {
            DigitalProduct digitalProduct = CreateProduct(product);
            _productRepository.Add(digitalProduct);
            Console.WriteLine($"El producto digital {product.GetName()} ha sido agregado al inventario");
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
            Console.WriteLine($"El producto digital {product.GetName()} ha sido eliminado del inventario");
            _productRepository.Remove(product);
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
    }
}
