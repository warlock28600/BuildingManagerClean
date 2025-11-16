using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{

    private readonly BuildingDbContext _context;
    private readonly IMapper _mapper;

    public PersonRepository(BuildingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Persons>> GetAllAsync()
    {
        var persons = await _context.Persons.ToListAsync();
        return persons;
    }

    public async Task<Persons> GetByIdAsync(int id)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(p=>p.Id==id);
        return person;
    }

    public async Task<bool> CreateAsync(Persons person)
    {
        _context.Persons.Add(person);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }

    public async Task<bool> UpdateAsync(int id, Persons person)
    {
        var personEntity = await GetByIdAsync(id);

        if (personEntity == null)
        {
            throw new KeyNotFoundException($"Person with id {id} not found");
        }
        _mapper.Map(person, personEntity);
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            throw new KeyNotFoundException($"Person with id {id} not found");
        }
        _context.Persons.Remove(person);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
}