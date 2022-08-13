using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.DTO;
using TestProject.Models;
using TestProject.Services.DepartmentServices;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Department>>> GetAllAsync()
        {
            return Ok(await _departmentServices.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetByIdAsync(int id)
        {
            Department department = await _departmentServices.GetByIdAsync(id);
            return Ok(department);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Department>> CreateAsync([FromBody] DepartmentDTO departmentDto)
        {
            Department department = await _departmentServices.InsertAsync(departmentDto);
            return Ok(department);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<ActionResult<Department>> UpdateAsync([FromBody] Department department)
        {
            await _departmentServices.UpdateAsync(department);
            return Ok(department);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<List<Department>>> DeleteAsync([FromQuery] int id)
        {
            await _departmentServices.DeleteAsync(id);
            return Ok(await _departmentServices.GetAllAsync());
        }
    }
}
