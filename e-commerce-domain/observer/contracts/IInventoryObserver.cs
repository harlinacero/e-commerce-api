using e_commerce_domain.entities.Product;

namespace e_commerce_domain.observer.contracts
{
    public interface IInventoryObserver
    {
        void OnProductAdded(ProductBase product);
        void OnProductUpdated(Guid productId, int newStock);
        void OnProductDeleted(Guid productId);
    }
}
