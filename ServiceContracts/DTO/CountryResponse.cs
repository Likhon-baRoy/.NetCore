using Entities;

namespace ServiceContracts.DTO;

/// <summary>
/// DTO classes that is used as return type for most of ConuntriesService methods
/// </summary>
public class CountryResponse
{
  public Guid CountryID { get; set; }
  public string? CountryName { get; set; }

  // Override the actual values instead of references. It compares the current object to another object of CountryResponse type and returns true, if both values are same; otherwise returns false
  public override bool Equals(object? obj)
  {
    if (obj == null || obj.GetType() != typeof(CountryResponse))
    {
      return false;
    }

    // typecast the obj and store in a variable
    CountryResponse country_to_compare = (CountryResponse)obj;

    return CountryID == country_to_compare.CountryID && CountryName == country_to_compare.CountryName;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}

public static class CountryExtensions
{
  public static CountryResponse ToCountryResponse(this Country country)
  {
    // Converts from Country object to CountryResponse object
    return new CountryResponse()
    {
      CountryID = country.CountryID,
      CountryName = country.CountryName
    };
  }
}
