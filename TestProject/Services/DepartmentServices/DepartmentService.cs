using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DepartmentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Department> InsertAsync(DepartmentDTO departmentDto)
        {
            Department department = GetMappedModel(departmentDto);
            _context.Add(department);
            await SaveAsync();
            return department;
        }

        private Department GetMappedModel(DepartmentDTO departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            return department;
        }

        public async Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Department department = await GetByIdAsync(id);
            _context.Departments.Remove(department);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
