using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;

namespace e_commerce_domain.repositories
{
    /// <summary>
    /// Inventario de productos
    /// </summary>
    public abstract class InventoryManager
    {
        protected readonly List<IInventoryObserver> _observers;
        protected InventoryManager()
        {
            _observers = new List<IInventoryObserver>();
        }
        public abstract void AddProduct(ProductBase product);
        public abstract void DeleteProduct(Guid idProduct);
        public abstract void UpdateStock(Guid idStock, int stock);
        /// <summary>
        /// Obtiene un producto del repositorio por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract ProductBase GetProductById(Guid id);
        /// <summary>
        /// Obtiene un producto del repositorio por su 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public abstract ProductBase GetProductByName(string name);
        /// <summary>
        /// Obtiene todos los productos del repositorio
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<ProductBase> GetAll();


        public void AddObserver(IInventoryObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IInventoryObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyProductAdded(ProductBase product)
        {
            foreach (var observer in _observers)
            {
                observer.OnProductAdded(product);
            }
        }

        protected void NotifyProductUpdated(Guid productId, int newStock)
        {
            foreach (var observer in _observers)
            {
                observer.OnProductUpdated(productId, newStock);
            }
        }

        protected void NotifyProductDeleted(Guid productId)
        {
            foreach (var observer in _observers)
            {
                observer.OnProductDeleted(productId);
            }
        }
    }
}
