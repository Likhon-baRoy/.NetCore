using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Person
{
  [Required(ErrorMessage = "{0} can't be empty or null")]
  [DisplayName("Person Name")]
  [StringLength(40, MinimumLength = 4, ErrorMessage ="{0} should be between {2} to {1} characters long")]
  public string? PersonName { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Password { get; set; }
  public string? ConfirmPassword { get; set; }

  [Range(0, 999.99, ErrorMessage = "{0} range should be between ${1} and ${2}")]
  public string? Price { get; set; }

  public override string ToString()
  {
    return $"Person object -\nPerson Name: {PersonName}\nEmail: {Email}\nPhone: {Phone}\nPassword: {Password}\nConfirm Password: {ConfirmPassword}\nPrice: {Price}\n";
  }
}
