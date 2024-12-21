using e_commerce_domain.DTO;
using e_commerce_domain.entities.Product;
using e_commerce_domain.enums;
using e_commerce_domain.observer;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.repositories;
using e_commerce_infraestructure.ProductsFactory;
using e_commerce_infraestructure.Reposotory;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IInventoryManager _physicalInventoryManager;
        private readonly IInventoryManager _digitalInventoryManager;
        public ProductController()
        {
            var observers = new List<IInventoryObserver>();
            _physicalInventoryManager = new PhysicalInventoryManager(observers);
            _digitalInventoryManager = new DigitalInventoryManager(observers);
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            List<GenericProductDTO> productsDTO = new List<GenericProductDTO>();


            var physicalProducts = _physicalInventoryManager.GetAll();
            var digitalProducts = _digitalInventoryManager.GetAll();

            productsDTO.AddRange(physicalProducts);
            productsDTO.AddRange(digitalProducts);

            return Ok(productsDTO);
        }

        /// <summary>
        /// Obtiene un producto en base a su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetProductById(Guid id, ProductType productType)
        {
            IInventoryManager _productRepository = GetInventoryManager(productType);

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
                var repository = GetInventoryManager(product.ProductType);
                repository.AddProduct(product);
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
            var repository = GetInventoryManager(product.ProductType);
            var existingProduct = repository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            try
            {
                var updatedProduct = ProductsFactory.CreateProduct(productType, product);
                repository.DeleteProduct(id);
                repository.AddProduct(product);
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
            var repository = GetInventoryManager(productType);
            var existingProduct = repository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            repository.DeleteProduct(id);
            return NoContent();
        }


        private IInventoryManager GetInventoryManager(ProductType productType)
        {
            return productType switch
            {
                ProductType.Physical => _physicalInventoryManager,
                ProductType.Digital => _digitalInventoryManager,
                _ => throw new NotSupportedException($"El tipo de producto {productType} no existe"),
            };
        }
    }
}