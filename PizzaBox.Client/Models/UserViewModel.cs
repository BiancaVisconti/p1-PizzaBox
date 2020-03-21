using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class UserViewModel
  {
    [Display(Name = "username")]
    [Required(ErrorMessage ="please enter your username")]
    public string Name { get; set; }
    [Display(Name = "password")]
    [Required(ErrorMessage ="please enter a valid password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string Address { get; set; }

    public long UserId { get; set; }

    public List<Order> Orders { get; set; }
  }
}