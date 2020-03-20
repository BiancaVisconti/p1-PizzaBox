using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Store : ASuperUser
  {
    public long StoreId { get; set; }
    //public int NumMenu { get; set; }

    public List<Order> Orders { get; set; }

    #region NAVIGATIONAL PROPERTIES
    public List<StorePizza> StorePizzas { get; set; }

    #endregion

    public Store()
    {
      //StoreId = DateTime.Now.Ticks;
    }

    public override string ToString()
    {
      return $"{StoreId}) {Name} in {Address}";
    }

    public override long GetId()
    {
      return StoreId;
    }
  }
}