using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;

namespace Services;

public class PersonsService : IPersonsService
{
  private readonly List<Person> _persons;
  private readonly ICountriesService _countriesService;

  public PersonsService(bool initialize = true)
  {
    _persons = new List<Person>();
    _countriesService = new CountriesService();

    if (initialize)
    {
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("37faf028-80b3-4471-8201-49b742e2f384"),
        PersonName = "Kate",
        Email = "kgilbart0@privacy.gov.au",
        DateOfBirth = DateTime.Parse("2000-04-15"),
        Gender = "Female",
        Address = "9367 Burrows Place",
        ReceiveNewsLetters = false,
        CountryID = Guid.Parse("c780c999-8945-480d-ab02-3c0d2c0836d6")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("b6478104-7ff7-4f12-a22a-657d77db5bff"),
        PersonName = "Linoel",
        Email = "lthickens1@nifty.com",
        DateOfBirth = DateTime.Parse("1999-01-02"),
        Gender = "Male",
        Address = "62359 Veith Point",
        ReceiveNewsLetters = true,
        CountryID = Guid.Parse("1f7294c7-940a-423d-b5c1-d09d8caf0c19")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("f47f89c5-98a4-48b3-b2d1-7909758578a7"),
        PersonName = "Sonya",
        Email = "skix2@fotki.com",
        DateOfBirth = DateTime.Parse("1990-06-07"),
        Gender = "Female",
        Address = "948 Summer Ridge Circle",
        ReceiveNewsLetters = false,
        CountryID = Guid.Parse("4c83e5bb-df23-49d2-8d0a-e7616d336564")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("ea268eaa-b13a-4dee-8c20-79270ec7803e"),
        PersonName = "Agnella",
        Email = "agumary3@hubpages.com",
        DateOfBirth = DateTime.Parse("1995-12-21"),
        Gender = "Female",
        Address = "5 Crowley Circle",
        ReceiveNewsLetters = false,
        CountryID = Guid.Parse("a4d39121-5788-4fa5-8e14-fe3781617862")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("eaf29c21-76f5-430d-b38f-c903d8c0fc1c"),
        PersonName = "Courtney",
        Email = "cgrafton4@squarespace.com",
        DateOfBirth = DateTime.Parse("1999-07-29"),
        Gender = "Female",
        Address = "91217 Sycamore Circle",
        ReceiveNewsLetters = true,
        CountryID = Guid.Parse("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("33f2c278-20e3-448a-a501-042f31571012"),
        PersonName = "Davey",
        Email = "dfrye5@epa.gov",
        DateOfBirth = DateTime.Parse("1995-04-03"),
        Gender = "Male",
        Address = "56945 Dennis Road",
        ReceiveNewsLetters = true,
        CountryID = Guid.Parse("43d44ee4-0f3b-4a57-8aa3-fa7900494fa3")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("66ec3051-1d0b-4434-9bc8-2ed833503f9b"),
        PersonName = "Earl",
        Email = "elaxtonne6@ihg.com",
        DateOfBirth = DateTime.Parse("1997-09-16"),
        Gender = "Male",
        Address = "86 Leroy Trail",
        ReceiveNewsLetters = true,
        CountryID = Guid.Parse("a4d39121-5788-4fa5-8e14-fe3781617862")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("59e3a9e6-07cd-4205-8b49-1a12418cef5f"),
        PersonName = "Flinn",
        Email = "ffrow7@marketwatch.com",
        DateOfBirth = DateTime.Parse("1994-08-25"),
        Gender = "Male",
        Address = "7397 Elmside Parkway",
        ReceiveNewsLetters = true,
        CountryID = Guid.Parse("4c83e5bb-df23-49d2-8d0a-e7616d336564")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("0b3b2afd-dd72-4656-930b-02696ae1809b"),
        PersonName = "Elyssa",
        Email = "efroome8@yandex.ru",
        DateOfBirth = DateTime.Parse("1994-07-31"),
        Gender = "Female",
        Address = "1 Cordelia Junction",
        ReceiveNewsLetters = false,
        CountryID = Guid.Parse("1f7294c7-940a-423d-b5c1-d09d8caf0c19")
      });
      _persons.Add(new Person()
      {
        PersonID = Guid.Parse("7601b84c-5187-45fb-9090-59e44fced8a9"),
        PersonName = "Ettie",
        Email = "ewanden9@reddit.com",
        DateOfBirth = DateTime.Parse("1994-12-13"),
        Gender = "Female",
        Address = "5 Rowland Parkway",
        ReceiveNewsLetters = false,
        CountryID = Guid.Parse("c780c999-8945-480d-ab02-3c0d2c0836d6")
      });
    }
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
    return _persons.Select(temp => temp.ToPersonResponse()).ToList();
  }

  public PersonResponse? GetPersonByPersonID(Guid? personID)
  {
    if (personID == null)
      return null;

    Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);

    if (person == null)
      return null;

    return person.ToPersonResponse();
  }

  public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
  {
    List<PersonResponse> allPersons = GetAllPersons();
    List<PersonResponse> matchingPersons = allPersons;

    if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
      return matchingPersons;

    switch (searchBy)
    {
      case nameof(Person.PersonName):
        matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.PersonName) ? temp.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      case nameof(Person.Email):
        matchingPersons = allPersons.Where(temp => (!string.IsNullOrEmpty(temp.Email) ? temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      case nameof(Person.DateOfBirth):
        matchingPersons = allPersons.Where(temp => ((temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      case nameof(Person.Gender):
        matchingPersons = allPersons.Where(temp => ((!string.IsNullOrEmpty(temp.Gender)) ? temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      case nameof(Person.CountryID):
        matchingPersons = allPersons.Where(temp => ((!string.IsNullOrEmpty(temp.Country)) ? temp.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      case nameof(Person.Address):
        matchingPersons = allPersons.Where(temp => ((!string.IsNullOrEmpty(temp.Address)) ? temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
        break;
      default: matchingPersons = allPersons; break;
    }

    return matchingPersons;
  }

  public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
  {
    if (string.IsNullOrEmpty(sortBy))
      return allPersons;

    List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
    {
      (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Email), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Email), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

      (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

      (nameof(PersonResponse.Age), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Age).ToList(),

      (nameof(PersonResponse.Age), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Age).ToList(),

      (nameof(PersonResponse.Gender), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Gender), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Country), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Country), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Address), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.Address), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

      (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

      (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

      _ => allPersons
    };

    return sortedPersons;
  }

  public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
  {
    if (personUpdateRequest == null)
      throw new ArgumentNullException(nameof(Person));

    // validation
    ValidationHelper.ModelValidation(personUpdateRequest);

    // get matching person object to update
    Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonID == personUpdateRequest.PersonID);
    if (matchingPerson == null)
    {
      throw new ArgumentException("Given person id doesn't exist");
    }

    // update all details
    matchingPerson.PersonName = personUpdateRequest.PersonName;
    matchingPerson.Email = personUpdateRequest.Email;
    matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
    matchingPerson.Gender = personUpdateRequest.Gender.ToString();
    matchingPerson.CountryID = personUpdateRequest.CountryID;
    matchingPerson.Address = personUpdateRequest.Address;
    matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

    return matchingPerson.ToPersonResponse();
  }

  public bool DeletePerson(Guid? personID)
  {
    if (personID == null)
      throw new ArgumentNullException(nameof(personID));

    Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);

    if (person == null)
      return false;

    _persons.RemoveAll(temp => temp.PersonID == personID);

    return true;
  }
}
