using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;

namespace e_commerce_domain.repositories
{
    public interface IInventoryManager
    {
        void AddObserver(IInventoryObserver observer);
        void AddProduct(ProductBase product);
        void DeleteProduct(Guid idProduct);
        IEnumerable<ProductBase> GetAll();
        ProductBase GetProductById(Guid id);
        ProductBase GetProductByName(string name);
        void RemoveObserver(IInventoryObserver observer);
        void UpdateStock(Guid idStock, int stock);
    }
}