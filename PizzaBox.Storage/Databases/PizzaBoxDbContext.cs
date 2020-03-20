using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

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
    
    // public DbSet<Crust> Crust { get; set; }
    // public DbSet<Size> Size { get; set; }
    // public DbSet<Topping> Topping { get; set; }

    public PizzaBoxDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) {}

  }
}