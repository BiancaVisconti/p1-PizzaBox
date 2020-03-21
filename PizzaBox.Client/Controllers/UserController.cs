using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private static User currentUser;
    private static Store currentStore;
    private static Order currentOrder;
    
    /*private PizzaBoxRepository _pbr;

    public UserController(PizzaBoxRepository repository)
    {
      _pbr = repository;
    }
    */

    private UserRepository _ur;

    public UserController(UserRepository repository)
    {
      _ur = repository;
    }
    
    
    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(UserViewModel user)
    {
      if (ModelState.IsValid)
      {
        var acct = _ur.CheckIfAccountExists(user.Name, user.Password);

        if (acct)
        {
          var u = _ur.GetUser(user.Name, user.Password);
          
          return View("User", u);
        }
      }
      return View(user);
    }
    
    
    [HttpGet]
    public IActionResult History()
    {
      return View("PastOrdersOptions");
    }

    /*[HttpGet]
    public IActionResult AllOrders()
    {
      ViewBag.Message = "Client All Orders";

      List<Order> listOrders = _or.Get(currentUser);

      foreach (var row in listOrders)
      {
        listOrders.Add(new Order
        {
            StoreId = row.StoreId,
            Date = row.Date,
        });
          
      }

      return View(listOrders);

    }
    */

    [HttpGet]
    public IActionResult Days7Orders(UserViewModel user)
    {
      
      
      return View("PastOrdersOptions");
    }

    [HttpGet]
    public IActionResult Days30Orders()
    {
      return View("PastOrdersOptions");
    }


  }
}