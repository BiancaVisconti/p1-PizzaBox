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
  public class PizzaRepository : IPizza
  {

    private PizzaBoxDbContext _db;
    
    public PizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<Pizza> Get() 
    {
			return _db.Pizza.ToList();
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
    
  }
}