using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
    [Display(Name = "pizzeria")]
    [Required(ErrorMessage ="please enter your username")]
    public string Username { get; set; }
    [Display(Name = "password")]
    [Required(ErrorMessage ="please enter a valid password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "address")]
    public string Address { get; set; }

    
    [Required(ErrorMessage ="please a valid pizzeria number")]
    public long StoreId { get; set; }

    public List<Order> Orders { get; set; }

    public List<StorePizza> StorePizzas { get; set; }

  }
}