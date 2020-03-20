using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class Pizza : AModel
  {
    public long PizzaId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    //public int NumMenu { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public List<OrderPizza> OrderPizzas { get; set; }
    public List<StorePizza> StorePizzas { get; set; }

    #endregion
    public Pizza()
    {
      //PizzaId = DateTime.Now.Ticks;
    }

    public override string ToString()
    {
      return $"{PizzaId})  ${Price}  {Name}  {Description} ";
    }

    public override long GetId()
    {
      return PizzaId;
    }

  }
}