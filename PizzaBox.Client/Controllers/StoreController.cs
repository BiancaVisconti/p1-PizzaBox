using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    
    private static User currentUser;
    private static Store currentStore;
    private static Order currentOrder;
    private static Pizza currentPizza;
    private static List<Pizza> currentListOfPizzas = new List<Pizza>();
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
      
      var acct = _sr.CheckIfAccountExists(store.Username, store.Password);

      if (acct)
      {
        currentStore = _sr.GetStore(store.Username, store.Password);

        var s = new StoreViewModel()
        {
          Username = currentStore.Name,
          Password = currentStore.Password,
          StoreId = currentStore.StoreId,
          Address = currentStore.Address
        };
        
        return View("StoreOptions", s);
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
      var list = _sr.GetOrders(tempInt);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string clientName = _sr.GetNameClient(order.UserId);

        List<OrderPizza> listOrderPizza = _sr.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _sr.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _sr.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          ClientName = clientName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
          
      }
      return View(listOrders);
    }

    [HttpPost]
    public IActionResult SDays7Orders(StoreViewModel store)
    {
      
      ViewBag.Message = "Your Order History";
      
      long tempInt = store.StoreId;
      var list = _sr.GetPeriodStore(tempInt, 7);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string clientName = _sr.GetNameClient(order.UserId);

        List<OrderPizza> listOrderPizza = _sr.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _sr.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _sr.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          ClientName = clientName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
          
      }
      return View(listOrders);
    }

    [HttpPost]
    public IActionResult SDays30Orders(StoreViewModel store)
    {
      ViewBag.Message = "Your Order History";
      
      long tempInt = store.StoreId;
      var list = _sr.GetPeriodStore(tempInt, 30);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string clientName = _sr.GetNameClient(order.UserId);

        List<OrderPizza> listOrderPizza = _sr.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _sr.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _sr.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          ClientName = clientName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
          
      }
      return View(listOrders);
    }

    [HttpGet]
    public IActionResult PizzeriaInventory(StoreViewModel store)
    {
      
      return View("StoreOptions");
    }

    [HttpGet]
    public IActionResult SalesAndRevenue()
    {
      List<Order> listOrders = _sr.Get(currentStore);
      decimal totalRevenue = 0;
      int totalAmount = 0;
      List<string> listPizzaAmountRevenue = new List<string>();
      Dictionary<long, int> RepeatedPizzaSales = _sr.CalculateSalesAndRevenue(listOrders);
      foreach (var p in RepeatedPizzaSales)
      {
        totalAmount += p.Value;
        int amount = p.Value;
        string namePizza = _sr.GetNamePizza(p.Key);
        decimal price = _sr.GetPricePizza(p.Key);
        totalRevenue += amount*price;
        decimal revenue = amount*price; 
        listPizzaAmountRevenue.Add(amount.ToString());
        listPizzaAmountRevenue.Add(namePizza);
        listPizzaAmountRevenue.Add(revenue.ToString());
      }

      var o = new OrderViewModel()
      {
        RevenueAmountPerPizza = listPizzaAmountRevenue,
        TotalAmount = totalAmount,
        TotalRevenue = totalRevenue,
        StoreName = currentStore.Name
      };
    
      return View("SalesAndRevenue", o);
    }
  }
}