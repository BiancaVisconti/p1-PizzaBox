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
    private static Pizza currentPizza;
    private static decimal currentTotalPrice;
    private static decimal currentTotalAmount;
    private static List<Pizza> currentListOfPizzas = new List<Pizza>();

    private static Dictionary<long, int> currentPizzaDict = new Dictionary<long, int>();
 
    
    
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
            List<StorePizza> listStorePizza = _ur.GetPizzasInStore(currentStore);
            currentPizzaDict = new Dictionary<long, int>();
            foreach (var p in listStorePizza)
            {
              currentPizzaDict.Add(p.PizzaId, p.Inventory);
            }
            
            List<Pizza> listPizzas = _ur.ShowMenu(currentPizzaDict);
            
            //var listPizzas = _ur.GetAllPizzas();

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
        bool check = _ur.CheckIfNumMenuPizzaIsValid(pizzaId, currentPizzaDict);

        //decimal price_ = _ur.GetPricePizza(pizzaId);
        
        //var check = _ur.GetPizza(pizzaId);

        if (check)
        {
          currentPizza = _ur.GetPizza(pizzaId);
          currentPizzaDict[currentPizza.PizzaId]--;
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

          currentTotalPrice = total;

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
      
      List<Pizza> listPizzas = _ur.ShowMenu(currentPizzaDict);
      
      //var listPizzas = _ur.GetAllPizzas();

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
      
      List<Pizza> listPizzas = _ur.ShowMenu(currentPizzaDict);
      

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
    public IActionResult RemovePizza()
    {
      if (currentListOfPizzas.Count > 0)
      {
        Pizza pizza = currentListOfPizzas[currentListOfPizzas.Count - 1];
        currentPizzaDict[pizza.PizzaId]++;
        currentListOfPizzas.RemoveAt(currentListOfPizzas.Count -1);

        currentTotalPrice -= pizza.Price;
        
        var o = new OrderViewModel()
        {
          StoreSelected = currentStore,
          ListOfPizzas = currentListOfPizzas,
          Client = currentUser,
          TotalPrice = currentTotalPrice
        };

        return View("PreViewOrder", o);
      }
      else
      {
        var o = new OrderViewModel()
        {
          StoreSelected = currentStore,
          ListOfPizzas = currentListOfPizzas,
          Client = currentUser,
          TotalPrice = currentTotalPrice
        };
        
        return View("CantRemovePizza", o);
      }
    }
    
    [HttpGet]
    public IActionResult CheckOut()
    {
      if (currentListOfPizzas.Count > 0)
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
          int old_inventory = _ur.GetInventory(currentStore, p.Key);
          int new_inventory = old_inventory - p.Value;
          _ur.UpdateInventory(currentStore, p.Key, new_inventory); 
        }
        
        return View("CheckOut", o);
      }
      else
      {
        return View("UserOptions");
      }
      
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
      return View("ClientAllOrders", listOrders);
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
      
      return View("Days7Orders", listOrders);
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
      return View("Days30Orders", listOrders);
    }

    [HttpGet]
    public IActionResult LogoutUser()
    {
      var u = new UserViewModel()
      {
        Name = currentUser.Name
      };
      return View("LogoutUser", u);
    }


  }
}