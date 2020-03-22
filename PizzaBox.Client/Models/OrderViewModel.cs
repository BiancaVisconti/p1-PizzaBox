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

    public string ClientName { get; set; }

    [Display(Name = "date")]
    public DateTime Date { get; set; }

    
    [Display(Name = "order")]
    public int Count { get; set; } = 0;

    public List<OrderPizza> OrderPizzas { get; set; }

    public List<string> AmountPizzas { get; set; }

    public Store StoreSelected { get; set; }

    public List<Pizza> ListOfPizzas { get; set; }

    public User Client { get; set; }

    public decimal TotalPrice { get; set; }

    public List<Order> Orders { get; set; }

    public List<string> RevenueAmountPerPizza { get; set; }

    public int TotalAmount { get; set; }

    public decimal TotalRevenue { get; set; }

    
  }
}