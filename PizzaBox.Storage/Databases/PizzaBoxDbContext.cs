using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Storage.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderPizza> OrderPizza { get; set; }
    public DbSet<StorePizza> StorePizza { get; set; }

    public PizzaBoxDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) 
    {
      builder.Entity<User>().HasKey(u => u.UserId);

      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);

      builder.Entity<User>().Property(u => u.UserId).ValueGeneratedNever();

      builder.Entity<User>().HasData(new User[]
      {
        new User() { UserId = 1, Name = "Bianca", Password = "bianca", Address = "Central 960"},
        new User() { UserId = 2, Name = "Silvana", Password = "silvana", Address = "Street 4250"},
        new User() { UserId = 3, Name = "Macarena", Password = "maca", Address = "Calle 13"},
        new User() { UserId = 4, Name = "Victoria", Password = "vicky", Address = "3 Poniente"},
        new User() { UserId = 5, Name = "Rufuz", Password = "beio", Address = "Avenida Beio 15"},
        new User() { UserId = 6, Name = "NancyCastro", Password = "nancy", Address = "15 Norte"},
        new User() { UserId = 7, Name = "Jenny", Password = "jenny", Address = "Avenida Beio 15"},
        new User() { UserId = 8, Name = "Fernanda", Password = "ferna", Address = "Blanca Estela 76"},
        new User() { UserId = 9, Name = "Francisca", Password = "fran", Address = "Los Pellines 950"},
        new User() { UserId = 10, Name = "Sofia", Password = "sofia", Address = "Lomas de Montenar 1190"}
      });

      builder.Entity<Store>().HasKey(s => s.StoreId);

      builder.Entity<Store>().HasMany(s => s.Orders).WithOne(o => o.Store);

      builder.Entity<Store>().HasMany(s => s.StorePizzas).WithOne(sp => sp.Store);

      builder.Entity<Store>().Property(s => s.StoreId).ValueGeneratedNever();

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { StoreId = 1, Name = "PizzaEater", Password = "eater", Address = "Cooper 786"},
        new Store() { StoreId = 2, Name = "DiegoPizza", Password = "diego", Address = "Mitchel 83"},
        new Store() { StoreId = 3, Name = "MiPizza", Password = "pizza", Address = "Mesquite 476"},
        new Store() { StoreId = 4, Name = "TuPizza", Password = "pizza", Address = "Abram 34"},
        new Store() { StoreId = 5, Name = "Mangiata", Password = "comer", Address = "Cooper 132"},
        new Store() { StoreId = 6, Name = "PizzaLover", Password = "pizza", Address = "Mesquite 87"}
        
      });

      builder.Entity<Order>().HasKey(o => o.OrderId);

      builder.Entity<Order>().HasMany(o => o.OrderPizzas).WithOne(op => op.Order);

      builder.Entity<Order>().Property(o => o.OrderId).ValueGeneratedNever();

      builder.Entity<Order>().HasData(new Order[]
      {
        new Order() { OrderId = 1, Date = new DateTime(2019, 11, 01, 07, 09, 14), StoreId = 1, UserId = 1},
        new Order() { OrderId = 2, Date = new DateTime(2019, 11, 17, 07, 09, 14), StoreId = 2, UserId = 2},
        new Order() { OrderId = 3, Date = new DateTime(2019, 12, 05, 07, 09, 14), StoreId = 1, UserId = 2},
        new Order() { OrderId = 4, Date = new DateTime(2019, 12, 06, 23, 00, 00), StoreId = 1, UserId = 7},
        new Order() { OrderId = 5, Date = new DateTime(2019, 12, 31, 15, 09, 00), StoreId = 2, UserId = 2},
        new Order() { OrderId = 6, Date = new DateTime(2020, 01, 10, 15, 00, 00), StoreId = 6, UserId = 9},
        new Order() { OrderId = 7, Date = new DateTime(2020, 02, 24, 12, 30, 00), StoreId = 5, UserId = 10},
        new Order() { OrderId = 8, Date = new DateTime(2020, 03, 01, 14, 25, 00), StoreId = 4, UserId = 1},
        new Order() { OrderId = 9, Date = new DateTime(2020, 03, 22, 22, 00, 00), StoreId = 3, UserId = 2}
      });
      
      
      builder.Entity<OrderPizza>().HasKey(op => op.OrderPizzaId);

      builder.Entity<OrderPizza>().Property(op => op.OrderPizzaId).ValueGeneratedNever();

      builder.Entity<OrderPizza>().HasData(new OrderPizza[]
      {
        new OrderPizza() { OrderPizzaId = 1, OrderId = 1, PizzaId = 3, Amount = 2},
        new OrderPizza() { OrderPizzaId = 2, OrderId = 1, PizzaId = 5, Amount = 3},
        new OrderPizza() { OrderPizzaId = 3, OrderId = 2, PizzaId = 2, Amount = 1},
        new OrderPizza() { OrderPizzaId = 4, OrderId = 3, PizzaId = 4, Amount = 1},
        new OrderPizza() { OrderPizzaId = 5, OrderId = 4, PizzaId = 6, Amount = 2},
        new OrderPizza() { OrderPizzaId = 6, OrderId = 5, PizzaId = 2, Amount = 1},
        new OrderPizza() { OrderPizzaId = 7, OrderId = 6, PizzaId = 7, Amount = 3},
        new OrderPizza() { OrderPizzaId = 8, OrderId = 6, PizzaId = 8, Amount = 1},
        new OrderPizza() { OrderPizzaId = 9, OrderId = 7, PizzaId = 9, Amount = 7},
        new OrderPizza() { OrderPizzaId = 10, OrderId = 7, PizzaId = 6, Amount = 2},
        new OrderPizza() { OrderPizzaId = 11, OrderId = 8, PizzaId = 5, Amount = 3},
        new OrderPizza() { OrderPizzaId = 12, OrderId = 8, PizzaId = 1, Amount = 1},
        new OrderPizza() { OrderPizzaId = 13, OrderId = 9, PizzaId = 9, Amount = 2},
        new OrderPizza() { OrderPizzaId = 14, OrderId = 9, PizzaId = 7, Amount = 1}
      });
      
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);

      builder.Entity<Pizza>().HasMany(p => p.OrderPizzas).WithOne(op => op.Pizza);

      builder.Entity<Pizza>().HasMany(p => p.StorePizzas).WithOne(sp => sp.Pizza);
      
      builder.Entity<Pizza>().Property(p => p.PizzaId).ValueGeneratedNever();
      
      builder.Entity<Pizza>().HasData(new Pizza[]
      {
        new Pizza() { PizzaId = 1, Name = "Small Hawaiian Pizza", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 5.00M},
        new Pizza() { PizzaId = 2, Name = "Medium Hawaiian Pizza", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 9.50M},
        new Pizza() { PizzaId = 3, Name = "Large Hawaiian Pizza", Description = "thin crust, tomato sauce, vegan cheese, pineapple, green pepper, onions", Price = 13.90M},
        new Pizza() { PizzaId = 4, Name = "Small Exquisite Pizza", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 6.00M},
        new Pizza() { PizzaId = 5, Name = "Medium Exquisite Pizza", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 11.00M},
        new Pizza() { PizzaId = 6, Name = "Large Exquisite Pizza", Description = "flatbread, tomato sauce, vegan cheese, tomatos, avocado, tofu, onions", Price = 15.50M},
        new Pizza() { PizzaId = 7, Name = "Small Delicious Pizza", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 5.50M},
        new Pizza() { PizzaId = 8, Name = "Medium Delicious Pizza", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 10.50M},
        new Pizza() { PizzaId = 9, Name = "Large Delicious Pizza", Description = "thick crust, pesto sauce, vegan cheese, onions, red pepper, mushrooms", Price = 16.50M},
        new Pizza() { PizzaId = 10, Name = "Giant Super Pizza", Description = "thick crust, tomato sauce, tomate, pineapple, avocado", Price = 59.90M}
      });


      builder.Entity<StorePizza>().HasKey(sp => sp.StorePizzaId);

      builder.Entity<StorePizza>().Property(sp => sp.StorePizzaId).ValueGeneratedNever();

      builder.Entity<StorePizza>().HasData(new StorePizza[]
      {
        new StorePizza() { StorePizzaId = 1, StoreId = 1, PizzaId = 1, Inventory = 5},
        new StorePizza() { StorePizzaId = 2, StoreId = 1, PizzaId = 2, Inventory = 2},
        new StorePizza() { StorePizzaId = 3, StoreId = 1, PizzaId = 3, Inventory = 5},
        new StorePizza() { StorePizzaId = 4, StoreId = 1, PizzaId = 4, Inventory = 2},
        new StorePizza() { StorePizzaId = 5, StoreId = 1, PizzaId = 5, Inventory = 3},
        new StorePizza() { StorePizzaId = 6, StoreId = 1, PizzaId = 6, Inventory = 8},
        new StorePizza() { StorePizzaId = 7, StoreId = 1, PizzaId = 7, Inventory = 1},
        new StorePizza() { StorePizzaId = 8, StoreId = 1, PizzaId = 8, Inventory = 9},
        new StorePizza() { StorePizzaId = 9, StoreId = 1, PizzaId = 9, Inventory = 2},
        new StorePizza() { StorePizzaId = 10, StoreId = 1, PizzaId = 10, Inventory = 10},
        new StorePizza() { StorePizzaId = 11, StoreId = 2, PizzaId = 1, Inventory = 4},
        new StorePizza() { StorePizzaId = 12, StoreId = 2, PizzaId = 2, Inventory = 1},
        new StorePizza() { StorePizzaId = 13, StoreId = 2, PizzaId = 3, Inventory = 7},
        new StorePizza() { StorePizzaId = 14, StoreId = 2, PizzaId = 4, Inventory = 5},
        new StorePizza() { StorePizzaId = 15, StoreId = 2, PizzaId = 5, Inventory = 13},
        new StorePizza() { StorePizzaId = 16, StoreId = 2, PizzaId = 6, Inventory = 20},
        new StorePizza() { StorePizzaId = 17, StoreId = 2, PizzaId = 7, Inventory = 21},
        new StorePizza() { StorePizzaId = 18, StoreId = 2, PizzaId = 8, Inventory = 20},
        new StorePizza() { StorePizzaId = 19, StoreId = 2, PizzaId = 9, Inventory = 8},
        new StorePizza() { StorePizzaId = 20, StoreId = 2, PizzaId = 10, Inventory = 10},
        new StorePizza() { StorePizzaId = 21, StoreId = 3, PizzaId = 1, Inventory = 14},
        new StorePizza() { StorePizzaId = 22, StoreId = 3, PizzaId = 2, Inventory = 17},
        new StorePizza() { StorePizzaId = 23, StoreId = 3, PizzaId = 3, Inventory = 34},
        new StorePizza() { StorePizzaId = 24, StoreId = 3, PizzaId = 4, Inventory = 25},
        new StorePizza() { StorePizzaId = 25, StoreId = 3, PizzaId = 5, Inventory = 27},
        new StorePizza() { StorePizzaId = 26, StoreId = 3, PizzaId = 6, Inventory = 12},
        new StorePizza() { StorePizzaId = 27, StoreId = 3, PizzaId = 7, Inventory = 13},
        new StorePizza() { StorePizzaId = 28, StoreId = 3, PizzaId = 8, Inventory = 14},
        new StorePizza() { StorePizzaId = 29, StoreId = 3, PizzaId = 9, Inventory = 3},
        new StorePizza() { StorePizzaId = 30, StoreId = 3, PizzaId = 10, Inventory = 5},
        new StorePizza() { StorePizzaId = 31, StoreId = 4, PizzaId = 1, Inventory = 10},
        new StorePizza() { StorePizzaId = 32, StoreId = 4, PizzaId = 2, Inventory = 3},
        new StorePizza() { StorePizzaId = 33, StoreId = 4, PizzaId = 3, Inventory = 1},
        new StorePizza() { StorePizzaId = 34, StoreId = 4, PizzaId = 4, Inventory = 6},
        new StorePizza() { StorePizzaId = 35, StoreId = 4, PizzaId = 5, Inventory = 2},
        new StorePizza() { StorePizzaId = 36, StoreId = 4, PizzaId = 6, Inventory = 2},
        new StorePizza() { StorePizzaId = 37, StoreId = 4, PizzaId = 7, Inventory = 2},
        new StorePizza() { StorePizzaId = 38, StoreId = 4, PizzaId = 8, Inventory = 2},
        new StorePizza() { StorePizzaId = 39, StoreId = 4, PizzaId = 9, Inventory = 2},
        new StorePizza() { StorePizzaId = 40, StoreId = 4, PizzaId = 10, Inventory = 10},
        new StorePizza() { StorePizzaId = 41, StoreId = 5, PizzaId = 1, Inventory = 2},
        new StorePizza() { StorePizzaId = 42, StoreId = 5, PizzaId = 2, Inventory = 3},
        new StorePizza() { StorePizzaId = 43, StoreId = 5, PizzaId = 3, Inventory = 4},
        new StorePizza() { StorePizzaId = 44, StoreId = 5, PizzaId = 4, Inventory = 6},
        new StorePizza() { StorePizzaId = 45, StoreId = 5, PizzaId = 5, Inventory = 7},
        new StorePizza() { StorePizzaId = 46, StoreId = 5, PizzaId = 6, Inventory = 2},
        new StorePizza() { StorePizzaId = 47, StoreId = 5, PizzaId = 7, Inventory = 9},
        new StorePizza() { StorePizzaId = 48, StoreId = 5, PizzaId = 8, Inventory = 1},
        new StorePizza() { StorePizzaId = 49, StoreId = 5, PizzaId = 9, Inventory = 6},
        new StorePizza() { StorePizzaId = 50, StoreId = 5, PizzaId = 10, Inventory = 10},
        new StorePizza() { StorePizzaId = 51, StoreId = 6, PizzaId = 1, Inventory = 4},
        new StorePizza() { StorePizzaId = 52, StoreId = 6, PizzaId = 2, Inventory = 3},
        new StorePizza() { StorePizzaId = 53, StoreId = 6, PizzaId = 3, Inventory = 7},
        new StorePizza() { StorePizzaId = 54, StoreId = 6, PizzaId = 4, Inventory = 5},
        new StorePizza() { StorePizzaId = 55, StoreId = 6, PizzaId = 5, Inventory = 4},
        new StorePizza() { StorePizzaId = 56, StoreId = 6, PizzaId = 6, Inventory = 2},
        new StorePizza() { StorePizzaId = 57, StoreId = 6, PizzaId = 7, Inventory = 2},
        new StorePizza() { StorePizzaId = 58, StoreId = 6, PizzaId = 8, Inventory = 7},
        new StorePizza() { StorePizzaId = 59, StoreId = 6, PizzaId = 9, Inventory = 8},
        new StorePizza() { StorePizzaId = 60, StoreId = 6, PizzaId = 10, Inventory = 10}
      });
    }
  }
}