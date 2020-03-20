using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
namespace PizzaBox.Storing.Repositories
{
  public class OrderPizzaRepository : IOrderPizza  // ARepository<OrderPizza>
  {
    //private static readonly OrderPizzaRepository _opr = new OrderPizzaRepository();

    private PizzaBoxDbContext _db;
    
    public OrderPizzaRepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }

    public List<OrderPizza> Get() 
    {
			return _db.OrderPizza.ToList();
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