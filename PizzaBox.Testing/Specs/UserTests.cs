using System.Collections.Generic;
using PizzaBox.Domain.Models;
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

    [Theory]
    [InlineData("Bianca", "bianca")]
    public void Test_RepositoryCheckIfAccountExists(string n, string p)
    {
      var actual = sut.CheckIfAccountExists(n, p);

      Assert.True(actual);
    }

    [Theory]
    [InlineData("Bianca", "bianca")]
    public void Test_RepositoryGetUser(string n, string p)
    {
      var actual = sut.GetUser(n, p);

      Assert.IsType<User>(actual);
    }


  }
}