using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents buisness logic for manipulating Person entity
/// </summary>
public interface IPersonsService
{
  /// <summary>
  /// Adds a new person into the list of persons
  /// </summary>
  /// <param name="personAddRequest">Person to add</param>
  /// <returns>Returns the same person details, along with newly generated PersonID</returns>
  PersonResponse AddPerson(PersonAddRequest? personAddRequest);

  /// <summary>
  /// Returns all persons
  /// </summary>
  /// <returns>Returns a list of objects of PersonResponse</returns>
  List<PersonResponse> GetAllPersons();
}
