using Application.Dto;

namespace Application.Contracts.Services;

public interface IPersonService
{
    public Task<IEnumerable<PersonDto>> GetPersons();
    public Task<PersonDto> GetPerson(int id);
    public Task CreatePerson(PersonDto person);
    public Task UpdatePerson(int id,PersonDto person);
    public Task DeletePerson(int id);
}