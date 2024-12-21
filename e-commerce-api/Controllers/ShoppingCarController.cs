using e_commerce_domain.entities.Product;
using e_commerce_domain.repositories;
using e_commerce_domain.services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCarController : ControllerBase
    {
        private readonly IShoppingCarService _shoppingCarService;
        private readonly IInventoryManager _physicalInventoryManager;
        private readonly IInventoryManager _digitalInventoryManager;

        public ShoppingCarController(IShoppingCarService shoppingCarService, IInventoryManager physicalInventoryManager, IInventoryManager digitalInventoryManager)
        {
            _shoppingCarService = shoppingCarService;
            _physicalInventoryManager = physicalInventoryManager;
            _digitalInventoryManager = digitalInventoryManager;
        }

        [HttpPost($"AddProductToShoppingCarById")]
        public ActionResult AddProductToShoppingCar(Guid productId)
        {
            try
            {
                _shoppingCarService.AddProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost($"AddProductToShoppingCarByName")]
        public ActionResult AddProductToShoppingCar(string productname)
        {
            try
            {
                _shoppingCarService.AddProduct(productname);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost($"AddProductToShoppingCar")]
        public ActionResult AddProductToShoppingCar(ProductBase productBase)
        {
            try
            {
                _shoppingCarService.AddProduct(productBase);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveProductToShoppingCarById")]
        public ActionResult RemoveProductToShoppingCar(Guid productId)
        {
            try
            {
                _shoppingCarService.RemoveProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveProductToShoppingCarByName")]
        public ActionResult RemoveToShoppingCar(string productname)
        {
            try
            {
                _shoppingCarService.RemoveProduct(productname);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost($"{nameof(CalculateTotalValue)}")]
        public ActionResult CalculateTotalValue()
        {
            try
            {
                var totalValue = _shoppingCarService.CalculateTotalValue();
                return Ok(totalValue);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet($"{nameof(ShowInfoProducts)}")]
        public ActionResult ShowInfoProducts()
        {
            try
            {
                var infoProducts = _shoppingCarService.ShowInfoProducts();
                return Ok(infoProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}