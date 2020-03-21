using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class UserChoiceStore
  {
    public string NameStore { get; set; }
  }
}