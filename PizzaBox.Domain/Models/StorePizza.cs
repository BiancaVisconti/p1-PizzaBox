using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class StorePizza : AModel
  {
    public long StorePizzaId { get; set; }
    public long PizzaId { get; set; }
    public long StoreId { get; set; }
    public int Inventory { get; set; }

    #region NAVIGATIONAL PROPERTIES
    public Pizza Pizza { get; set; }
    public Store Store { get; set; }

    #endregion

    public StorePizza()
    {
      //StorePizzaId = DateTime.Now.Ticks;
    }

    public override long GetId()
    {
      return StorePizzaId;
    }
  }
}