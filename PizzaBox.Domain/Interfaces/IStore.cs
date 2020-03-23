using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IStore
  {
    bool CheckIfAccountExists(string name, string password);

    Store GetStore(string name, string password);


  }
}