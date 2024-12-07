using e_commerce_domain.enums;
using e_commerce_domain.observer;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.Reposotory;

namespace e_commerce_infraestructure.ProductsFactory
{
    public static class InventoryManagerFactory
    {
        public static InventoryManager CreateInventoryManagerFactory(ProductType productType)
        {
            InventoryManager inventoryManager = productType switch
            {
                ProductType.Physical => PhysicalInventoryManager.GetInstance(),
                ProductType.Digital => DigitalInventoryManager.GetInstance(),
                _ => throw new System.NotSupportedException("El tipo de producto no es soportado."),
            };
            inventoryManager.AddObserver(new InventoryObserver());
            return inventoryManager;
        }
    }
}
