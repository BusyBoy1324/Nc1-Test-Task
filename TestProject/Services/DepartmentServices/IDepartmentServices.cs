using TestProject.DTO;
using TestProject.Models;

namespace TestProject.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        public Task<List<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<Department> InsertAsync(DepartmentDTO departmentDto);
        public Task UpdateAsync(Department department);
        public Task DeleteAsync(int id);
    }
}
