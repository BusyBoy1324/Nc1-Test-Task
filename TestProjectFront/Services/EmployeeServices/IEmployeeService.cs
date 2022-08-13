using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public List<Employee> Employees { get; set; }
        public Task<EmployeeDTO> CreateAsync(EmployeeDTO employeeDto);
        public Task<List<Employee>> DeleteAsync(int id);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<Employee> UpdateAsync(Employee employee);
    }
}
