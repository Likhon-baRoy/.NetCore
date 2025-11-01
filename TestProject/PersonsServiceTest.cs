using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;

namespace TestProject;

public class PersonsServiceTest
{
  // private fields
  private readonly IPersonsService _personsService;
  private readonly ICountriesService _countriesService;

  // constructor
  public PersonsServiceTest()
  {
    _personsService = new PersonsService();
    _countriesService = new CountriesService();
  }

  #region AddPerson

  // When we supply null value as PersonAddRequest, it should throw ArgumentNullException
  [Fact]
  public void AddPerson_NullPerson()
  {
    // Arrage
    PersonAddRequest? personAddRequest = null;

    // Act
    Assert.Throws<ArgumentNullException>(() =>
    {
      _personsService.AddPerson(personAddRequest);
    });
  }

  // When we supply null value as PersonName, it should throw ArgumentException
  [Fact]
  public void AddPerson_PersonNameIsNull()
  {
    // Arrage
    PersonAddRequest? personAddRequest = new PersonAddRequest()
    {
      PersonName = null
    };

    // Act
    Assert.Throws<ArgumentException>(() =>
    {
      _personsService.AddPerson(personAddRequest);
    });
  }

  // When we supply proper Person details, it should insert the person into the persons list; and it should return an object of PersonResponse, which includes with the newly generated person ID
  [Fact]
  public void AddPerson_ProperPersonDetails()
  {
    // Arrage
    PersonAddRequest? personAddRequest = new PersonAddRequest()
    {
      PersonName = "Person Name...",
      Email = "person@example.com",
      Address = "sample address",
      CountryID = Guid.NewGuid(),
      Gender = GenderOptions.Male,
      DateOfBirth = DateTime.Parse("2000-01-01"),
      ReceiveNewsLetters = true
    };

    // Act
    PersonResponse person_response_from_add = _personsService.AddPerson(personAddRequest);

    List<PersonResponse> person_list = _personsService.GetAllPersons();

    // Assert
    Assert.True(person_response_from_add.PersonID != Guid.Empty);
    Assert.Contains(person_response_from_add, person_list);
  }
  #endregion

  #region GetPersonByPersonID

  // If we supply null as PersonID, it should return null as PersonResponse
  [Fact]
  public void GetPersonByPersonID_NullPersonID()
  {
    // Arrange
    Guid? personID = null;

    // Act
    PersonResponse? person_response_from_get = _personsService.GetPersonByPersonID(personID);

    // Assert
    Assert.Null(person_response_from_get);
  }

  // If we supply a valid person id, it should return the valid person details PersonResponse object
  [Fact]
  public void GetPersonByPersonID_WithPersonID()
  {
    // Arrange
    CountryAddRequest country_request = new CountryAddRequest()
    {
      CountryName = "Canada"
    };
    CountryResponse country_response = _countriesService.AddCountry(country_request);

    // Act
    PersonAddRequest? person_request = new PersonAddRequest()
    {
      PersonName = "Person Name...",
      Email = "email@sample.com",
      Address = "sample address",
      CountryID = country_response.CountryID,
      DateOfBirth = DateTime.Parse("2000-01-01"),
      Gender = GenderOptions.Male,
      ReceiveNewsLetters = false
    };

    PersonResponse person_response_from_add = _personsService.AddPerson(person_request);
    PersonResponse? person_response_from_get = _personsService.GetPersonByPersonID(person_response_from_add.PersonID);

    // Assert
    Assert.Equal(person_response_from_add, person_response_from_get);
  }

  #endregion
}
