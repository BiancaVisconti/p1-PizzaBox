using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class AccountViewModel
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool User { get; set; }
  }
}