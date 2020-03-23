using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository : IStore
  {

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

    public Store GetStore(string name, string password)
    {
      return _db.Store.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public Store GetStore(int numMenu)
    {
      return _db.Store.SingleOrDefault(s => s.StoreId == numMenu);
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

    public List<Order> GetPeriodStore(long storeId, int days)
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

    public StorePizza GetStorePizza(Store store, Pizza pizza)
    {
      StorePizza storePizza = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId));
      
      return storePizza;
    }

    public bool UpdateInventory(Store store, Pizza pizza, int new_inventory)
    {
      var sp = Get(store, pizza);
      sp.Inventory = new_inventory;
      
      _db.StorePizza.Update(sp);
      return _db.SaveChanges() == 1;
    }

    public StorePizza Get(Store store, Pizza pizza)
    {
      StorePizza storePizza = (_db.StorePizza.SingleOrDefault(sp => sp.PizzaId == pizza.PizzaId && sp.StoreId == store.StoreId));
      
      return storePizza;
    }

    public Pizza GetPizza(string pizzaName)
    {
      Pizza pizza = _db.Pizza.SingleOrDefault(p => p.Name == pizzaName);
      
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