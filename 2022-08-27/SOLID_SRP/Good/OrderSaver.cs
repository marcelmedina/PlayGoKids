using SOLID_SRP.Models;

public class OrderSaver
{
    private readonly Order _order;

    public OrderSaver(Order order)
    {
        _order = order;
    }

    public void Save()
    {
        //TODO: save order
        Console.WriteLine($"save order: {_order.OrderNumber}");
    }
}