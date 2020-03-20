using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class OrderPizza : AModel
  {
    public long OrderPizzaId { get; set; }
    public long PizzaId { get; set; }
    public long OrderId { get; set; }
    public int Amount { get; set; }

    #region NAVIGATIONAL PROPERTIES
    public Pizza Pizza { get; set; }
    public Order Order { get; set; }

    #endregion

    public OrderPizza()
    {
      //OrderPizzaId = DateTime.Now.Ticks;
    }

    public override long GetId()
    {
      return OrderPizzaId;
    }
  }
}