using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    private static Store currentStore;
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
      var s = new StoreViewModel()
      {
        Username = currentStore.Name
      };
      
      return View("StorePastOrdersOptions", s);
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
      return View("StoreAllOrders", listOrders);
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
      return View("SDays7Orders", listOrders);
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
      return View("SDays30Orders", listOrders);
    }

    [HttpGet]
    public IActionResult PizzeriaInventory()
    {
      List<string> listInventory = new List<string>();
      
      foreach (var sp in _sr.GetPerStore(currentStore))
      {
        Pizza pizza = _sr.GetPizza(sp.PizzaId);
        listInventory.Add(sp.Inventory.ToString());
        listInventory.Add(pizza.Name);
      }

      var s = new StoreViewModel()
      {
        Inventory = listInventory,
        Username = currentStore.Name,
      };
      
      
      return View("Inventory", s);
    }

    [HttpPost]
    public IActionResult UpdateInventory(string updateInv, string pizzaId)
    {
      Pizza pizza_ = _sr.GetPizza(pizzaId);
      int new_inventory = _sr.GetStorePizza(currentStore, pizza_).Inventory + Int32.Parse(updateInv);
      _sr.UpdateInventory(currentStore, pizza_, new_inventory);
      
      List<string> listInventory = new List<string>();
      
      foreach (var sp in _sr.GetPerStore(currentStore))
      {
        Pizza pizza = _sr.GetPizza(sp.PizzaId);
        // listInventory.Add(pizza.PizzaId.ToString());
        listInventory.Add(sp.Inventory.ToString());
        listInventory.Add(pizza.Name);
      }

      var s = new StoreViewModel()
      {
        Inventory = listInventory,
        Username = currentStore.Name,
      };
      
      return View("Inventory", s);
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

      var s = new StoreViewModel()
      {
        RevenueAmountPerPizza = listPizzaAmountRevenue,
        TotalAmount = totalAmount,
        TotalRevenue = totalRevenue,
        Username = currentStore.Name
      };
    
      return View("SalesAndRevenue", s);
    }

    [HttpGet]
    public IActionResult LogoutStore()
    {
      var s = new StoreViewModel()
      {
        Username = currentStore.Name
      };
      return View("LogoutStore", s);
    }
  }
}