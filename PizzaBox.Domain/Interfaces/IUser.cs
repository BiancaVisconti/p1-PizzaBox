using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IUser
  {
    bool CheckIfAccountExists(string name, string password);


    User GetUser(string name, string password);

 
  }
}