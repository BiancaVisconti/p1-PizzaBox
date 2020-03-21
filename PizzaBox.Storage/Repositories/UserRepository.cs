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

    public List<User> Get() 
    {
			return _db.User.ToList();
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

    public bool CheckIfUsernameExists(string name)
    {
      if (_db.User.SingleOrDefault(s => s.Name == name) != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public long GetId(string name, string password)
    {
      long id = (_db.User.SingleOrDefault(u => u.Name == name && u.Password == password).UserId);
      
      return id;
    }

    public User GetUser(string name, string password)
    {
      return _db.User.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public User GetUser(long userId)
    {
      return _db.User.SingleOrDefault(u => u.UserId == userId);
    }

    public string GetName(long userId)
    {
      string userName = (_db.User.SingleOrDefault(u => u.UserId == userId).Name);
      
      return userName;
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

    public Store GetStore(string name, string password)
    {
      return _db.Store.SingleOrDefault(u => u.Name == name && u.Password == password);
    }

    public Store GetStoreById(string numStore)
    {
      return _db.Store.SingleOrDefault(s => s.StoreId.ToString() == numStore);
    }

    public Store GetStore(string name)
    {
      return _db.Store.SingleOrDefault(u => u.Name == name);
    }

    public bool Post(User user)
    {
      _db.User.Add(user);
      return _db.SaveChanges() == 1;
    }

  }
}