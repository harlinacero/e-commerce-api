using e_commerce_domain.entities.Order;
using e_commerce_domain.services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                var newOrder = _orderService.CreateOrder(order);
                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult CreateOrder(Guid orderid)
        {
            try
            {
                var newOrder = _orderService.FollowOrder(orderid);
                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}