using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
namespace PizzaBox.Storing.Repositories
{
  public class OrderPizzaRepository : IOrderPizza
  {

    private PizzaBoxDbContext _db;
    
    public OrderPizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }


    public List<OrderPizza> Get(Order order)
    {
      List<OrderPizza> list = (_db.OrderPizza.Where(op => op.OrderId == order.OrderId).ToList());
      
      return list;
    }

    public bool Post(OrderPizza orderPizza)
    {
      _db.OrderPizza.Add(orderPizza);
      return _db.SaveChanges() == 1;
    }
    
  }
}