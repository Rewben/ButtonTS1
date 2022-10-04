// See https://aka.ms/new-console-template for more information
using FateSystem.Devices;

Console.WriteLine("Start of Program.");

static void Main(string[] args)
{
    var order = new Order { Item = "Pizza with extra cheese" };
            
    var orderingService = new FoodOrderingService();
    var appService = new AppService();
    var mailService = new MailService();

    orderingService.FoodPrepared += appService.OnFoodPrepared;
    orderingService.FoodPrepared += mailService.OnFoodPrepared;

    orderingService.PrepareOrder(order);
    
    Console.ReadKey();
}
public class AppService
{
    public void OnFoodPrepared(object source, EventArgs eventArgs)
    {
        Console.WriteLine("NotificationService: your food is prepared");
    }
}

public class MailService
{
    public void OnFoodPrepared(object source, EventArgs eventArgs)
    {
        Console.WriteLine("MailService: your food is prepared.");
    }
}
public class Order
{
    public string Item { get; set; }
    public string Ingredients { get; set; }

}

public class FoodOrderingService
{
    // define a delegage
    public delegate void FoodPreparedEventHandler(object source, EventArgs args);
    // declare the event
    public event FoodPreparedEventHandler FoodPrepared;

    protected virtual void SendAppNotification(string Notify)
    {
        Console.WriteLine(Notify);
    }
    protected virtual void SendEmailNotification(string Notify)
    {
        Console.WriteLine(Notify);
    }
    public void PrepareOrder(Order order)
    {
        Console.WriteLine($"Preparing your order '{order.Item}', please wait...");
        Thread.Sleep(4000);

        OnFoodPrepared();

        SendAppNotification("Notification Sent");
    }
    protected virtual void OnFoodPrepared()
    {
        if (FoodPrepared != null)
            FoodPrepared(this, null);
           
        else
            Console.WriteLine("FAILED to Prepare food.");
    }

    


}


