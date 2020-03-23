using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class StoreTests
  {
     private StoreRepository sut;

    public StoreTests(StoreRepository repository)
    {
      sut = repository;
    }
    
    [Fact]
    public void Test_RepositoryGet()
    {
      var actual = sut.Get();

      Assert.True(actual != null);
      Assert.True(actual.Count >= 0);
    }

    [Theory]
    [InlineData("MiPizza", "pizza")]
    public void Test_RepositoryCheckIfAccountExists(string n, string p)
    {
      var actual = sut.CheckIfAccountExists(n, p);

      Assert.True(actual);
    }

    [Theory]
    [InlineData("MiPizza", "pizza")]
    public void Test_RepositoryGetStore(string n, string p)
    {
      var actual = sut.GetStore(n, p);

      Assert.IsType<Store>(actual);
    }

    [Theory]
    [InlineData(1)]
    public void Test_RepositoryGetStoreByNumMenu(int n)
    {
      var actual = sut.GetStore(n);

      Assert.IsType<Store>(actual);
    }

  }
}