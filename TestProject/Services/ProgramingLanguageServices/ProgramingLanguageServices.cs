using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TestProject.Data;
using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.ProgramingLanguageServices
{
    public class ProgramingLanguageServices : IProgramingLanguageServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProgramingLanguageServices(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ProgramingLanguage>> GetAllAsync()
        {
            return await _context.ProgrammingLanguages.ToListAsync();
        }

        public async Task<ProgramingLanguage> GetByIdAsync(int id)
        {
            return await _context.ProgrammingLanguages.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProgramingLanguage> InsertAsync(ProgramingLanguageDTO programingLanguageDto)
        {
            ProgramingLanguage programingLanguage = GetMappedModel(programingLanguageDto);
            _context.Add(programingLanguage);
            await SaveAsync();
            return programingLanguage;
        }

        private ProgramingLanguage GetMappedModel(ProgramingLanguageDTO programingLanguageDto)
        {
            ProgramingLanguage programingLanguage = _mapper.Map<ProgramingLanguage>(programingLanguageDto);
            return programingLanguage;
        }

        public async Task UpdateAsync(ProgramingLanguage programingLanguage)
        {
            _context.ProgrammingLanguages.Update(programingLanguage);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ProgramingLanguage programingLanguage = await GetByIdAsync(id);
            _context.ProgrammingLanguages.Remove(programingLanguage);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
