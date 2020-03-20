using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IOrderPizza
  {
    List<OrderPizza> Get(Order order);
  }
}