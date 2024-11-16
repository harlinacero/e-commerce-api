using e_commerce_domain.entities.Product;

namespace e_commerce_domain.useCases
{
    /// <summary>
    /// Inventario de productos
    /// </summary>
    public abstract class InventoryManager
    {
        protected InventoryManager() { }

        public abstract void AddProduct(ProductBase product);
        public abstract void DeleteProduct(Guid idProduct);
        public abstract void UpdateStock(Guid idStock, int stock);
    }
}
