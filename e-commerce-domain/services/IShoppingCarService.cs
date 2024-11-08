using e_commerce_domain.entities.Product;

namespace e_commerce_domain.useCases
{
    public interface IShoppingCarService
    {
        /// <summary>
        /// Agrega un producto al carrito  a partir de su id
        /// </summary>
        /// <param name="idProduct"></param>
        void AddProduct(Guid idProduct);
        /// <summary>
        /// Agrega un producto al carrito
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(ProductBase product);
        /// <summary>
        /// Agrega un producto al carrito a partir de su nombre
        /// </summary>
        /// <param name="name"></param>
        void AddProduct(string name);
        /// <summary>
        /// Calcula el valor total de los productos del carrito
        /// </summary>
        /// <returns></returns>
        decimal CalculateTotalValue();
        /// <summary>
        /// Eliminar un product del carrito a partir de su id
        /// </summary>
        /// <param name="idProduct"></param>
        void RemoveProduct(Guid idProduct);
        /// <summary>
        /// Elimina un producti del carrito a partir de su nombre
        /// </summary>
        /// <param name="name"></param>
        void RemoveProduct(string name);
        /// <summary>
        /// Muestra la información de los productos del carrito
        /// </summary>
        /// <returns></returns>
        string ShowInfoProducts();
    }
}