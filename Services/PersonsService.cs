using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services;

public class PersonsService : IPersonsService
{
  private readonly List<Person> _persons;
  private readonly ICountriesService _countriesService;

  public PersonsService()
  {
    _persons = new List<Person>();
    _countriesService = new CountriesService();
  }

  private PersonResponse ConvertPersonToPersonResponse(Person person)
  {
    PersonResponse personResponse = person.ToPersonResponse();
    personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;

    return personResponse;
  }

  public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
  {
    // check if personAddRequest is not null
    if (personAddRequest == null)
    {
      throw new ArgumentNullException(nameof(personAddRequest)); // name of the parameter which is NULL
    }

    // Model validation
    ValidationHelper.ModelValidation(personAddRequest);

    // Convert personAddRequest into Person type
    Person person = personAddRequest.ToPerson();
    // generate PersonID
    person.PersonID = Guid.NewGuid();
    // add person object to persons list
    _persons.Add(person);

    // convert the Person object into PersonResponse type
    return ConvertPersonToPersonResponse(person);
  }

  public List<PersonResponse> GetAllPersons()
  {
    throw new NotImplementedException();
  }
}
