using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
    private PizzaBoxRepository _pbr;

    public PizzaViewModel(PizzaBoxRepository repository)
    {
      _pbr = repository;
    }

    [Display(Name = "n°")]
    public long PizzaId { get; set; }

    [Display(Name = "pizza")]
    public string Name { get; set; }

    [Display(Name = "description")]
    public string Description { get; set; }
    
    [Display(Name = "price")]
    public decimal Price { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public List<OrderPizza> OrderPizzas { get; set; }
    public List<StorePizza> StorePizzas { get; set; }

    #endregion

  }
}