using SOLID_OCP;
using SOLID_OCP.Models;

var order = new Order(1);
var validator = new OrderValidator(order);
var saver = new CosmosDbOrderSaver(order);
var notifier = new OrderNotifier(order);
var processor = new OrderProcessor(validator, saver, notifier);
processor.Process();
