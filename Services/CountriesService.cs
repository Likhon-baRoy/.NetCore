using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
  private readonly List<Country> _countries;

  public CountriesService(bool initialize = true)
  {
    _countries = new List<Country>();

    if (initialize)
    {
      _countries.AddRange(new List<Country>() {
      new Country()
      {
        CountryID = Guid.Parse("c780c999-8945-480d-ab02-3c0d2c0836d6"),
        CountryName = "USA"
      },
      new Country()
      {
        CountryID = Guid.Parse("1f7294c7-940a-423d-b5c1-d09d8caf0c19"),
        CountryName = "Canada"
      },
      new Country()
      {
        CountryID = Guid.Parse("4c83e5bb-df23-49d2-8d0a-e7616d336564"),
        CountryName = "UK"
      },
      new Country()
      {
        CountryID = Guid.Parse("a4d39121-5788-4fa5-8e14-fe3781617862"),
        CountryName = "Bangladesh"
      },
      new Country()
      {
        CountryID = Guid.Parse("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3"),
        CountryName = "India"
      }
      });
    }
  }

  public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
  {
    // Validation: countryAddRequest parameter can't be null
    if (countryAddRequest == null)
    {
      throw new ArgumentNullException(nameof(countryAddRequest));
    }

    // Validation: CountryName can't be null
    if (countryAddRequest.CountryName == null)
    {
      throw new ArgumentException(nameof(countryAddRequest.CountryName));
    }

    // Validation: CountryName can't be duplicate
    if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
    {
      throw new ArgumentException("Given country name already exists");
    }

    // Convert object from CountryAddRequest to Country type
    Country country = countryAddRequest.ToCountry();

    // generate CountryID
    country.CountryID = Guid.NewGuid();

    // Add country object into _countries
    _countries.Add(country);

    return country.ToCountryResponse();
  }

  public List<CountryResponse> GetAllCountries()
  {
    return _countries.Select(country => country.ToCountryResponse()).ToList();
  }

  public CountryResponse? GetCountryByCountryID(Guid? countryID)
  {
    if (countryID == null)
      return null;

    Country? country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryID == countryID);

    return country_response_from_list?.ToCountryResponse();
  }
}
