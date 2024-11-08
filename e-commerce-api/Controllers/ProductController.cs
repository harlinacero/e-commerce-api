using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;
using e_commerce_domain.repositories;
using e_commerce_domain.useCases;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ShoppingCarService _carService;

        public ProductController()
        {
            ProductRepository productRepository = new ProductRepository();
            Customer customer = new Customer();
            _carService = new ShoppingCarService(productRepository, customer);
        }

        [HttpGet]
        public string Product()
        {
            var digitalProduct = new DigitalProduct()
            {
                Id = Guid.Parse("c2cef007-cbee-4875-8e6b-69900326ffad"),
                Name = "libro.pdf"
            };

            var physicalProduct = new PhysicalProduct()
            {
                Id = Guid.Parse("7d31d594-7965-4bb2-a38f-de9716ceebd1"),
                Name = "libro.pdf"
            };

            
            // Sobre carga de métodos: el método AddProduct funciona para agregar productos por id o por nombre, además del objeto completo
            _carService.AddProduct(digitalProduct);
            _carService.AddProduct(physicalProduct);
            _carService.AddProduct(digitalProduct.Id);
            _carService.AddProduct(physicalProduct.Name);

            // Polimorfismo: trata todos los productos del carrito (digitales y físicos) como un producto base para permitir calcular su total
            
            _carService.CalculateTotalValue();

            return _carService.ShowInfoProducts();
        }
    }
}