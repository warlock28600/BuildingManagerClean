using Application.Dto;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IPersonRepository
{
    public  Task<IEnumerable<Persons>> GetAllAsync();
    public Task<Persons> GetByIdAsync(int id);
    public Task<bool> CreateAsync(Persons person);
    public Task<bool> UpdateAsync(int id,Persons person);
    public Task<bool> DeleteAsync(int id);
}