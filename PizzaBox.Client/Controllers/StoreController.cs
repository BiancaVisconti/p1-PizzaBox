using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    private StoreRepository _sr;

    public StoreController(StoreRepository repository)
    {
      _sr = repository;
    }

    [HttpGet]
    public IActionResult LoginStore()
    {
      return View();
    }

    [HttpPost]
    public IActionResult LoginStore(StoreViewModel store)
    {
      
      if (ModelState.IsValid)
      {
        var acct = _sr.CheckIfAccountExists(store.Username, store.Password);

        if (acct)
        {
          var s = _sr.GetStore(store.Username, store.Password);

          ViewBag.Message = s;
          
          return View("StoreOptions");
        }
      }
      return View(store);
    }

    [HttpPost]
    public IActionResult MenuPizzeria(StoreViewModel store)
    {
      var s = _sr.GetStore(store.Username, store.Password);

      ViewBag.Message = s;
      
      return View("StoreOptions");
    }

    [HttpGet]
    public IActionResult History(StoreViewModel store)
    {
      var s = _sr.GetStore(store.Username, store.Password);

      //ViewBag.Message = u;
      
      return View("StorePastOrdersOptions");
    }

    [HttpPost]
    public IActionResult StoreAllOrders(StoreViewModel store)
    {
       ViewBag.Message = "Your Order History";
      
      long tempInt = store.StoreId;
      var data = _sr.GetOrders(tempInt);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      foreach (var row in data)
      {
        listOrders.Add(new OrderViewModel
        {
            UserId = row.UserId,
            Date = row.Date,
        });
          
      }
      return View(listOrders);
    }

    [HttpPost]
    public IActionResult Days7Orders(StoreViewModel store)
    {
      
      return View("StorePastOrdersOptions");
    }

    [HttpPost]
    public IActionResult Days30Orders(StoreViewModel store)
    {
      return View("StorePastOrdersOptions");
    }

    [HttpGet]
    public IActionResult PizzeriaInventory(StoreViewModel store)
    {
      return View("StoreOptions");
    }
  }
}