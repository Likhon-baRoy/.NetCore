using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class Person
{
  [Required(ErrorMessage = "Person Name can't be empty or null")]
  public string? PersonName { get; set; }
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public string? Password { get; set; }
  public string? ConfirmPassword { get; set; }
  public string? Price { get; set; }

  public override string ToString()
  {
    return $"Person object -\nPerson Name: {PersonName}\nEmail: {Email}\nPhone: {Phone}\nPassword: {Password}\nConfirm Password: {ConfirmPassword}\nPrice: {Price}\n";
  }
}
