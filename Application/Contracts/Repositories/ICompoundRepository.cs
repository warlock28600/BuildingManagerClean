namespace Application.Contracts.Repositories
{
    public interface ICompoundRepository
    {
        public Task<IEnumerable<Domain.Entities.Compounds>> GetCompounds();
        public Task<Domain.Entities.Compounds> GetCompoundById(int id);
        public Task<Boolean> CreateCompound(Domain.Entities.Compounds compound);
        public Task<Boolean> UpdateCompound(int id,Domain.Entities.Compounds compound);
        public Task<Boolean> DeleteCompound(int id);
    }
}
