using System;
using System.Collections.Generic;
using DurableFunctionsFanOutInPattern.Model;

namespace DurableFunctionsFanOutInPattern.Services
{
    public class OrderService : IOrderService
    {
        public List<Order> GetOrders(DateTime dateTime)
        {
            //TODO: Retrieve orders for a particular date

            return new List<Order>()
            {
                new Order(){OrderNumber = "ON-00001"},
                new Order(){OrderNumber = "ON-00002"},
                new Order(){OrderNumber = "ON-00003"},
                new Order(){OrderNumber = "ON-00004"},
                new Order(){OrderNumber = "ON-00005"}
            };
        }

        public string ProcessOrder(Order order)
        {
            //TODO: Any processing
            return order.OrderNumber;
        }

        public void SendNotification(string[] orderNumbers)
        {
            //TODO: Send notification
        }
    }
}
