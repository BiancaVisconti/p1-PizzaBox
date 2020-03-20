using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StorePizzaRepository : IStorePizza // ARepository<StorePizza>
  {
    //private static readonly StorePizzaRepository _spr = new StorePizzaRepository();

    private PizzaBoxDbContext _db;
    
    public StorePizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<StorePizza> Get() 
    {
			return _db.StorePizza.ToList();
    }

    public List<StorePizza> GetPerStore(Store store) 
    {
			return _db.StorePizza.Where(sp => sp.StoreId == store.StoreId).ToList();
    }

    public StorePizza Get(Store store, Pizza pizza)
    {
      StorePizza storePizza = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId));
      
      return storePizza;
    }

    public int GetInventory(Store store, Pizza pizza)
    {
      int inventory = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId).Inventory);
      
      return inventory;
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