using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    
    private static User currentUser;
    private static Store currentStore;
    private static Order currentOrder;
    private OrderRepository _or;

    public OrderController(OrderRepository repository)
    {
      _or = repository;
    }

    [HttpGet]
    public IActionResult OrderPizzas()
    {
      return View();
    }

    [HttpPost]
    public IActionResult OrderPizzas(List<PizzaViewModel> listOfPizzas)
    {
      return View();
    }

    /*[HttpGet]
    public IActionResult ClientAllOrders(UserViewModel u)
    {
       ViewBag.Message = "Your Order History";
      
      long tempInt = u.UserId;
      var data = _or.Get(tempInt);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      foreach (var row in data)
      {
        listOrders.Add(new OrderViewModel
        {
            StoreId = row.StoreId,
            Date = row.Date,
        });
          
      }
      return View(listOrders);

    }
    */

  }
}