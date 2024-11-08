using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;

namespace e_commerce_domain.entities.ShoppingCar
{
    public class ShoppingCar
    {
        public Customer Customer { get; set; }
        public ICollection<ProductBase> Products { get; set; }
    }
}
