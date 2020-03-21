using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
    

    public long OrderId { get; set; }

    public long StoreId { get; set; }

    public long UserId { get; set; }

    public DateTime Date { get; set; }

    
  }
}