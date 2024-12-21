namespace e_commerce_domain.observer.contracts
{
    public interface InventoryObserbable
    {
        void AddObserver(IInventoryObserver observer);
        void RemoveObserver(IInventoryObserver observer);
        void UpdateStock(Guid idStock, int stock);
    }
}
