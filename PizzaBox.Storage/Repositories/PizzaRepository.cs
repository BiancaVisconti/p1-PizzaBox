using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using System;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository : IPizza // ARepository<Pizza>
  {
    //private static readonly PizzaRepository _pr = new PizzaRepository();

    private PizzaBoxDbContext _db;
    
    public PizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<Pizza> Get() 
    {
			return _db.Pizza.ToList();
    }

    public Pizza GetPizza(long pizzaId)
    {
      Pizza pizza = _db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId);
      
      return pizza;
    }
 
    public string GetName(long pizzaId)
    {
      string pizzaName = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Name);
      
      return pizzaName;
    }

    public decimal GetPrice(long pizzaId)
    {
      decimal pizzaPrice = (_db.Pizza.SingleOrDefault(p => p.PizzaId == pizzaId).Price);
      
      return pizzaPrice;
    }

    public Pizza GetPizzaByNumMenu(int id)
    {
      return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
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
    
  }
}