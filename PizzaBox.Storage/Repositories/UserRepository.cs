using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository : IUser // ARepository<User>
  {
    //private static readonly UserRepository _ur = new UserRepository();
    //private static readonly OrderRepository _or = new OrderRepository();

    private PizzaBoxDbContext _db;
    
    public UserRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public bool CheckIfAccountExists(string name, string password)
    {
      if (_db.User.SingleOrDefault(u => u.Name == name && u.Password == password) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public User GetUser(string name, string password)
    {
      return _db.User.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public List<Order> GetOrders(long userId)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == userId).ToList());
      return list;
    }

    public string GetNameStore(long storeId)
    {
      string storeName = (_db.Store.SingleOrDefault(s => s.StoreId == storeId).Name);
      
      return storeName;
    }

    public List<OrderPizza> Get(Order order)
    {
      List<OrderPizza> list = (_db.OrderPizza.Where(op => op.OrderId == order.OrderId).ToList());
      
      return list;
    }

    public string GetNamePizza(long pizzaId)
    {
      string pizzaName = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Name);
      
      return pizzaName;
    }

    public List<Store> ShowPizzerias()
    {
      return _db.Store.ToList(); 
    }

    public Store GetStoreById(string numStore)
    {
      return _db.Store.SingleOrDefault(s => s.StoreId.ToString() == numStore);
    }

    public List<StorePizza> GetPizzasInStore(Store store)
    {
      List<StorePizza> list = (_db.StorePizza.Where(sp => sp.StoreId == store.StoreId && sp.Inventory > 0).ToList());
      
      return list;
    }

    public Pizza GetPizza(string pizzaId)
    {
      Pizza pizza = _db.Pizza.SingleOrDefault(p => p.PizzaId.ToString() == pizzaId);
      
      return pizza;
    }

    public List<Order> GetOrders() 
    {
			return _db.Order.ToList();
    }

    public List<OrderPizza> GetOrderPizzas() 
    {
			return _db.OrderPizza.ToList();
    }

    public decimal GetPricePizza(long pizzaId)
    {
      decimal pizzaPrice = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Price);
      
      return pizzaPrice;
    }

    public List<Order> GetPeriodUser(long userId, int days)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == userId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());

      return list;
    }

    public bool PostOrder(Store store, User user)
    {
      var o = new Order();
      o.OrderId = GetOrders().Count() + 1;
      o.StoreId = store.StoreId;
      o.UserId = user.UserId;

      _db.Order.Add(o);
      return _db.SaveChanges() == 1;
    }

    public bool UpdateInventory(Store store, Pizza pizza, int new_inventory)
    {
      var sp = Get(store, pizza);
      sp.Inventory = new_inventory;
      
      _db.StorePizza.Update(sp);
      return _db.SaveChanges() == 1;
    }

    public Pizza GetPizzaByNumMenu(int id)
    {
      return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
    }
    
    public bool CheckIfNumMenuPizzaIsValid(string nuMenu, Dictionary<long, int> dict)
    {
      int result;
      if (int.TryParse(nuMenu, out result))
      {
        Pizza pizza = GetPizzaByNumMenu(Int32.Parse(nuMenu));
        if (pizza != null)
        {
          foreach (var d in dict)
          {
            if(d.Key == pizza.PizzaId && d.Value > 0)
            {
              return true;
            }   
          }
          return false;
        }
        else
        {
          return false;
        }
        
      }
      else
      {
        return false;
      }          
    } 

    public bool PostOrderPizza(Order order, Pizza pizza, int amount)
    {
      var op = new OrderPizza();
      op.OrderPizzaId = GetOrderPizzas().Count() + 1;
      op.OrderId = order.OrderId;
      op.PizzaId = pizza.PizzaId;
      op.Amount = amount;

      _db.OrderPizza.Add(op);
      return _db.SaveChanges() == 1;
    }

    public StorePizza Get(Store store, Pizza pizza)
    {
      StorePizza storePizza = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId));
      
      return storePizza;
    }

    public Dictionary<Pizza, int> PizzaAmount(List<Pizza> list)
    {
      Dictionary<Pizza, int> RepeatedPizzaOrder = new Dictionary<Pizza, int>();

      for (int i = 0; i < list.Count(); i++)
      {
          if (RepeatedPizzaOrder.ContainsKey(list[i]))
          {
            RepeatedPizzaOrder[list[i]]++;
          }
          else
          {
            RepeatedPizzaOrder.Add(list[i], 1);
          }
      }
      return RepeatedPizzaOrder;
    }

    public bool HasItBeenMoreThan2Hours(User user)
    {
      bool check = true;
      List<Order> list = Get(user);
      foreach (var o in list)
      {
        
        DateTime date = DateTime.Now;
        double minutes = date.Subtract(o.Date).TotalMinutes;

        if (minutes < 2*60)
        {
          check = false;
        }
      }
      return check;
    } 

    public bool HasItBeenMoreThan24Hours(User user, Store store)
    {
      bool check = true;
      List<Order> list = Get(user);
      if (list.Count() > 0)
      {
        int count = Get24HoursAtStore(user, store);
        if (count > 0)
        {
          check = false;
        }
      }
      return check;
    }

    public List<Order> Get(User user)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId).ToList());
      return list;
    }

    public int Get24HoursAtStore(User user, Store store)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId && o.StoreId != store.StoreId).ToList());
      int count = 0;
      foreach (var o in list)
      {
          double minutes = DateTime.Now.Subtract(o.Date).TotalMinutes;

          if (minutes < 24*60)
          {
            count++;
          }
      }
      return count;
    }

   public Pizza GetPizza(long pizzaId)
    {
      Pizza pizza = _db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId);
      
      return pizza;
    }
   
   public List<Pizza> ShowMenu(Dictionary<long, int> dict)
    { 
      List<Pizza> list = new List<Pizza>();
      foreach (var p in dict)
      {
        if (p.Value > 0)
        {
          Pizza pizza = GetPizza(p.Key);
          list.Add(pizza);
        }
      }
      return list;
    }

    public int GetInventory(Store store, Pizza pizza)
    {
      int inventory = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId).Inventory);
      
      return inventory;
    } 

  }
}