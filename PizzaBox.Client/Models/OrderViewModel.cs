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

    [Display(Name = "pizzeria")]
    public string StoreName { get; set; }

    public long UserId { get; set; }

    public string UserName { get; set; }

    [Display(Name = "date")]
    public DateTime Date { get; set; }

    
    [Display(Name = "order")]
    public int Count { get; set; } = 0;

    public List<OrderPizza> OrderPizzas { get; set; }

    public List<string> AmountPizzas { get; set; }

    
  }
}