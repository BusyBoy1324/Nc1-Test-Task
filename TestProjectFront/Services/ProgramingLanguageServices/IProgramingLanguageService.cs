using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.ProgramingLanguageServices
{
    public interface IProgramingLanguageService
    {
        public List<ProgramingLanguage> ProgramingLanguages { get; set; }
        public Task<ProgramingLanguageDTO> CreateAsync(ProgramingLanguageDTO programingLanguageDto);
        public Task<List<ProgramingLanguage>> DeleteAsync(int id);
        public Task<List<ProgramingLanguage>> GetAllAsync();
        public Task<ProgramingLanguage> UpdateAsync(ProgramingLanguage programingLanguage);
        public Task<ProgramingLanguage> GetByIdAsync(int id);

    }
}
