using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;
using e_commerce_domain.observer;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.Reposotory;

namespace e_commerce_infraestructure.ProductsFactory
{
    public class InventoryManagerFactory
    {
        private readonly ProductType _productType;
        public InventoryManagerFactory(ProductType productType) {
            _productType = productType;
        }
        public virtual IInventoryManager CreateInventoryManagerFactory()
        {
            IInventoryManager inventoryManager = _productType switch
            {
                ProductType.Physical => new PhysicalInventoryManager(new List<IInventoryObserver>()),
                ProductType.Digital => new DigitalInventoryManager(new List<IInventoryObserver>()),
                _ => throw new System.NotSupportedException("El tipo de producto no es soportado."),
            };
            inventoryManager.AddObserver(new InventoryObserver());
            return inventoryManager;
        }
    }
}
