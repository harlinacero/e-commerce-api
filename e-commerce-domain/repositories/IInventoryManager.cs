using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.observer.contracts;

namespace e_commerce_domain.repositories
{
    public interface IInventoryManager : InventoryObserbable
    {
        void AddProduct(GenericProductDTO product);
        void DeleteProduct(Guid idProduct);
        IEnumerable<GenericProductDTO> GetAll();
        GenericProductDTO GetProductById(Guid id);
        GenericProductDTO GetProductByName(string name);
        
    }
}