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
    private static Pizza currentPizza;
    private static List<Pizza> currentListOfPizzas = new List<Pizza>();
    

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
    public IActionResult ChoosePizzeria()
    {
      //List<StoreViewModel> list = new List<StoreViewModel>();
      bool check1 = _ur.HasItBeenMoreThan2Hours(currentUser);
      if (check1)
      {
        List<Store> listPizzerias = _ur.ShowPizzerias();

        var s = new StoreViewModel()
        {
          AllStores = listPizzerias,
          ClientName = currentUser.Name
        };

        return View("ChoosePizzeria", s);
      }
      else
      {
        var s = new StoreViewModel()
        {
          ClientName = currentUser.Name
        };
        
        return View("2HCantMakeOrder", s);
      }
      
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
          bool check2 = _ur.HasItBeenMoreThan24Hours(currentUser, currentStore);
          if (check2)
          {
            var listPizzas = _ur.GetAllPizzas();

            var s = new StoreViewModel()
            {
              Username = currentStore.Name,
              Password = currentStore.Password,
              StoreId = currentStore.StoreId,
              Address = currentStore.Address,
              Pizzas = listPizzas,
              ClientName = currentUser.Name
            };
            
            return View("AddPizza", s);
          }
          else
          {
            var s = new StoreViewModel()
            {
              ClientName = currentUser.Name
            };
            
            return View("24HCantMakeOrder", s);
          }
        }
      }
      List<Store> listPizzerias = _ur.ShowPizzerias();

      var svm = new StoreViewModel()
      {
        AllStores = listPizzerias,
        ClientName = currentUser.Name
      };

      return View("ChoosePizzeria", svm);
    }
    
    [HttpPost]
    public IActionResult PreViewOrder(string pizzaId)
    {

      if (ModelState.IsValid)
      {
        var check = _ur.GetPizza(pizzaId);

        if (check != null)
        {
          currentPizza = _ur.GetPizza(pizzaId);
          List<Pizza> lp = new List<Pizza>();
          lp = currentListOfPizzas;
          lp.Add(currentPizza);
          currentListOfPizzas = lp;
          
          decimal total = 0;
          foreach (var p in currentListOfPizzas)
          {
            string namePizza = _ur.GetNamePizza(p.PizzaId);
            decimal price = _ur.GetPricePizza(p.PizzaId);
            total += price;  
          }

          var o = new OrderViewModel()
          {
            StoreSelected = currentStore,
            ListOfPizzas = currentListOfPizzas,
            Client = currentUser,
            TotalPrice = total
          };

          return View("PreViewOrder", o);
        }
      }
      var listPizzas = _ur.GetAllPizzas();

      var s = new StoreViewModel()
      {
        Username = currentStore.Name,
        Password = currentStore.Password,
        StoreId = currentStore.StoreId,
        Address = currentStore.Address,
        Pizzas = listPizzas,
        ClientName = currentUser.Name
      };
      
      return View("AddPizza", s);
    }

    [HttpGet]
    public IActionResult AddPizza()
    {
      var listPizzas = _ur.GetAllPizzas();

      var s = new StoreViewModel()
      {
        Username = currentStore.Name,
        Password = currentStore.Password,
        StoreId = currentStore.StoreId,
        Address = currentStore.Address,
        Pizzas = listPizzas,
        ClientName = currentUser.Name
      };
      
      return View("AddPizza", s);
    }
    
    [HttpGet]
    public IActionResult CheckOut()
    {
      decimal total = 0;
      foreach (var p in currentListOfPizzas)
      {
        string namePizza = _ur.GetNamePizza(p.PizzaId);
        decimal price = _ur.GetPricePizza(p.PizzaId);
        total += price;  
      }

      var o = new OrderViewModel()
      {
        StoreSelected = currentStore,
        ListOfPizzas = currentListOfPizzas,
        Client = currentUser,
        TotalPrice = total
      };

      _ur.PostOrder(currentStore, currentUser);

      var order = _ur.GetOrders();
      Order ord = order[order.Count-1];
      var dict = _ur.PizzaAmount(currentListOfPizzas);
      foreach (var p in dict)
      {
        _ur.PostOrderPizza(ord, p.Key, p.Value);
      }
      
      return View("CheckOut", o);
    }
    
    [HttpGet]
    public IActionResult History()
    {
      var u = new UserViewModel()
      {
        Name = currentUser.Name,
        Password = currentUser.Password,
        UserId = currentUser.UserId,
        Address = currentUser.Address
      };

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

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _ur.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _ur.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          StoreName = storeName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
          
      }
      return View(listOrders);
    }
    
    [HttpPost]
    public IActionResult Days7Orders(UserViewModel user)
    {
      ViewBag.Message = "Your Order History";

       ViewBag.Name = currentUser;
      
      long tempInt = user.UserId;
      var list = _ur.GetPeriodUser(tempInt, 7);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string storeName = _ur.GetNameStore(order.StoreId);

        List<OrderPizza> listOrderPizza = _ur.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _ur.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _ur.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          StoreName = storeName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
      }
      
      return View(listOrders);
    }

    [HttpPost]
    public IActionResult Days30Orders(UserViewModel user)
    {
      ViewBag.Message = "Your Order History";

       ViewBag.Name = currentUser;
      
      long tempInt = user.UserId;
      var list = _ur.GetPeriodUser(tempInt, 30);
      
      List<OrderViewModel> listOrders = new List<OrderViewModel>();

      int count = 0;

      foreach (var order in list)
      {
        string storeName = _ur.GetNameStore(order.StoreId);

        List<OrderPizza> listOrderPizza = _ur.Get(order);

        Dictionary<string, int> dict = new Dictionary<string, int>();

        List<string> listDict = new List<string>();

        decimal total = 0;
        foreach (var p in listOrderPizza)
        {
          string pizzaName = _ur.GetNamePizza(p.PizzaId);
          listDict.Add(pizzaName);
          listDict.Add((p.Amount).ToString());
          decimal price = _ur.GetPricePizza(p.PizzaId);
          total += price; 
        }

        listOrders.Add(new OrderViewModel
        {
          StoreName = storeName,
          Date = order.Date,
          Count = ++count,
          AmountPizzas = listDict,
          TotalPrice = total
        });
      } 
      return View(listOrders);
    }


  }
}