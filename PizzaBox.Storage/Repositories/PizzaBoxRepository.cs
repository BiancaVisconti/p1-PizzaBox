using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaBoxRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    
    public IEnumerable<T> Read<T>() where T : class
    {
      return _db.Set<T>();
    }
  }
}