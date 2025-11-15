namespace Application.Contracts.Repositories
{
    public interface IResidentRepository
    {
        public Task<IEnumerable<Domain.Entities.ResidentEntity>> GetResidents();
        public Task<Domain.Entities.ResidentEntity?> GetResidentById(int id);
        public Task CreateResident(Domain.Entities.ResidentEntity resident);
        public Task UpdateResident(int id,Domain.Entities.ResidentEntity resident);
        public Task DeleteResident(int id);
    }
}
