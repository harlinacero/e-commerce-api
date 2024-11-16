using e_commerce_domain.entities.Order;
using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;
using e_commerce_domain.enums;
using e_commerce_domain.repositories;
using e_commerce_domain.services.PayFactory;
using e_commerce_domain.useCases;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ShoppingCarService _carService;
        private readonly DigitalProduct digitalProduct;
        private readonly PhysicalProduct physicalProduct;
        private readonly Customer customer;
        private readonly Order order;
        public ProductController()
        {
            customer = new Customer("Harlin", "harlina@mail.com", "harlin123", "harlin", "acero", "av123");

            digitalProduct = new DigitalProduct("libro.pdf", "Libro digital", 300, 20, 10, 10, "PDF", 200)
            {
                Id = Guid.Parse("c2cef007-cbee-4875-8e6b-69900326ffad")
            };

            physicalProduct = new PhysicalProduct("libro", "Libro pasta dura", 300, 20, 10, 10, 150, 20, 35, 3, 50)
            {
                Id = Guid.Parse("7d31d594-7965-4bb2-a38f-de9716ceebd1")
            };


            ProductRepository productRepository = new(new List<ProductBase>() { digitalProduct, physicalProduct });
            order = new()
            {
                Products = new List<ProductBase>()
                {
                    digitalProduct,
                    physicalProduct,
                },
                Customer = customer,
                Date = new DateTime()
            };

            _carService = new ShoppingCarService(productRepository, customer);
        }

        [HttpGet]
        public string Product()
        {


            // Sobre carga de métodos: el método AddProduct funciona para agregar productos por id o por nombre, además del objeto completo
            _carService.AddProduct(digitalProduct);
            _carService.AddProduct(physicalProduct);


            // Polimorfismo: trata todos los productos del carrito (digitales y físicos) como un producto base para permitir calcular su total

            _carService.CalculateTotalValue();

            return _carService.ShowInfoProducts();
        }

        /// <summary>
        /// Ejemplo de modificación del formato del producto digital con validación
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        [HttpGet("UpdateFormatProduct")]
        public ActionResult UpdateProductFormat(string format)
        {
            digitalProduct.SetFileFormtat(format);
            return Ok($"El formato del producto digital {digitalProduct.GetName()} ha sido cambiado {digitalProduct.GetFileFormat()}");
        }

        [HttpGet("PayOrderWithCreditCar")]
        public ActionResult PayOrderWithCreditCard(MethodPay methodPay)
        {
            PrepareOrder();
            IPayProcess creditCarPay = PayProcessFactory.Create(methodPay, order);
            creditCarPay.BeginPayProcess();
            if (creditCarPay.IsPayProcessAvailable())
            {
                creditCarPay.ConfirmPay();
                return Ok($"El pago fue realizado correctamente");
            }

            return BadRequest($"El pago con tarjeta de crédito de la orden {order.Id} no pudo ser procesado");
        }

        private void PrepareOrder()
        {
            order.State = "En Proceso";

            foreach (var product in order.Products)
            {
                order.Total += product.CalculateTotalValue();
            }
        }
    }
}