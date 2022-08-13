using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.ProgramingLanguageServices
{
    public interface IProgramingLanguageServices
    {
        public Task<List<ProgramingLanguage>> GetAllAsync();
        public Task<ProgramingLanguage> InsertAsync(ProgramingLanguageDTO programingLanguageDto);
        public Task UpdateAsync(ProgramingLanguage programingLanguage);
        public Task DeleteAsync(int id);
        public Task<ProgramingLanguage> GetByIdAsync(int id);
    }
}
