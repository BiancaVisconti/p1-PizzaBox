using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IOrder
  {
    List<Order> Get(Store store);
    List<Order> GetPeriod(Store store, double days);
    List<Order> GetPeriod(User user, double days);
    int Get2Hours(User user);
    int Get24HoursAtStore(User user, Store store);
    List<Order> Get(User user);
  }

}