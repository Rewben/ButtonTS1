// See https://aka.ms/new-console-template for more information
using FateSystem.Devices;

Console.WriteLine("Start of Program.");

static void Main(string[] args)
{
    var order = new Order { Item = "Pizza with extra cheese" };
    var orderingService = new FoodOrderingService();
    orderingService.PrepareOrder(order);
    Console.ReadKey();
    Thread.Sleep(4000);
    Console.WriteLine();
    Thread.Sleep(4000);
}
public class Order
{
    public string Item { get; set; }
    public string Ingredients { get; set; }

}

public class FoodOrderingService
{
    public void PrepareOrder(Order order)
    {
        Console.WriteLine($"Preparing your order '{order.Item}', please wait...");
        Thread.Sleep(4000);
        Console.WriteLine($"'{order.Item}' Complete.");
        Thread.Sleep(4000);
    }
}

