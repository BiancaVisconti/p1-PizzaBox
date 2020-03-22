using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository : IStore // ARepository<Store>
  {

    //private static readonly StoreRepository _sr = new StoreRepository();

    private PizzaBoxDbContext _db;
    
    public StoreRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }
    
    public List<Store> Get() 
    {
			return _db.Store.ToList();
    }

    public bool CheckIfAccountExists(string name, string password)
    {
      if (_db.Store.SingleOrDefault(s => s.Name == name && s.Password == password) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public bool CheckIfUsernameExists(string name)
    {
      if (_db.Store.SingleOrDefault(s => s.Name == name) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public long GetId(int numMenu)
    {
      long id = (_db.Store.SingleOrDefault(s => s.StoreId == numMenu).StoreId);
      
      return id;
    }

    public long GetId(string name, string password)
    {
      long id = (_db.Store.SingleOrDefault(s => s.Name == name && s.Password == password).StoreId);
      
      return id;
    }

    public Store GetStore(string name, string password)
    {
      return _db.Store.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public Store GetStore(int numMenu)
    {
      return _db.Store.SingleOrDefault(s => s.StoreId == numMenu);
    }

    public string GetName(long storeId)
    {
      string storeName = (_db.Store.SingleOrDefault(s => s.StoreId == storeId).Name);
      
      return storeName;
    }
    public string GetNameClient(long userId)
    {
      string clientName = (_db.User.SingleOrDefault(s => s.UserId == userId).Name);
      
      return clientName;
    }

    public List<OrderPizza> Get(Order order)
    {
      List<OrderPizza> list = (_db.OrderPizza.Where(op => op.OrderId == order.OrderId).ToList());
      
      return list;
    }

    public List<Order> Get(Store store)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == store.StoreId).ToList());
      
      return list;
    }

    public List<Order> GetPeriodStore(long storeId, double days)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == storeId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());
      
      return list;
    }

    public decimal GetPricePizza(long pizzaId)
    {
      decimal pizzaPrice = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Price);
      
      return pizzaPrice;
    }

    public string GetNamePizza(long pizzaId)
    {
      string pizzaName = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Name);
      
      return pizzaName;
    }

    public Pizza GetPizza(long pizzaId)
    {
      Pizza pizza = _db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId);
      
      return pizza;
    }

    public List<StorePizza> GetPerStore(Store store) 
    {
			return _db.StorePizza.Where(sp => sp.StoreId == store.StoreId).ToList();
    }

    public List<Order> GetOrders(long storeId)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == storeId).ToList());
      return list;
    }

    public bool Post(Store store)
    {
      _db.Store.Add(store);
      return _db.SaveChanges() == 1;
    }

    public bool CheckIfNumLocationIsValid(string nuMenu)
    {
      int result;
      if (int.TryParse(nuMenu, out result))
      {
        Store store = GetStore(Int32.Parse(nuMenu)); ///*******CHANGE METHOD
        if (store == null)
        {
          return false;
        }
        else
        {
          return true;
        }
      }
      else
      {
        return false;
      }
    }

    public void ShowStores()
    {
      foreach (var s in Get())
      {
        Console.WriteLine(s);
      }
    }

    public Dictionary<long, int> CalculateSalesAndRevenue(List<Order> listOrders)
    {
      Dictionary<long, int> RepeatedPizzaSales = new Dictionary<long, int>();

      foreach (var o in listOrders)
      {
        List<OrderPizza> listOrderPizza = Get(o);
        for (int i = 0; i < listOrderPizza.Count(); i++)
        {
          if (RepeatedPizzaSales.ContainsKey(listOrderPizza[i].PizzaId))
          {
            RepeatedPizzaSales[listOrderPizza[i].PizzaId] += listOrderPizza[i].Amount;
          }
          else
          {
            RepeatedPizzaSales.Add(listOrderPizza[i].PizzaId, listOrderPizza[i].Amount);
          }
        }  
      }
      return RepeatedPizzaSales;
    }
 
  }
}