using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<Employee> InsertAsync(EmployeeDTO employeeDto);
        public Task UpdateAsync(Employee employee);
        public Task DeleteAsync(int id);

    }
}
