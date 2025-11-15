using Application.Dto;

namespace Application.Contracts.Repositories;

public interface IPersonRepository
{
    public  Task<IEnumerable<PersonDto>> GetAllAsync();
    public Task<PersonDto> GetByIdAsync(int id);
    public Task CreateAsync(PersonDto person);
    public Task UpdateAsync(int id,PersonDto person);
    public Task DeleteAsync(int id);
}