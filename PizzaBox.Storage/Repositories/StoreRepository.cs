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
 
  }
}