using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IStorePizza
  {
    List<StorePizza> GetPizzasInStore(Store store);
  }
}