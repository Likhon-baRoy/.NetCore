using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApp.CustomValidators;

namespace WebApp.Models;

public class Person : IValidatableObject
{
  [Required(ErrorMessage = "{0} can't be empty or null")]
  [Display(Name = "Person Name", Prompt = "Enter the person full name", Description = "For registration we've to keep person name record")]
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

  [MinimumYearValidator(2005, ErrorMessage = "{0} should not be newer than Jan 01, {1}")]
  public DateTime? DateOfBirth { get; set; }

  [BindNever] // exempt only this field from binding
  public int? Age { get; set; }
  public DateTime FromDate { get; set; }

  [DateRangeValidator("FromDate", ErrorMessage = "{0} should be older than or equal to {1}")]
  public DateTime ToDate { get; set; }

  public override string ToString()
  {
    return $"Person object -\nPerson Name: {PersonName}\nEmail: {Email}\nPhone: {Phone}\nPassword: {Password}\nConfirm Password: {ConfirmPassword}\nPrice: {Price}\n";
  }

  public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
  {
    if (DateOfBirth.HasValue == false && Age.HasValue == false)
    {
      yield return new ValidationResult("Either of DateOfBirth or Age should be supplied", new[] { nameof(Age) });
    }
  }
}
