using PizzaBox.Domain.Abstracts;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storing.Repositories
{
  public abstract class ARepository<T> where T : AModel
  {
    
    private PizzaBoxDbContext _db;
    
    public ARepository(PizzaBoxDbContext dbContext)
    {
      _db = dbContext;
    }
    
    //protected static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

  }
}