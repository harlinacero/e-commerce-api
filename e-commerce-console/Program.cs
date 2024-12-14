using e_commerce_domain.entities.Order;
using e_commerce_domain.entities.Product;
using e_commerce_domain.entities.User;
using e_commerce_domain.enums;
using e_commerce_domain.observer;
using e_commerce_domain.observer.contracts;
using e_commerce_domain.services.Contracts;
using e_commerce_domain.services.PayFactory;
using e_commerce_domain.useCases;

internal class Program
{
    private static void Main(string[] args)
    {
        // Ejemplo de implementación de clases abstractas
        Console.WriteLine("----------------- Modificación del inventario de productos -----------------");
        AbstractManagerInventory();
        Console.WriteLine("----------------- Fin de la modificación del inventario de productos -----------------");
        Console.WriteLine();
        
        
        // Ejemplo de implementación interfaces 
        Console.WriteLine("----------------- Pago de órdenes -----------------");
        PayOrderProcess();
        Console.WriteLine();
        Console.WriteLine("----------------- Fin del pago -----------------");
        Console.ReadLine();
    }

    private static void AbstractManagerInventory()
    {
        //InventoryManager digitalInventoryManager = new DigitalInventoryManager();
        //InventoryManager physicalInventoryManager = new PhysicalInventoryManager();

        //// Agregar observadores
        //digitalInventoryManager.AddObserver(new InventoryObserver());
        //physicalInventoryManager.AddObserver(new InventoryObserver());


        //var digitalProduct = new DigitalProduct("libro.pdf", "Libro digital", 300, 20, 10, 10, "PDF", 200);
        //var physicalProduct = new PhysicalProduct("libro", "Libro pasta dura", 300, 20, 10, 10, 150, 20, 35, 3, 50);
        
        
        //Console.WriteLine();
        //digitalInventoryManager.AddProduct(digitalProduct);
        //physicalInventoryManager.AddProduct(physicalProduct);
       
        //Console.WriteLine();
        //digitalInventoryManager.UpdateStock(digitalProduct.Id, 50);
        //physicalInventoryManager.UpdateStock(physicalProduct.Id, 50);
        
        //Console.WriteLine();
        //digitalInventoryManager.DeleteProduct(digitalProduct.Id);
        //physicalInventoryManager.DeleteProduct(physicalProduct.Id);

    }

    private static void PayOrderProcess()
    {
        
        Console.WriteLine("----------------- Pago por PayPal -----------------");
        Order order1 = PrepareOrder(4, 3);
        IPayProcess creditCarPay = PayProcessFactory.Create(MethodPay.PayPal, order1);
        creditCarPay.BeginPayProcess();
        if (creditCarPay.IsPayProcessAvailable())
        {
            creditCarPay.ConfirmPay();
        }


        Console.WriteLine();
        Console.WriteLine("----------------- Pago por Tarjeta de Crédito -----------------");
        Order order2 = PrepareOrder(2, 5);
        creditCarPay = PayProcessFactory.Create(MethodPay.CreditCard, order2);
        creditCarPay.BeginPayProcess();
        if (creditCarPay.IsPayProcessAvailable())
        {
            creditCarPay.ConfirmPay();
        }

        Console.WriteLine();
        Console.WriteLine("----------------- Pago en efectivo -----------------");
        Order order3 = PrepareOrder(3, 0);
        creditCarPay = PayProcessFactory.Create(MethodPay.Cash, order3);
        creditCarPay.BeginPayProcess();
        if (creditCarPay.IsPayProcessAvailable())
        {
            creditCarPay.ConfirmPay();
        }

        Console.WriteLine();
        Console.WriteLine("----------------- Pago por transferencia -----------------");
        Order order4 = PrepareOrder(0, 10);
        creditCarPay = PayProcessFactory.Create(MethodPay.Cash, order4);
        creditCarPay.BeginPayProcess();
        if (creditCarPay.IsPayProcessAvailable())
        {
            creditCarPay.ConfirmPay();
        }

        Console.WriteLine();
    }


    /// <summary>
    /// Crea una nueva orden agregando un número específico de productos físicos y digitales
    /// </summary>
    /// <param name="totalDigitalProducts"></param>
    /// <param name="totalPhysicalProducts"></param>
    /// <returns></returns>
    private static Order PrepareOrder(int totalDigitalProducts, int totalPhysicalProducts)
    {
        Customer customer = new("Harlin", "harlina@mail.com", "harlin123", "harlin", "acero", "av123");

        Order order = new()
        {
            Id = Guid.NewGuid(),
            Products = new List<ProductBase>(),
            Customer = customer,
            Date = new DateTime()
        };

        for (int i = 0; i <= totalDigitalProducts; i++)
        {
            var product = new DigitalProduct("libro.pdf", "Libro digital", 300, 20, 10, 10, "PDF", 200);
            order.Products.Add(product);
            order.Total += product.CalculateTotalValue();
        }

        for (int i = 0; i <= totalPhysicalProducts; i++)
        {
            var product = new PhysicalProduct("libro", "Libro pasta dura", 300, 20, 10, 10, 150, 20, 35, 3, 50);
            order.Products.Add(product);
            order.Total += product.CalculateTotalValue();
        }
        order.State = "En Proceso";

        return order;
    }
}


