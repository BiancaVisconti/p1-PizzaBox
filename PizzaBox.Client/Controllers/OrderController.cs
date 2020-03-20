using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private PizzaBoxRepository _pbr;

    public OrderController(PizzaBoxRepository repository)
    {
      _pbr = repository;
    }
  }
}