using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.ProductsFactory;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        public ProductController()
        {
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductBase> GetAllProducts()
        {
            IEnumerable<ProductBase> products = new List<ProductBase>();
            var physicalProducts = InventoryManagerFactory.CreateInventoryManagerFactory(ProductType.Physical).GetAll();
            var digitalProducts = InventoryManagerFactory.CreateInventoryManagerFactory(ProductType.Digital).GetAll();

            products = products.Concat(physicalProducts).Concat(digitalProducts);

            return products;
        }

        /// <summary>
        /// Obtiene un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetProductById(Guid id, ProductType productType)
        {
            InventoryManager _productRepository = InventoryManagerFactory.CreateInventoryManagerFactory(productType);
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        /// <summary>
        /// Crea un producto en base a las propiedades recibidas
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateProduct([FromBody] GenericProductDTO product)
        {
            try
            {
                var newproduct = ProductsFactory.CreateProduct(product.ProductType, product);
                var repository = InventoryManagerFactory.CreateInventoryManagerFactory(product.ProductType);
                repository.AddProduct(newproduct);
                return CreatedAtAction(nameof(GetProductById), new { id = newproduct.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un producto en base a las propiedades recibidas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Guid id, [FromBody] GenericProductDTO product, ProductType productType)
        {
            var repository = InventoryManagerFactory.CreateInventoryManagerFactory(productType);
            var existingProduct = repository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            try
            {
                var updatedProduct = ProductsFactory.CreateProduct(productType, product);
                repository.DeleteProduct(id);
                repository.AddProduct(updatedProduct);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id, ProductType productType)
        {
            var repository = InventoryManagerFactory.CreateInventoryManagerFactory(productType);
            var existingProduct = repository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            repository.DeleteProduct(id);
            return NoContent();
        }
    }
}