using e_commerce_domain.entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_domain.repositories
{
    /// <summary>
    /// Contrato para el repositorio de los productos
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Agrega un producto al repositorio
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(ProductBase product);
        /// <summary>
        /// Elimina un productor del repositorio
        /// </summary>
        /// <param name="idProduct"></param>
        void RemoveProduct(Guid idProduct);
        /// <summary>
        /// Obtiene un producto del repositorio por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductBase GetProductById(Guid id);
        /// <summary>
        /// Obtiene un producto del repositorio por su 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ProductBase GetProductByName(string name);
        /// <summary>
        /// Obtiene todos los productos del repositorio
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductBase> GetAll();
    }
}
