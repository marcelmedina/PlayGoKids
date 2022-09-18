using SOLID_ISP_BAD;
using SOLID_ISP_BAD.Models;

var order = new Order(1);
var validator = new OrderValidator(order);
validator.Validate();
