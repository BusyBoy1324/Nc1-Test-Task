using TestProject.DTO;
using TestProject.Models;

namespace TestProjectFront.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        public List<Department> Departments { get; set; }
        public Task<DepartmentDTO> CreateAsync(DepartmentDTO departmentDto);
        public Task<List<Department>> DeleteAsync(int id);
        public Task<List<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<Department> UpdateAsync(Department department);
    }
}
