using System.Collections.Generic;
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

    [HttpGet]
    public IActionResult ClientAllOrders(UserViewModel user)
    {
      ViewBag.Message = "ClientAllOrders";
      //TempData["UserViewModel"] = user;

      var data = _or.Get(user.UserId);
      
      List<Order> listOrders = new List<Order>();
      

      foreach (var row in data)
      {
        listOrders.Add(new Order
        {
            StoreId = row.StoreId,
            Date = row.Date,
        });
          
      }
      

      return View("ClientAllOrders");
      //return View();
    }

  }
}