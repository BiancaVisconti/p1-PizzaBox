using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository : IOrder // ARepository<Order>
  {

    //private static readonly OrderRepository _or = new OrderRepository();

    private PizzaBoxDbContext _db;
    
    public OrderRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<Order> Get() 
    {
			return _db.Order.ToList();
    }

    public List<Order> Get(Store store)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == store.StoreId).ToList());
      
      return list;
    }

    public List<Order> Get(User user)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId).ToList());
      return list;
    }

    public List<Order> GetPeriod(Store store, double days)
    {
      List<Order> list = (_db.Order.Where(o => o.StoreId == store.StoreId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());
      
      return list;
    }

    public List<Order> GetPeriod(User user, double days)
    {
      List<Order> list = (_db.Order.Where(o => o.UserId == user.UserId && o.Date.AddHours(days*24) >= DateTime.Now).ToList());

      return list;
    }

    public int Get2Hours(User user)
    {
      List<Order> list = Get(user);
      int count = 0;

      foreach (var o in list)
      {
          double minutes = DateTime.Now.Subtract(o.Date).TotalMinutes;

          if (minutes < 2*60)
          {
            count++;
          }
      }
      return count;
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

    public bool Post(Order order)
    {
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
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

  }
}