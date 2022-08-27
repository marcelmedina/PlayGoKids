using SOLID_SRP;
using SOLID_SRP.Models;

var order = new Order(1);
var processor = new OrderProcessor(order);
processor.Validate();
processor.Save();
processor.Notify();
