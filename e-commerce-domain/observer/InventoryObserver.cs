using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;

namespace e_commerce_domain.observer
{
    public class InventoryObserver : IInventoryObserver
    {
        public void OnProductAdded(ProductBase product)
        {
            Console.WriteLine($"Producto agregado: {product.GetName()}");
        }

        public void OnProductUpdated(Guid productId, int newStock)
        {
            Console.WriteLine($"Producto actualizado: ID={productId}, Nuevo stock={newStock}");
        }

        public void OnProductDeleted(Guid productId)
        {
            Console.WriteLine($"Producto eliminado: ID={productId}");
        }
    }
}
