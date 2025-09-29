using System.ComponentModel.DataAnnotations;

namespace WebApp.CustomValidators;

public class MinimumYearValidatorAttribute : ValidationAttribute
{
  public int MinimumYear { get; set; } = 2000; // default value in-case user does not supply the minimum year
  public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";

  // parameterless constructor
  public MinimumYearValidatorAttribute()
  {

  }

  // parameterized constructor
  public MinimumYearValidatorAttribute(int minimumYear)
  {
    MinimumYear = minimumYear;
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value != null)
    {
      DateTime date = (DateTime)value;
      if (date.Year >= MinimumYear)
      {
        return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, validationContext.DisplayName, MinimumYear));
      }
      else
      {
        return ValidationResult.Success;
      }
    }

    return null;
  }
}
