using Application.Dto.Compound;

namespace Application.Contracts.Services
{
    public interface ICompoundService
    {
        public Task<IEnumerable<CompoundGetDto>> GetCompounds();
        public Task<CompoundGetDto> GetCompoundById(int id);
        public Task<bool> CreateCompound(CompoundCreateDto compoundCreateDto);
        public Task<bool> UpdateCompound(int id, CompoundCreateDto compoundCreateDto);
        public Task<bool> DeleteCompound(int id);
    }
}
