using DurableFunctionsChainingPattern.Model;

namespace DurableFunctionsChainingPattern.Services
{
    public interface IOrderService
    {
        Order InitializeOrder(Order order);
        Order ValidateOrder(Order order);
        Order ProcessOrder(Order order);
        Order SaveOrder(Order order);
    }
}
