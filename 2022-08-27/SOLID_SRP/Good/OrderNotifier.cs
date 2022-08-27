using SOLID_SRP.Models;

public class OrderNotifier
{
    private readonly Order _order;

    public OrderNotifier(Order order)
    {
        _order = order;
    }

    public void Notify()
    {
        //TODO: send notification
        Console.WriteLine($"send notification: {_order.OrderNumber}");
    }
}