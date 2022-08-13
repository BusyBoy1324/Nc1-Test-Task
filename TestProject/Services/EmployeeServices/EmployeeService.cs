using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EmployeeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Employee> InsertAsync(EmployeeDTO employeeDto)
        {
            var department = await _context.Departments.Where(n => n.Name == employeeDto.Department).FirstOrDefaultAsync();
            var programingLanguage = await _context.ProgrammingLanguages.Where(n => n.Name == employeeDto.ProgramingLanguage).FirstOrDefaultAsync();
            Employee employee = GetMappedModel(employeeDto);
            employee.DepartmentId = department.Id;
            employee.ProgramingLanguageId = programingLanguage.Id;
            employee.ProgramingLanguageName = programingLanguage.Name;
            _context.Add(employee);
            await SaveAsync();
            return employee;
        }

        private Employee GetMappedModel(EmployeeDTO employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Employee employee = await GetByIdAsync(id);
            _context.Employees.Remove(employee);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
