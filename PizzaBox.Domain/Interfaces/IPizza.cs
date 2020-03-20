using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IPizza
  {

    string GetName(long pizzaId);

    decimal GetPrice(long pizzaId);

    Pizza GetPizzaByNumMenu(int id);

  }

}