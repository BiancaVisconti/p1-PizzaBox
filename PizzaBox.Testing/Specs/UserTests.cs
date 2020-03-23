using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Specs
{
  public class UserTests
  {
    private UserRepository sut;

    public UserTests(UserRepository repository)
    {
      sut = repository;
    }

    // [Fact]
    // public void Test_RepositoryGet()
    // {
    //   var actual = sut.Get();

    //   Assert.True(actual != null);
    //   Assert.True(actual.Count >= 0);
    // }
  }
}