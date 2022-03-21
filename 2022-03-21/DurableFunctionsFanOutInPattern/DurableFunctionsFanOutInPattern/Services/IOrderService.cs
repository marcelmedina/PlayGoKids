using System;
using System.Collections.Generic;
using DurableFunctionsFanOutInPattern.Model;

namespace DurableFunctionsFanOutInPattern.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders(DateTime dateTime);
        string ProcessOrder(Order order);
        void SendNotification(string[] orderNumbers);
    }
}
