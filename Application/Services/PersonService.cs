using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class PersonService:IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonDto>> GetPersons()
    {
        var persons = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PersonDto>>(persons);
    }

    public async Task<PersonDto> GetPerson(int id)
    {
        var Person = await _repository.GetByIdAsync(id);
        return _mapper.Map<PersonDto>(Person);  
    }

    public async Task CreatePerson(PersonDto person)
    {
       await _repository.CreateAsync(_mapper.Map<Persons>(person));
    }

    public async Task UpdatePerson(int id, PersonDto person)
    {
       await _repository.UpdateAsync(id, _mapper.Map<Persons>(person));
    }

    public async Task DeletePerson(int id)
    {
        await _repository.DeleteAsync(id);
    }
}