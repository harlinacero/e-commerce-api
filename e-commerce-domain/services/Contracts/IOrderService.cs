using e_commerce_domain.entities.Order;

namespace e_commerce_domain.services.Contracts
{
    public interface IOrderService
    {
        string CreateOrder(Order order);
        string FollowOrder(Guid order);
    }
}