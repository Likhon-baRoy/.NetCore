using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebApp.CustomValidators;

public class DateRangeValidatorAttribute : ValidationAttribute
{
  public string OtherPropertyName { get; set; }

  public DateRangeValidatorAttribute(string otherPropertyName)
  {
    OtherPropertyName = otherPropertyName;
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value != null)
    {
      // get to_date
      DateTime to_date = (DateTime)value;

      // get from_date
      PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

      if (otherProperty != null)
      {
        DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

        if (from_date > to_date)
        {
          // format error message with property names
          string message = FormatErrorMessage(validationContext.DisplayName);
          return new ValidationResult(message);
        }
        return ValidationResult.Success;
      }
      return null;
    }
    return null;
  }

  public override string FormatErrorMessage(string name)
  {
    // name = current property display name (ToDate)
    // OtherPropertyName = property name we are comparing to (FromDate)
    return string.Format(ErrorMessageString, name, OtherPropertyName);
  }
}
