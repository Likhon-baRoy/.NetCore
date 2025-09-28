using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApp.Models;

public class Person
{
  [Required(ErrorMessage = "{0} can't be empty or null")]
  [DisplayName("Person Name")]
  [StringLength(40, MinimumLength = 4, ErrorMessage = "{0} should be between {2} to {1} characters long")]
  [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
  public string? PersonName { get; set; }

  [Required()]
  [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
  public string? Email { get; set; }

  [Phone(ErrorMessage = "{0} is not a proper mobile number")]
  public string? Phone { get; set; }

  [Required(ErrorMessage = "{0} can't be blank")]
  public string? Password { get; set; }

  [Required(ErrorMessage = "{0} can't be blank")]
  [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
  public string? ConfirmPassword { get; set; }

  [ValidateNever] // if surpass the validation for specific field!
  [Range(0, 999.99, ErrorMessage = "{0} range should be between ${1} and ${2}")]
  public string? Price { get; set; }

  public override string ToString()
  {
    return $"Person object -\nPerson Name: {PersonName}\nEmail: {Email}\nPhone: {Phone}\nPassword: {Password}\nConfirm Password: {ConfirmPassword}\nPrice: {Price}\n";
  }
}
