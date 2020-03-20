namespace PizzaBox.Domain.Abstracts
{
  public abstract class ASuperUser : AModel
  {
    public string Name { get; set; }

    public string Password { get; set; }

    public string Address { get; set; }
 
  }
}