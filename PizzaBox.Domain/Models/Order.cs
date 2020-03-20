using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public long OrderId { get; set; }

    public DateTime Date { get; set; }

    //public List<Pizza> ListOfPizza { get; }

    public long StoreId { get; set; }

    public long UserId { get; set; }

    #region NAVIGATIONAL PROPERTIES
    public Store Store { get; set; }

    public User User { get; set; }

    public List<OrderPizza> OrderPizzas { get; set; }

    #endregion

    public Order()
    {
      Date = DateTime.Now;
    }

    public override long GetId()
    {
      return OrderId;
    }
  }
}