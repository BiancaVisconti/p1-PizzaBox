using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
  public class User : ASuperUser
  {
    public long UserId { get; set; }

    public List<Order> Orders { get; set; }

    public User()
    {
      //UserId = DateTime.Now.Ticks;
    }

    public override string ToString()
    {
      return $"{UserId} {Name} {Address}";
    }

    public override long GetId()
    {
      return UserId;
    }
  }
}