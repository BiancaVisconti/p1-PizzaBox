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
    

    private UserRepository _ur;

    public UserController(UserRepository repository)
    {
      _ur = repository;
    }
    
    
    [HttpGet]
    public IActionResult LoginUser()
    {
      return View();
    }

    [HttpPost]
    public IActionResult LoginUser(UserViewModel user)
    {
      
      if (ModelState.IsValid)
      {
        var acct = _ur.CheckIfAccountExists(user.Name, user.Password);

        if (acct)
        {
          currentUser = _ur.GetUser(user.Name, user.Password);

          var u = new UserViewModel()
          {
            Name = currentUser.Name,
            Password = currentUser.Password,
            UserId = currentUser.UserId,
            Address = currentUser.Address
          };
          
          return View("UserOptions", u);
        }
      }
      return View(user);
    }
    
    [HttpPost]
    public IActionResult MenuClient(UserViewModel user)
    {
      var u = _ur.GetUser(user.Name, user.Password);

      ViewBag.Message = u;
      
      return View("UserOptions");
    }
    
    [HttpGet]
    public IActionResult History()
    {
      
      //var u = _ur.GetUser(userId);

      //var u = _ur.GetUser(user.Name, user.Password);

      var u = new UserViewModel()
      {
        Name = currentUser.Name,
        Password = currentUser.Password,
        UserId = currentUser.UserId,
        Address = currentUser.Address
      };

      //ViewBag.Message = u;
      
      return View("UserPastOrdersOptions", u);
    }

    [HttpPost]
    public IActionResult ClientAllOrders(UserViewModel user)
    {
       ViewBag.Message = "Your Order History";

       ViewBag.Name = currentUser;
      
      long tempInt = user.UserId;
      var list = _ur.GetOrders(tempInt);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string storeName = _ur.GetNameStore(order.StoreId);

        List<OrderPizza> listOrderPizza = _ur.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        foreach (var p in listOrderPizza)
        {
          string pizzaName = _ur.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
        }

        listOrders.Add(new OrderViewModel
        {
            StoreName = storeName,
            Date = order.Date,
            Count = ++count,
            AmountPizzas = listDict
        });
          
      }
      return View(listOrders);
    }

    [HttpGet]
    public IActionResult ChoosePizzeria()
    {
      /*List<StoreViewModel> list = new List<StoreViewModel>();
      
      List<Store> listPizzerias = _ur.ShowPizzerias();

      foreach (var p in listPizzerias)
      {
        list.Add(new StoreViewModel
        {
            StoreId = p.StoreId,
            Username = p.Name
        });
      }*/
      
      return View();
    }

    [HttpPost]
    public IActionResult ChoosePizzeria(string storeId)
    {
      if (ModelState.IsValid)
      {
        var acct = _ur.GetStoreById(storeId);

        if (acct != null)
        {
          currentStore = _ur.GetStoreById(storeId);

          var s = new StoreViewModel()
          {
            Username = currentStore.Name,
            Password = currentStore.Password,
            StoreId = currentStore.StoreId,
            Address = currentStore.Address
          };
          
          return View("AddPizza", s);
        }
      }
      return View();
    }

    [HttpPost]
    public IActionResult Days7Orders(UserViewModel user)
    {
      
      
      return View("UserPastOrdersOptions");
    }

    [HttpPost]
    public IActionResult Days30Orders(UserViewModel user)
    {
      return View("UserPastOrdersOptions");
    }


  }
}