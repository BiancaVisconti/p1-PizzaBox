using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StorePizzaRepository : IStorePizza
  {

    private PizzaBoxDbContext _db;
    
    public StorePizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<StorePizza> GetPizzasInStore(Store store)
    {
      List<StorePizza> list = (_db.StorePizza.Where(sp => sp.StoreId == store.StoreId && sp.Inventory > 0).ToList());
      
      return list;
    }

    public bool Post(StorePizza storePizza)
    {
      _db.StorePizza.Add(storePizza);
      return _db.SaveChanges() == 1;
    }

    public bool Update(StorePizza storePizza)
    {
      _db.StorePizza.Update(storePizza);
      return _db.SaveChanges() == 1;
    }
    
  }
}